class Shop():

    def __init__(self, shop_name, shop_type, number_of_units = 100):
        self.shop_name = shop_name
        self.shop_type = shop_type
        self.number_of_units = number_of_units

    def describe_shop(self):
        print(self.shop_name)
        print(self.shop_type)

    def open_shop(self):
        print("онлайн магазин відкритий")

    def set_number_of_units(self,number):
        self.number_of_units = number

    def increment_number_of_units(self,number):
        self.number_of_units += number

class Discount(Shop):
    __discount_products = ['product1','product2','product7']
    def get_discount_products(self):
        print(self.__discount_products)




