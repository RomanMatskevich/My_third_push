// ConsoleApplication2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <stdio.h>
#include <Windows.h>
int main() {
	 int a, f, c, d, e,b, res, res_asm;
	printf("a = ");
	scanf_s("%hd", &a);
	printf("b = ");
	scanf_s("%hd", &b);
	printf("c = ");
	scanf_s("%hd", &c);
	printf("d = ");
	scanf_s("%hd", &d);
	printf("e = ");
	scanf_s("%hd", &e);
	printf("f = ");
	scanf_s("%hd", &f);
	res = (2 + c - d * 23 - e) / (2 * a * a - 1 - f);
	__asm 
	{
		mov eax, d;
		mov ebx, 23;
		imul ebx;
		neg eax;
		mov ecx, c;
		add eax, 2;
		add eax, ecx;
		sub eax, e;//<al>=(2+c-d*23-e)
		mov ecx, eax;
		cdq;
		mov eax, 2;
		mov ebx, a;
		imul ebx;
		imul ebx;
		sub eax, 1;
		sub eax, f;
		mov ebx, eax;
		mov eax, ecx;
		cdq;
		idiv ebx;

		mov res_asm, eax;
	}
	printf("res = %d, res_asm = %d\n", res, res_asm);
	system("pause");
	return 0;

}


