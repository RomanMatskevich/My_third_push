import csv
list = []

def floatss(a):
    cant = a.split(",")
    if cant[1] == '50':
        return float(cant[0]) + 0.5
    elif cant[1] == '00':
        return float(cant[0])

with open("marks2.lab11.csv", newline='', encoding="UTF-8") as File:
    reader = csv.reader(File)
    for row in reader:
        list.append(row)

def avg_stat():
    true_list = [0] * 20
    k = 0
    for j in range(5, len(list[0])):
        count = 0.0
        for i in range(0, len(list)):
            if list[i][j] == "0,50":
                count += 0.5
            elif list[i][j] == "0,33":
                count += 0.33
            else:
                continue
        true_list[k] += (count / (len(list)/2)) * 100
        k += 1
    true_list = tuple(true_list)
    return true_list
print(avg_stat())

def marks_stat():

