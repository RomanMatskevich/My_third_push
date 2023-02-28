class Bank(object):
    __balance = 100
    def __init__(self,__balance = 100):
        self.__balance = __balance
    def __str__(self):
        return f"Баланс: {self.__balance}"
    def add_money(self,money):
        self.__balance += int(money)
        print("Операція успішна")
    def take_money(self,money):
        if self.__balance > money:
            self.__balance -= money
            print("Операція успішна")
        else:
            print("нажаль недостатньо коштів")

menu = 5
money = Bank()
while menu!=4:
    menu = int(input("Оберіть, що саме бажаєте зробити?\n1.Перевірити баланс\n2.Додати кошти\n3.Зняти кошти\n4.Закрити меню\n"))

    if menu == 1:
        print(money)
    elif menu == 2:
        mani = int(input("Введіть сумму:"))
        money.add_money(mani)
    elif menu == 3:
        mani = int(input("Введіть сумму:"))
        money.take_money(mani)
