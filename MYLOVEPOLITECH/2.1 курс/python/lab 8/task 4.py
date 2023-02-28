class Dog():

    pets_clas = "mammal"
    nature = "Спокійний, доброзичливий"
    breed = "DOG"

    def __init__(self, __age, __name):
        self.__age = __age
        self.__name = __name

    def get_name(self):
        print(str(self.__name))

    def get_age(self):
        print(str(self.__age) + " Років")

    def get_voice(self):
        print(f"{self.__name} Гавкає")

    def get_spin(self):
        print(f"{self.__name} Бігає за хвостом")

"""Наслідуваний класс від dog"""

class Amstaff(Dog):

    pets_clas = "mammal"
    nature = "Спокійний, доброзичливий, агресивний при небезпеці"
    breed = "Amstaff"

    def __init__(self, __age, __name):
        Dog.__init__(self, __age, __name)
        self.__age = __age
        self.__name = __name
    def get_voice(self):
        print(f"{self.__name} Тихо гавкає")

    def get_circle(self):
        print(f"{self.__name} Тримає кільце в щелепі")

"""Наслідуваний класс від dog"""
class Buldog(Dog):
    pets_clas = "mammal"
    nature = "Спокійний, вразливий, чуттєвий"
    breed = "Buldog"
    def get_voice(self):
        print(f"{self.__name} Грубо та голосно гавкає")

    def __init__(self, __age, __name):
        Dog.__init__(self, __age, __name)
        self.__age = __age
        self.__name = __name


    def get_bed(self ):
        print(f"{self.__name} лягла на спину")

"""Клас зі списком дом. тварин """
class Pets(Buldog, Amstaff):

    list = []
    Nargizka = Buldog(6, "Nargizka")
    list.append(Nargizka)
    Mulan = Buldog(8, "Mulan")
    list.append(Mulan)
    Lord = Amstaff(4, "Lord")
    list.append(Lord)

"""інфа про  Nargizka """

Pets.list[0].get_name()
Pets.list[0].get_age()
Pets.list[0].get_bed()
Pets.list[0].get_voice()
Pets.list[0].get_spin()
print("\n")
"""інфа про Mulan"""
Pets.list[1].get_name()
Pets.list[1].get_age()
Pets.list[1].get_bed()
Pets.list[1].get_voice()
Pets.list[1].get_spin()
print("\n")
"""інфа про Lord"""
Pets.list[2].get_name()
Pets.list[2].get_age()
Pets.list[2].get_circle()
Pets.list[2].get_voice()
Pets.list[2].get_spin()