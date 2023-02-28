const {sequalize} = require('sequelize')

module.exports = new sequalize(
    process.env.DB_NAME,
    process.env.DB_USER,
    process.env.DB_PASSWORD,
    {
        dialect: 'postgres',
        host: process.env
    }
)