from aiogram import Bot, types
from aiogram.dispatcher import Dispatcher
from aiogram.utils import executor

import config
from config import *


bot = Bot(token=TOKEN)
dp = Dispatcher(bot)


@dp.message_handler(commands=['start'])
async def process_start_command(message: types.Message):
    await message.reply("Готовий почати тестування?")

questions = []
questions.append(config.Question('Який тип данних в мові python є змінним?','Список','Строка','Число','Кортеж'))
questions.append(config.Question('Яка бібліотека відповідає за побудову ботів','Math','Aiogram','config','Бот пишеться вручну'))
questions.append(config.Question('Python - мова програмування-','Інтерпритована','Компільована','Це не мова програмування','Стильова'))
questions.append(config.Question('Яка бібліотека відповідає за використання математичних функцій','Math','Aiogram','config','пишуться вручну'))
questions.append(config.Question('Ключове слово def використовується для','оголошення класу','оголошення методу','оголошення змінної','оголошення списку'))
questions.append(config.Question('Для перетворення числа в строку використовуэться','str()','tuple()','bool()','func()'))
questions.append(config.Question('Що виведе данна функція print(str(int(\'2\')) + str(int(\'8\')))','10','-6','помилку','28'))
questions.append(config.Question('Результат операції x = 4\ny=4\n x+=y*y-str(x)','16','6','помилку','4'))
questions.append(config.Question('Яка команда підключає бібліотеки в Python','import ...','lib','import lib','export lib'))
questions.append(config.Question('','16','6','помилку','4'))
async def echo_message(msg: types.Message):
    await bot.send_message(msg.from_user.id, msg.text)


if __name__ == '__main__':
    executor.start_polling(dp)


