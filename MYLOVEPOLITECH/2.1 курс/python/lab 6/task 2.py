a = input("-->")
list = []
while True:
    try:
        list.append(a)
        a = int(input("-->"))
    except:
        break
f1 = open('tsk2.files/parn.txt','w')
f2 = open('tsk2.files/neparn.txt','w')
for index in list:
    if int(index) %2 == 0:
        f1.write(str(index) + "\n")
    else:
        f2.write(str(index) + "\n")
f1.close()
f2.close()
print("Данні записані в файли")