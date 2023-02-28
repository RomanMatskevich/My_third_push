import random

class Coin(object):
    __sideup = "head"
    def __init__(self,__sideup = "0"):
        if random.randint(0,1) == 0:
            self.__sideup = "head"
        else:
            self.__sideup = "tails"

    def __str__(self):
        return f"{self.__sideup}"

    def toss(self,__sideup = "head"):
        if random.randint(0, 1) == 0:
            self.__sideup = "head"
        else:
            self.__sideup = "tails"
        return f"{self.__sideup}"

coinflip = Coin()
print(f"Значення coinflip при створенні {coinflip}")
print("Підкидаємо монету 20 разів")
N = 0
while N<20:
    print(coinflip.toss())
    N+=1