

#include <Windows.h>
#include <stdio.h>
#include <string.h>


int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    char masiv[100] = "AAA BBBB CCCCC KK M";
    char mas[10];
    char vivod[10];
    int j = 0;
    for (int i = 0; i < 100; i++)
    {
        
        if (masiv[i] != 32)
        {
            mas[j] = masiv[i];
            j++;
        }
        if (sizeof(mas) > sizeof(vivod))
        {
            j = 0;
            for (int k = 0; k < 10; k++)
                vivod[k] = mas[k];
        }
    }
    printf("%s", vivod);
    return 0;
    
}
