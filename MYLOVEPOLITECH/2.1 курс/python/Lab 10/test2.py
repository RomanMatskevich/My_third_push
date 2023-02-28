import mod as user
import unittest

class TestStringMethods2(unittest.TestCase):
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

    obj = user.User('roman','matskevich','chater@gmail.com','chater',1)
    def test_describe_user(self):
        """output information about user"""
        print("id:" + self.id())
        self.assertIsNone(self.obj.describe_user())

    def test_greeting_user(self):
        """output short text vith user name"""
        print("id:" + self.id())
        self.assertIsNone(self.obj.greeting_user())

    def test_increment_login_attempts(self):
        """login_attempts +=1"""
        print("id:" + self.id())
        self.assertIsNone(self.obj.increment_login_attempts())

    obj.reset_login_attempts()

    def test_increment_login_attempts_after_reset(self):
        """resets_login_attempts"""
        print("id:" + self.id())
        self.assertIsNone(self.obj.increment_login_attempts())

    bbj2 = user.Admin('roman','matskevich','chater@gmail.com','chater',1)
    bbj3 = user.Priveleges()
    def test_priveleges_into_admin(self):
        """resets_login_attempts"""
        print("id:" + self.id())
        self.assertIsNone(self.bbj3.show_privileges())


