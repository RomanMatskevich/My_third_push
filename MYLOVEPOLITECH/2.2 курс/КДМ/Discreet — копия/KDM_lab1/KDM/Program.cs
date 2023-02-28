using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace KDM
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo customCulture =
      (System.Globalization.CultureInfo)
      System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;


            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            int n = 0, m = 0;
            do
            {
                WriteLine("Введіть потужність першої та другої множин:");
                Write("|A|=");
                n = Convert.ToInt32(ReadLine());
                Write("|B|=");
                m = Convert.ToInt32(ReadLine());
                WriteLine("Заповніть множини елементами:");

                int[] A = new int[n];
                int[] B = new int[m];
                for (int i = 0; i < n; i++)
                {
                    Write("A[i]=");
                    A[i] = Convert.ToInt32(ReadLine());
                }


                WriteLine("");
                for (int i = 0; i < m; i++)
                {
                    Write("B[i]=");
                    B[i] = Convert.ToInt32(ReadLine());
                }

                WriteLine();
                Array.Sort(A);
                Array.Sort(B);

                WriteLine("Результатом об'єднання множин А та В є множина С, елементи якої:");

                int j = 0;
                int[] C = new int[n + m];
                for (int i = 0; i < n + m; i++)
                {
                    if (i < n)
                    {
                        C[i] = A[i];

                    }
                    if (i < n + m && i >= n)
                    {
                        C[i] = B[j];
                        j++;
                    }
                }
                int s = n + m;
                Array.Sort(C);
                for (int i = 0; i < (n + m) - 1; i++)
                {
                    if (C[i] != C[i + 1])
                    {
                        Write($"{C[i]},");
                    }
                }
                WriteLine($"{C[s - 1]}");
                WriteLine("");

                WriteLine("Результатом перетину множин А та В є множина С, елементи якої:");
                for (int i = 0; i < (n + m) - 1; i++)
                {
                    if (C[i] == C[i + 1])
                    {
                        Write($"{C[i]} ");
                    }
                }
                WriteLine("");

                WriteLine("Результатом різниці множин А та В є множина С, елементи якої:");
                int count;
                for (int i = 0; i < n; i++)
                {
                    count = 0;
                    for (int k = 0; k < m; k++)
                    {
                        if (A[i] == B[k]) count++;
                    }
                    if (count == 0) Write($"{A[i]} ");
                }

                WriteLine("");

                WriteLine("Результатом симетричної різниці множин А та В є множина С, елементи якої:");
                Array.Sort(C);
                for (int i = 0; i < (n + m) - 2; i++)
                {
                    if (C[i] != C[i + 1] && C[i + 1] != C[i + 2])
                    {
                        Write($"{C[i + 1]} ");
                    }
                }
                WriteLine($"{C[s - 1]}");
            } while (m != 0);
        }

    }
}
