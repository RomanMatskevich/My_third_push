// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//
#include <iostream>
#include <windows.h>

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	const int n = 4, m = 4;
	int mass[n][m];
	for(int i=0;i<n;i++)
		for (int j = 0; j < m; j++)
		{
			mass[i][j] = 1 + rand() % (9);
			printf("%4d", mass[i][j]);
		}
	printf("\n");
}

