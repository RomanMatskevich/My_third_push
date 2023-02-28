class Apple():
    states = {1:"Відсутнє", 2:"Цвітіння", 3:"Зелене", 4:"Червоне"}

    def __init__(self,__index):
        self.__index = __index
        self.__state = self.states[1]

    def state_info(self):
        return self.__state

    def grow(self):
        i=1
        while i<=4:
            if self.__state == self.states[i]:
                self.__state = self.states[i+1]
                break
            i+=1
    def is_ripe(self):
        if self.__state == self.states[4]:
            return True

class AppleTree():
    def __init__(self,amount):
        self.apples = []
        for i in range(0,amount):
            self.apples.append(Apple(i))
    def grow_all(self):
        for item in self.apples:
            item.grow()



    def all_are_ripe(self):
        if len(self.apples) == 0:
            return False
        else:
            for item in self.apples:
                if not item.is_ripe():
                    return False
            return True

    def give_away_all(self):
        self.apples = []
class Gardener():
    def __init__(self,name,__tree):
        self.name =  name
        self.__tree = __tree

    def work(self):
        self.__tree.grow_all()

    def harvest(self):
        if self.__tree.all_are_ripe():
            self.__tree.give_away_all()
            print("Урожай зібрано")
        else:
            print("Ще не всі яблука достигли")

    def apple_base(self):
        print(f"Кількість яблук {len(self.__tree.apples)}")
        print(f"{self.__tree.apples[1].state_info()}")


first = Apple(1)
second = Apple(2)
third = Apple(3)

moon = AppleTree(10)
moon1 = Gardener("Steve",moon)
moon1.work()
moon1.apple_base()
moon1.work()
moon1.apple_base()
moon1.harvest()
moon1.work()
moon1.harvest()