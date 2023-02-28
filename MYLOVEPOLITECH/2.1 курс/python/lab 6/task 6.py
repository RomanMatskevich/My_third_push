import re
import datetime
import time

def times():
    now = datetime.datetime.now()
    return now.strftime("%d/%m/%Y %H:%M:%S")


text = open("task 6/text_python.txt",'r')
text = text.read()
letter_in = input("Введіть букву для пошуку (eng) ")
word_in = input("Введіть слово для пошуку (eng) ")

start_time = time.time()
count = re.findall( word_in.lower(), text.lower())
count1 = re.findall(letter_in.lower(),text.lower())
print("Знайдено букв ",len(count1))
print("Знайдено слів",len(count))
end_time = time.time() - start_time
print("Час виконання програми",end_time)

file = open('task 6/result.txt','w')
file.write(f"Час створення файлу {times()}\nЗнайдено букв {len(count1)}\nЗнайдено слів {len(count)}\nЧас виконання програми {end_time}")
