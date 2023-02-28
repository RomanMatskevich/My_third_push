import datetime


class Person(object):

    def __init__(self,surname,last_name,nickname,birth_date):
        self.surname = surname
        self.last_name = last_name
        self.nickname = nickname
        self.birth_date = datetime.datetime(int(birth_date[0:4]),int(birth_date[5:7]),int(birth_date[8:10]))
        self.date = datetime.datetime.now()
    def get_age(self):
        if self.date.month < self.birth_date.month:
            return self.date.year - self.birth_date.year - 1;'''якщо не було др'''
        else:
            return self.date.year - self.birth_date.year
    def get_fullname(self):
        return self.surname + " " + self.last_name

def times(time):
    return time.strftime("%d/%m/%Y")




def modifier(filename):
    file = open(filename,'r',encoding="UTF-8")
    text = file.readlines()
    person_list = []
    i=0
    while i < len(text):
        person_list.append(Person(text[i],text[i+1],text[+2],text[i+3]))
        i += 4
    file.close()
    file = open(filename, 'w', encoding="UTF-8")

    for i in range(0,len(person_list)):
        file.write(person_list[i].surname)
        x = person_list[i].get_fullname()
        file.write(x)
        file.write(person_list[i].last_name)
        file.write(person_list[i].nickname)
        file.write(times(person_list[i].birth_date) + "\n")
        file.write(str(person_list[i].get_age())+ " " +"Років")

    file.close()




modifier('person.txt')
exemp = Person("Роман","Мацкевич","counted","2003-03-23")
print(exemp.get_fullname())
print(str(exemp.get_age()) + " років")