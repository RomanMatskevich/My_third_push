class Human():

    default_name = "Antony"
    default_age = "25"

    def __init__(self,name,age,__money,__house):
        self.name = name
        self.age = age
        self.__money = __money
        self.__house = __house

    def info(self):
        print(f"{self.name}")
        print(f"Вік {self.age}")
        print(f"Коштів {self.__money}")
        print(f"Будинок")
        self.__house.info()
    @classmethod
    def default_info(self):
        print(f"{self.default_name}")
        print(f"{self.default_age}")

    def make_deal(self,link,cost):
        self.__house = link
        self.__money -= cost

    def earn_money(self,sum):
        self.__money += sum
        print(f"Рахунок поповнено на {sum}")

    def buy_house(self,link,sale = 0.1):
        if self.__money < link.get_price() * (1-sale):
            print("У вас недостатнь коштів для здійснення операції")
        else:
            self.make_deal(link, link.get_price() * (1 - sale))
class House():
    def __init__(self,__area = "40кв.м",__price = 10000):
        self.__area = __area
        self.__price = __price
    def final_price(self,sale):
        return self.__price * (1-sale)

    def get_price(self):
        return self.__price

    def get_area(self):
        return self.__area

    def info(self):
        print(f"Площа {self.__area}")
        print(f"Ціна {self.__price}")


class SmallHouse(House):
    def __init__(self,__area = "36.кв.м",__price = 35000):
        super().__init__(__area,__price)

Human.default_info()
My1House = House("12кв.м",7000)
Rom4ik = Human("Roman",18,1000,My1House)
Rom4ik.info()
house = SmallHouse()
Rom4ik.buy_house(house,0.1)
Rom4ik.earn_money(36000)
Rom4ik.buy_house(house,0.1)
Rom4ik.info()