a=int(input("a:"))
b=int(input("b:"))
c=float(input("c:"))
d=float(input("d:"))
MathList=[]
MathList.append(a+b)
MathList.append(a-b)
MathList.append(a*c)
MathList.append(d/b)
MathList.append(a**a)
MathList.append(d//c)
MathList.append(a%c)
print("Кількість елементів у списку:", len(MathList))
print(MathList[1],MathList[3],MathList[5])
c=MathList[1]
MathList[1]=MathList[4];
MathList[4]=c
print(MathList)
name=input("Введіть ваше прізвище та ім'я")
print("Лабораторна робота №1")
print("Виконав",name)
print("Під час виконання було вивчено прості арифметичні операції, та методи вводу і виводу інформаціїї")