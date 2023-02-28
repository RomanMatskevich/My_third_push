class Alphabet():
    def __init__(self):
         self.lan = "УКР"
         self.letters = ('а','б','в','г','д','е','є','ж','з','и','і','ї','й','к','л','м','н','о',
                                                'п','р','с','е','у','ф','х','ц','ч','ш','щ','ь','ю','я')

    def print_alphabet(self):
        print(self.letters)

    def letters_num(self):
        return len(self.letters)

    def is_ua_lang(self,text):
        text = text.lower()
        if text.find("э") != -1 or text.find("ї") != -1 or text.find("г") != -1 or text.find("щ")!=-1:
            return f"належить Українській мові"
        else:
            return "Не належить Українській мові"
class EngAlphabet(Alphabet):

    def __init__(self):
        super().__init__()
        self.lan = "Eng"
        self.letters = ('q','w','e','r','t','y','u','i','o','p','a','s','d','f','g','h','j','k','l','z','x','c','v','b','n','m')
        self.__en_letters_num = len(self.letters)

    def is_en_letter(self,text):
        text = text.lower()
        if text.find("f") != -1 or text.find("g") != -1 or text.find("q") != -1 or text.find("s") != -1 or text.find("j")!=-1:
            return f"належить англійській мові"
        else:
            return "Не належить англійській мові"
    def letters_num(self):
        return f"{self.__en_letters_num}"
    def example(self):
        return "this text is written in English"



Eng_lang = EngAlphabet()
Eng_lang.print_alphabet()
print(f"кількість букв {Eng_lang.letters_num()}")
print(f"Буква j {Eng_lang.is_en_letter('j')}")
print(f"Буква Щ {Eng_lang.is_ua_lang('Щ')}")
print(Eng_lang.example())