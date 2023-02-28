const { readFile, writeFile } = require('fs');
const { join } = require('path');

const userPath = join(__dirname, 'user.json')

const add = (title, level) => {
    getAll (user => {
        const isExists = user.languages.find( elem => elem.title === title );
        if (isExists)
            return console.log(`Помилка! Ця момва вже додана до списку!`);

        user.languages.push({title, level});
        write(user);
        console.log(`Мову додано успішно`);
    });
}

const remove = title => {
    getAll(user => {
        const isExists = user.languages.find( elem => elem.title === title );
        if (!isExists)
            return console.log(`Такої мови немає в списку.`);

        user.languages = user.languages.filter(elem => elem.title !== title);
        write(user);
        console.log(`Мову'${title}' ушпішно видалено!`);
    });
}

const list = () => {
    getAll(user => {
        console.log(`Список ваших мов:`);
        user.languages.forEach( elem => console.log(elem.title) );
    });
}

const read = title => {
    getAll(user => {
        const isExists = user.languages.find( elem => elem.title === title );
        if (!isExists)
            return console.log(`Цієї мови немає в списку!`);

        const lang = user.languages.filter( elem => elem.title === title)[0];
        console.log(`Мова: ${lang.title}\nРівень: ${lang.level}` );
    });
}


//
const getAll = callback => {
    readFile(userPath, 'utf8', (err, data) => {
        if (err)
            throw err;
        try {
            callback( JSON.parse(data) );
        } catch {
            callback([]);
        }
    });
}

const write = data => {
    writeFile(userPath, JSON.stringify(data), {}, err => {
        if (err)
            throw err;
    });
}

module.exports = {
    add, list, remove, read
};