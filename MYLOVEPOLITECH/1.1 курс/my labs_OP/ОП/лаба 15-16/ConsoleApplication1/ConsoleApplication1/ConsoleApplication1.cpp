// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <Windows.h>
#include <stdio.h>
int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	signed char a, b, res, dil = 0, per = 0, res_asm;
	printf("a[-128; 127] = "); scanf_s("%hhi", &a);
	printf("b[-128; 127] = "); scanf_s("%hhi", &b);

	if (a > b) {

		if (a == 0) {
			printf("Error:");
		}
		else {
			res = (a*b-1);
		}

	}
	else if (a == b) {
		res = 255;
	}
	else if (a < b) {

		if (b == 0) {
			printf("Error:");
		}
		else {
			res = (a -5) / b;
		}
	}

	__asm {
		mov al, a;
		mov bl, b;
		cmp al, bl;
		jg mark1;//a>b
		je mark2;//a = b
		jl mark3;//a<b


	mark1://a>b
		cmp al, 0;
		je error1;

		imul bl;

	}


	if (dil > 0) {
		printf("Ділення на 0!\n");
	}
	else if (per > 0) {
		printf("Переповнення!\n");
	}
	else if (dil == 0 && per == 0) {
		printf("res = %hhi,\nres_asm = %hhi\n", res, res_asm);
	}

	system("pause");
	return 0;
}




