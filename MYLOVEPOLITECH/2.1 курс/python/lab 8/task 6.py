class Full_Name(ValueError):
    def __init__(self,*args):
        if args:
            self.message = args[0]
        else:
            self.message = None
    def __str__(self):
        if len(self.message):
            return 'Ім\'я не повне-->{0}'.format(self.message)

name = "Роман"
if len(name)<10:
    raise Full_Name(name)
name = "Роман Мацкевич Геннадійович"
if len(name)<10:
    raise Full_Name(name)


