﻿// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <stdio.h>
#include <windows.h>
#include <math.h>

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int a;
	printf("оберіть тип обрахунку \n1--(1/x^1/3)\n2--((e^x^2)/2)\n"); scanf_s("%d", &a);
	switch (a)
	{

	case 1:

		double result;
		for (int x = 5; x <= 7; x++)
		{
			result = 1 / (cbrt(x));
			printf("x=%d\n", x);
			printf("result=%f\n", result);
		}
		break;
	case 2:
		int f;
		double resulta;
		for (float x = 2; x <= 3;)
		{
			f = pow(x, 2);
			resulta = (exp(f)) / 2;
			printf("x=%f\n", x);
			printf("result=%f\n", resulta);
			x = x + 0.1;
		}
		break;
	default:
		printf("обрано некоректний варіант");
	}
	return 0;
}


// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
