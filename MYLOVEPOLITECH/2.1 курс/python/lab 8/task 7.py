class Arabian_Rome():
    def __init__(self, number):
        self.number = number

    """Я не прочитав, що вистачило б десяткового числа, тому розробив список для чисел до 3999"""
    def __str__(self):
        if 0<self.number<3999:
            help_list = [
                ["None"],
                ["None", "M", "MM", "MMM"],
                ["None", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"],
                ["None", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"],
                ["None", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"],
            ]
            leng = len(str(self.number))

            number = str(self.number)
            i = 0
            out_word = ""
            while i < leng:
                if int(number[i]) != 0:
                    out_word += help_list[-int(leng) + i][int(number[i])]
                else:
                    pass
                i += 1
            return out_word
        else:
            return "Число не підходить під діапазон від 0 до 3999"

class Rome_Arabian():
    def __init__(self, number):
        self.number = number

    def __str__(self):
        help_list = ["None", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"]
        i=0
        out_number = 0
        while i < 10:
            if self.number == help_list[i]:
                out_number += i
            i+=1
        return f"{out_number}"

print(Arabian_Rome(497))
print(Arabian_Rome(2167))
print(Arabian_Rome(11))
print(Arabian_Rome(7))
print(Rome_Arabian("IV"))
print(Rome_Arabian("VII"))