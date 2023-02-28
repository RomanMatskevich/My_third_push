from task2 import *
class Priveleges():
    privileges = ["Allowed to add message", "Allowed to delete users", "Allowed to ban users"]

    def show_privileges(self):
        for item in self.privileges:
            print(item)

class Admin(User):
    priv = Priveleges()
