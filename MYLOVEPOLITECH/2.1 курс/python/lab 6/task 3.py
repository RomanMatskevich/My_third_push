text = open("tsk3/learning_python.txt", 'r', encoding="UTF-8").readlines()

text.sort(key = lambda s: len(s))
text.reverse()

for i in range(0,len(text)):
    text[i] = text[i].replace("Python","C")
true_file = open('tsk3/New_catalog/Learn_C.txt','w')
false_file = open('tsk3/New_catalog/hiba.txt','w')

for i in range(0,len(text)):
    print(text[i])
    a = input("Чи підходить данні параметри для мови С?\nВведіть + якщо так,і будь що інше якщо ні \n")
    if a == "+":
        true_file.write(text[i])
    else:
        false_file.write(text[i])



