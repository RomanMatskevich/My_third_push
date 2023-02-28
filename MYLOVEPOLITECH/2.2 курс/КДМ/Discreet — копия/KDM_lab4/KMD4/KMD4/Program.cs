using System;
using System.Collections.Generic;
using System.Text;


namespace KMD4
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            int n, m;
            Console.Write("Введіть кількість вершин:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------------");
            Console.Write("Введіть кількість ребер:");
            m = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------------");
            int[,] matrix = new int[n, n];
            Console.WriteLine("Введення здійснюйте в форматі: 1 вершина,2 верши-на,вага.");
            for (int i = 1; i <= m; i++)
            {
                Console.Write($"Введіть вершини {i} ребра та його вагу: ");
                string[] vrt = Console.ReadLine().Split(',');
                int a = int.Parse(vrt[0]);
                int b = int.Parse(vrt[1]);
                matrix[a - 1, b - 1] = int.Parse(vrt[2]);
                matrix[b - 1, a - 1] = int.Parse(vrt[2]);
            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Матриця суміжності графа:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------");
            PrimMethod(matrix, n);
            void PrimMethod(int[,] mtrx, int n_count)
            {
                List<int> vrt_2 = new List<int>();
                bool[] used = new bool[n_count];
                for (int i = 0; i < used.Length; i++)
                    used[i] = false;
                used[0] = true;
                int sum = 0;
                int existVertex = 0, newVertex = 0;
                for (int k = 0; k < mtrx.GetLength(0) - 1; k++)
                {
                    int min = int.MaxValue;
                    for (int i = 0; i < mtrx.GetLength(0); i++)
                    {
                        if (!used[i])
                            continue;
                        for (int j = 0; j < mtrx.GetLength(1); j++)
                        {
                            if (mtrx[i, j] != 0 && !used[j])
                                vrt_2.Add(j);
                        }
                        for (int j = 0; j < vrt_2.Count; j++)
                        {
                            if (mtrx[i, vrt_2[j]] < min)
                            {
                                min = mtrx[i, vrt_2[j]];
                                existVertex = i;
                                newVertex = vrt_2[j];
                            }
                        }
                        vrt_2.Clear();
                    }
                    used[newVertex] = true;
                    sum += min;
                    Console.WriteLine($"{k + 1}. ({existVertex + 1},{newVertex + 1})");
                }
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Мінімальне остове дерево (за методом Прима) = {sum}");
            }
            Console.ReadKey();
        }
    }
}
