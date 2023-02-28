class Bufer():
    __list_count = []
    def __init__(self):
        pass

    def add(self, a):
        summ = 0
        self.__list_count += a
        if len(self.__list_count) >= 5:

            i = 0
            while i<5:
                summ += int(self.__list_count[i])
                i+=1
            self.__list_count = self.__list_count[5:len(self.__list_count)]
            print(summ)
            ls = []
            self.add(ls)

    def current_par(self):
        summ = 0
        for item in self.__list_count:
            summ += int(item)
        print(summ)


prog = Bufer()
menu = input("close-закрити і виввести, що залишилось в буфері\nВивести сумму,що зараз в буфері-out\n-->")
if menu != "close":
    prog.add(menu.split(','))
    while menu != "close":
        menu = input("->>")
        if menu == "out":
            prog.current_par()
        else:
            prog.add(menu.split(','))

