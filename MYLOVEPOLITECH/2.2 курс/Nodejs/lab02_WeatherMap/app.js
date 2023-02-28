const  express = require('express');
const hbs = require('hbs');
const { Navigator } = require('node-navigator');
const fetch = require('node-fetch2');


const navigator = new Navigator();

const PORT = 5000;
const CITIES = ['Kyiv', 'Zhytomyr', 'New York', 'Warsaw', 'London'];
const APIKEY = '0fe07b1ed2a13bf1ecedc174e4547d03';

const fetchWeather = async (url) => {
    return await fetch(url, {
        method: 'GET',
        mode: 'cors',
        headers: { 'Content-Type': 'application/json' }
    });
}
const app = express();
app.set('view engine', 'hbs');
hbs.registerPartials(__dirname + '/views/partials');

app.get('/', (req, res) => {
    res.render('main.hbs');
});
app.get('/weather/', async (req, res) => {
    navigator.geolocation.getCurrentPosition(async (pos) => {
        const result = await fetchWeather(`https://api.openweathermap.org/data/2.5/onecall?lat=${pos.latitude}&lon=${pos.longitude}&exclude=hourly,daily&appid=${APIKEY}`).then(response => response.json());
        return res.render('weatherPage.hbs', {
            CITIES,
            cityName: `your current location (${pos.latitude}; ${pos.longitude})`,
            pressure: result.current.pressure,
            humidity: result.current.humidity,
            temperature: Math.round(result.current.temp - 273, 0),
            icon: `https://openweathermap.org/img/wn/${result.current.weather[0]['icon']}@4x.png`
        });
    });
});
app.get('/weather/:city', async (req, res) => {
    const {city} = req.params;
    const result = await fetchWeather(`https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${APIKEY}`).then(response => response.json());
    if (result.code === 404)
        return res.status(404).render("404.hbs");
    return res.render('weatherPage.hbs', {
        CITIES,
        cityName: result.name,
        pressure: result.main.pressure,
        humidity: result.main.humidity,
        temperature: (result.main.temp - 273).toFixed(0),
        icon: `https://openweathermap.org/img/wn/${result.weather[0]['icon']}@4x.png`
    });
});

app.use((req, res, next) => {
    res.redirect('/');
})

const start = () =>{
    try{
        app.listen(PORT, () => console.log(`Server started on PORT ${PORT}...`));
    }catch (e){
        console.log(e);
    }
};
start();