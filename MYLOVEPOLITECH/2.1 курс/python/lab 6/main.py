f = open('numbers.txt','r')
numbers = f.read()
list = numbers.split()
sum = 0

for i in range(0,len(list)):
    sum += int(list[i])
f.close()

f = open('sumnumbers.txt','w')
f.write(str(sum))
f.close()