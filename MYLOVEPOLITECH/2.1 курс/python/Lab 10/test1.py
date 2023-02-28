import task8 as shop
import unittest

class TestStringMethods(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        print("setUpClass")
        print("==========")
    @classmethod
    def tearDownClass(cls):
        print("==========")
        print("tearDownClass")

    def setUp(self):
        """Set up for test"""
        print("Set up for [" + str( self.shortDescription()) + "]")

    def tearDown(self):
        """Tear down for test"""
        print("Tear down for [" + str(self.shortDescription()) + "]")
        print("")

    def test_wrong_name(self):
        """create a new object (Shop vith 2 params)"""
        print("id:" + self.id())
        self.assertTrue(shop.Shop('1', '1'))

    def test_for_ex_def_describe_shop1(self):
        """create 1 object(shop) and use describe_shop()"""
        print("id:" + self.id())
        self.obj1 = shop.Shop('1shop', 'shoes')
        self.assertIsNone(self.obj1.describe_shop())

    def test_for_ex_def_describe_shop2(self):
        """create 1 object(shop) and use describe_shop()"""
        print("id:" + self.id())
        self.obj2 = shop.Shop('2shop', 'cars')
        self.assertIsNone(self.obj2.describe_shop())

    def test_for_ex_def_describe_shop3(self):
        """create 1 object(shop) and use describe_shop()"""
        print("id:" + self.id())
        self.obj3 = shop.Shop('3shop', 'dress')
        self.assertIsNone(self.obj3.describe_shop())

    obj = shop.Shop('1shop', 'shoes')

    def test_for_object_store_one(self):
        """add atribut and out"""
        print("id:" + self.id())

        self.assertTrue(self.obj.number_of_units)

    def test_for_object_store_two(self):
        """add to number_of_units 5"""
        print("id:" + self.id())
        self.obj.number_of_units += 5
        self.assertTrue(self.obj.number_of_units)

    def test_set_number_of_units(self):
        """add a method set"""
        print("id:" + self.id())
        self.assertIsNone(self.obj.set_number_of_units(5))

    def test_increment_number_of_units(self):
        """add a method incriment"""
        print("id:" + self.id())
        self.assertIsNone(self.obj.increment_number_of_units(5))

    obj4 = shop.Discount('1', '1', 100)

    def test_get_discounts_ptoducts(self):
        """add a method in class Discount()"""
        print("id:" + self.id())

        self.assertIsNone(self.obj4.get_discount_products())
