import random
import time


def decorator(list_in, bottom_in, upper_in):
    start_time = time.time()
    print(function(list_in, bottom_in, upper_in))
    return time.time() - start_time


def function(list_in, bottom_in, upper_in):
    final_list = []
    if max(list_in) - upper_in < min(list_in) + bottom_in or min(list_in) + bottom_in > max(list_in) - upper_in:
        print("Вихід за межі мін. так макс. значення!")
        return 0
    for i in range(len(list_in)):
        if list_in[i] >= min(list_in) + bottom_in and list_in[i] <= max(list_in) - upper_in:
            final_list.append(list_in[i])
    return final_list


n = int(input("Введіть розмір списку"))

list = []
for i in range(0, n):
    list.append(random.randint(-50, 51))
print(list)


bottom = int(input("Ведіть нижню межу"))
upper = int(input("Введіть верхню межу"))

print(f"Час виконання програми - {decorator(list, bottom, upper)}")