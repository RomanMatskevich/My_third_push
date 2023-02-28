using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMD3
{
    class Program
    {
        public static int Fackt(int m)
        {
            if (m == 0)
            {
                return 1;
            }
            else
            {
                return m * Fackt(m - 1);
            }
        }

        public static int Mult(int[] a)
        {
            int res = 1;
            for (int i = 0; i < a.Length; i++)
            {
                res = res * Fackt(a[i]);
            }
            return res;
        }
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.Write("Введіть n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введіть k: ");
            int k = int.Parse(Console.ReadLine());
            int q;
            int Res;
            int e = n - k;
            do
            {
                Console.WriteLine("1.Розміщення без повторень");
                Console.WriteLine("2.Розміщення з повторенням");
                Console.WriteLine("3.Сполучення без повторень");
                Console.WriteLine("4.Сполучення з повторенням");
                Console.WriteLine("5.Перестановки звичайні");
                Console.WriteLine("6.Перестановки з повторенням елементів");
                Console.WriteLine("0.Вихід з програми");
                Console.Write("-> ");
                q = int.Parse(Console.ReadLine());
                switch (q)
                {
                    case 1:
                        Res = Fackt(n) / Fackt(e);
                        Console.WriteLine($"Відповідь: {Res}");
                        break;
                    case 2:
                        double res;
                        res = Math.Pow(n, k);
                        Console.WriteLine($"Відповідь: {res}");
                        break;
                    case 3:
                        Res = Fackt(n) / Fackt(k) * Fackt(n - k);
                        Console.WriteLine($"Відповідь: {Res}");
                        break;
                    case 4:
                        int sum = n + k - 1;
                        int fackt = Fackt(k) * Fackt(sum - k);
                        Res = Fackt(sum) / fackt;
                        Console.WriteLine($"Відповідь: {Res}");
                        break;
                    case 5:
                        Res = Fackt(n);
                        Console.WriteLine($"Відповідь: {Res}");
                        break;
                    case 6:
                        Console.Write("Введіть кількість елементів ->");
                        int l = int.Parse(Console.ReadLine());
                        int[] a = new int[l];
                        for (int i = 0; i < a.Length; i++)
                        {
                            Console.Write($"N{i + 1}=>");
                            a[i] = int.Parse(Console.ReadLine());
                        }
                        Res = Fackt(n) / Mult(a);
                        Console.WriteLine($"Відповідь: {Res}");
                        break;
                    default:
                        Console.WriteLine("Виберіть дію преставлену з переліку можливих!");
                        break;
                }

            } while (q != 0);

        }
    }
}

