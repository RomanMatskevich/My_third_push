class Car(object):
    def __init__(self,c_brand,c_model,c_year,__speed = 0):
        self.c_brand = c_brand
        self.c_model = c_model
        self.c_year = c_year
        self.__speed = 0

    def acelerate(self):
        self.__speed += 5
    def brake(self):
        self.__speed -= 5
    def get_speed(self):
        return f"{self.__speed}"

camry3_5 = Car("Toyota","camry40",2005)
n=0
while n<5:
    camry3_5.acelerate()
    print(f"speed {camry3_5.get_speed()}")
    n += 1
n=0
while n<5:
    camry3_5.brake()
    print(f"speed {camry3_5.get_speed()}")
    n += 1
