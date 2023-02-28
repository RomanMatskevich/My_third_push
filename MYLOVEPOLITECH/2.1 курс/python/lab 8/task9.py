class User():

    def __init__(self, first_name, last_name, e_mail, nickname,  accept_to_news):
        self.first_name = first_name
        self.last_name = last_name
        self.e_mail = e_mail
        self.nickname = nickname
        self.accept_tp_news = accept_to_news

    def describe_user(self):
        print(self.first_name + " " + self.last_name)

    def greeting_user(self):
        print("Вітаємо " + self.nickname)

    login_attempts = 0

    def increment_login_attempts(self):
        self.login_attempts += 1

    def reset_login_attempts(self):
        self.login_attempts = 0










