import csv
def floatss(a):
    help = a.split(",")
    if help[1] == '50':
        return float(help[0]) + 0.5
    elif help[1] == '00':
        return float(help[0])
list = []
with open('marks.lab6.csv', newline='',encoding= "UTF-8") as File:
    reader = csv.reader(File)
    for row in reader:
        list.append(row)
        print(row)

true_list = [0]*20
k=0
for j in range(5,len(list[0])):
    count = 0.0
    for i in range(0,len(list)):
        if list[i][j] == "0,50":
            count += 0.5
        else:
            continue
    true_list[k] += (count/85)*100
    k += 1
print(true_list)


best_list = []
for i in range(0,len(list)):
    if floatss(list[i][4]) == 10 and int(list[i][3][0:2]) < 9:
        print(i+1)
        print(list[i][3])
        best_list.append(int(list[i][3][0:2]))
print(best_list)
best_list.sort()
print(best_list)