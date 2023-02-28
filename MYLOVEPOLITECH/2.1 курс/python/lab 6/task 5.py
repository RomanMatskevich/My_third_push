import datetime

def times():
    now = datetime.datetime.now()
    return now.strftime("%d/%m/%Y %H:%M:%S")

list1 = []
file = open('tsk5/guest_book.txt','w')
name = input("Введіть ім'я ")
i=0
while name != "":
    try:
        list1.append("Доброго ранку" + " " + name)
        print(list1[i])
        a = list1[i]

        file.write(str(a) + " " + times() + "\n")
        i += 1
        name = input("Введіть ім'я ")
    except:
        break

file.write("\n\n\n\n\n" + "Остання коректировка файлу" + " " + times())
file.close()