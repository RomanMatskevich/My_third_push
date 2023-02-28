using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2DConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
                                 System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            bool ok;
            int n, min = -123, max = 163, m;
            double[,] matr;
            Console.WriteLine("Введіть розміри масиву");
            Console.Write("n=");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);//рядочки
            } while (!ok);
            Console.Write("m=");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out m);//стовпчики
            } while (!ok);
            matr = new double[n, m];
            Random rnd = new Random();
            int rows = matr.GetUpperBound(0) + 1;
            int columns = matr.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matr[i, j] = rnd.Next(min, max) / 10.0;
                    Console.Write($" {matr[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.Write("\n");
            double[] mas2 = new double[columns];
            double[] suma = { 0, 0 };

            Console.Write("Сумма всіх стовпців");
            for (int i = 0; i < columns; i++)
            {
                mas2[i] = 0;
                for (int j = 0; j < rows; j++)
                    mas2[i] += matr[j, i];
                Console.Write($" {mas2[i]:N1}");
                if (mas2[i] > suma[0])
                {
                    suma[0] = mas2[i];
                    suma[1] = i + 1;
                }
            }
            Console.WriteLine($"\nНайбільша сума елементів у рядку №{suma[1]} {suma[0]:N1}");
            for (int i = 0; i < columns; i++)
            {
                mas2[i] = 0;
                for (int j = 0; j < rows; j++)
                {
                    if (matr[j, i] < 0)
                        mas2[i] += Math.Abs(matr[j, i]);
                }
                
            }
            bool fl;
            double x;
            Console.WriteLine("Відсортований масив");
            do
            {
                fl = false;
                for (int i = 0; i < columns - 1; i++)
                {
                    if (mas2[i] < mas2[i + 1])
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            x = matr[j, i];
                            matr[j, i] = matr[j, i+1];
                            matr[j , i+1] = x;
                            x = mas2[i];
                            mas2[i] = mas2[i + 1];
                            mas2[i + 1] = x;
                            fl = true;
                        }
                    }
                }

            } while (fl);
            Console.WriteLine("");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($" {matr[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
    }
}

