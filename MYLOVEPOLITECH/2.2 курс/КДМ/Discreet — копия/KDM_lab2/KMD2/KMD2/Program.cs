using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KMD2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.Unicode; 
            Console.InputEncoding = Encoding.Unicode;
            int A;
            int B;
            int[] q;
            int[] w;
            int t;
            int[][] a;
            int k;
            bool flag = true;
            bool checkok; 
            Console.WriteLine("Введіть кількість елементів множини A:");
            do 
            {
                if ((checkok = int.TryParse(Console.ReadLine(), out A)) != true)
                    Console.WriteLine("Помилка, введіть правильне значення");
            }
            while (!checkok); 
            Console.WriteLine("Введіть кількість елементів множини B:");
            do 
            {
                if ((checkok = int.TryParse(Console.ReadLine(), out B)) != true)
                    Console.WriteLine("Помилка, введіть правильне значення");
            }
            while (!checkok); 
            q = new int[A];
            w = new int[B];
            a = new int[A][];
            for (int i = 0; i < A; i++)
            {
                a[i] = new int[B];
            }
            for (int i = 0; i < A; i++)
            {
                for (int j = 0; j < B; j++)
                {
                    a[i][j] = 0;
                }
            }

            Console.WriteLine("Елементи першої множини А:");
            for (int i = 0; i < A; i++)
            {
                do 
                {
                    if ((checkok = int.TryParse(Console.ReadLine(), out t)) != true)
                        Console.WriteLine("Помилка, введіть правильне значення");
                }
                while (!checkok); 
                for (k = 0; k < A; k++)
                {
                    if (t == q[k])
                    {
                        flag = false;
                        Console.Write("Повтор\n");
                        i--;
                    }
                }
                if (flag)
                {
                    q[i] = t;
                }
                flag = true;
            }
            Console.WriteLine("Елементи другої множини В:");
            for (int i = 0; i < B; i++)
            {
                do 
                {
                    if ((checkok = int.TryParse(Console.ReadLine(), out t)) != true)
                        Console.WriteLine("Помилка, введіть правильне значення");
                }
                while (!checkok); 
                for (k = 0; k < B; k++)
                {
                    if (t == w[k])
                    {
                        flag = false;
                        i--;
                    }
                }
                if (flag)
                {
                    w[i] = t;
                }
                flag = true;
            }
            for (int i = 0; i < A; i++)
            {
                for (int j = 0; j < B; j++)
                {
                    if (q[i] %w[j]==0) 
                    {
                        a[i][j] = 1;
                    }
                }
            }
            Console.WriteLine("Побудована матриця має наступний вигляд:");
            for (int i = 0; i < B; i++)
            {
                Console.Write("   ");
                Console.Write(w[i]);
            }
            for (int i = 0; i < A; i++)
            {
                Console.Write("\n");
                Console.Write("\n");
                Console.Write(q[i]);
                Console.Write("   ");
                for (int j = 0; j < B; j++)
                {
                    Console.Write(a[i][j]);
                    Console.Write("   ");
                }
            }
            Console.Write("\n");
            Console.ReadKey();
        }

    }
}
