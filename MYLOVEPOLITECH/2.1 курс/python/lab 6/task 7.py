import csv

list = []
with open('marks.lab6.csv', newline='',encoding= "UTF-8") as File:
    reader = csv.reader(File)
    for row in reader:
        list.append(row)

def floatss(a):
    cant = a.split(",")
    if cant[1] == '50':
        return float(cant[0]) + 0.5
    elif cant[1] == '00':
        return float(cant[0])


mark_list = [0]*21

k = 0
j = 0.5


for i in range(0,len(list)):
    while j <= 10.0:
        if floatss(list[i][4]) == j:
            mark_list[k] += 1
        j += 0.5
        k += 1
    j = 0.0
    k = 0


mark_time_list = [0]*21

j = 0

for i in range(0,20):
    count = 0
    mark = 0
    for j in range(0,len(list)):
        if int(list[j][3][0:2]) == i:
            mark += floatss(list[j][4])
            count += 1
            mark_time_list[i] = mark/count


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

print("\n\n\n")

for m in range(0,len(mark_list)):
    print(f"Кількість студентів, що отримали оцінку {m/2} становить {mark_list[m]}")

print("\n\n\n")
for m in range(0,len(mark_time_list)):
    print(f"Середня оцінка за час {m}хв становить {mark_time_list[m]}")

print("\n\n\n")
print(f"Кількість студентів, що проходили тестування {len(list)}")
file = open('tsk 7/result_kmr.txt', 'w')
for i in range(0,len(true_list)):
    file.write(f"На {i+1} питання правильно дали відповідь {str(int(true_list[i]))}% студентів\n")

file.write("\n\n\n")
file.write(f"Найкращі студенти\n1) id:{list[94][0]} оцінка 10 час виконання {list[94][3]}\n2) id:{list[105][0]} оцінка 10 час виконання {list[105][3]}\n")
file.write(f"3) id:{list[78][0]} оцінка 10 час виконання {list[78][3]}\n4) id:{list[77][0]} оцінка 10 час виконання {list[77][3]}\n")
file.write(f"5) id:{list[128][0]} оцінка 10 час виконання {list[128][3]}\n")
file.close()



