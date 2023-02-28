require('dotenv').config()
const express = require('express')
const mongoose = require('mongoose');

const router = require('./routers/index');

const PORT = process.env.PORT || 5000;
const app = express();

app.use(express.json());
app.use('/', router);

mongoose.connect(process.env.DB_URL)
    .then(()=>{
        app.listen(PORT, () => console.log(`Server started on PORT ${PORT}...`))
    })
    .catch(e => {console.log(e)})