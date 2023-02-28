using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ConsoleApp6
{

   

    class Program
    {
        //метода=============================
      
        public static Student[] ReadStudentsArray()
        {
            int n;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Введіть кількість учнів "); n = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Student[] students;
            students = new Student[n];
            int k;
           
            for (int i = 0; i < students.Length; i++)
            {
                string a, b;
                int c;
                students[i] = new Student();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Введіть ім'я ");
                students[i].name = Console.ReadLine();
                Console.Write("Введіть прізвище ");
                students[i].surname = Console.ReadLine();
                Console.Write("Введіть номер групи ");
                
                students[i].group = int.Parse(Console.ReadLine());
                Console.Write("Введіть номер курсу ");
                students[i].year = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Введіть кількість предметів "); k = int.Parse(Console.ReadLine());
                students[i].results = new Result[k];
                Console.WriteLine("Введіть результати студента");
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < students[i].results.Length; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Предмет "); a = Console.ReadLine();
                    Console.Write("Вчитель "); b = Console.ReadLine();
                    Console.Write("Бал     "); c = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;
                    students[i].results[j] = new Result(a,b,c);
                }
       
                Console.WriteLine("Оберіть валюту (1:UAH)(2:$)(3EUR)");students[i].Currency = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть вартість навчання за місяць");students[i].CostMonth=int.Parse(Console.ReadLine());
                students[i].CostYear = 10 * students[i].CostYear;
                students[i].CostFull = 4 * students[i].CostFull;
            }

            return students;
        }
        public static void PrintStudent(Student a)
        {
            Console.WriteLine($"Ім'я {a.name} Прізвище {a.surname} Номер курсу {a.year} Група {a.group}");

        }
        public static void PrintStudents(Student[] a)
        {

            for (int i = 0; i < a.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Ім'я {a[i].name}");
                Console.WriteLine($"Прізвище {a[i].surname}");
                Console.WriteLine($"Група {a[i].group}");
                Console.WriteLine($"Рік {a[i].year}");

                Console.WriteLine("Оцінки");

                for (int j = 0; j <a[i].results.Length ; j++)
                {
                    
                    Console.WriteLine($"Вчитель {a[i].results[j].teacher}");
                    Console.WriteLine($"Предмет {a[i].results[j].subject}");
                    Console.WriteLine($"Оцінка  {a[i].results[j].points}");
                }
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                string b="eur";
                if (a[i].Currency == 1)
                    b = "грн";
                else
                     if (a[i].Currency == 2)
                    b = "$";
                else
                     if (a[i].Currency == 3)
                    b = "eur";
                Console.WriteLine($"Вартість навчання за місяць: {a[i].CostMonth.ToString() + b}");
                Console.WriteLine($"Вартість навчання за рік   : {a[i].CostYear.ToString() + b}");
                Console.WriteLine($"Вартість за всі курси      : {a[i].CostFull.ToString() + b}");

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void GetStudentsInfo(Student[]a,out double highest,out double lowest)
        {
            double k=int.MinValue, b=int.MaxValue;
            double sb=0;
            for (int i = 0; i < a.Length; i++)
            {
                {
                    for (int j = 0; j < a[i].results.Length; j++)
                        sb += a[i].results[j].points;
                }
                sb /= a[i].results.Length;
                if (sb > k)
                    k = sb;
                if (sb < b)
                    b = sb;
                sb = 0;
            }
            highest = k;
            lowest = b;
        }
        public static int Sortstudentsbypoints(Student a, Student b)
        {
            double avgA = a.GetAveragePoints(), avgB = b.GetAveragePoints();
            if (avgA > avgB)
                return 1;
            if (avgA < avgB)
                return -1;
            return 0;
        }
        public static int Sortstudentsbyname(Student a, Student b)
        {
           
            string avgA = a.name, avgB = b.name;
            if (avgA.CompareTo(avgB) == 0)
            {
               return a.surname.CompareTo(b.surname);

            }
            return avgA.CompareTo(avgB);

        }
        public static void SortStudentsByPoints(Student[]a)
        {
            Array.Sort(a,Sortstudentsbypoints);
        }
        public static void SortStudentsByName(Student[]a)
        {
            Array.Sort(a, Sortstudentsbyname);
        }
        public static void ForMonth() 
        {
        
        }
        //===================================
        public static Student stud = new Student();
        
       

        static void Main(string[] args)
        {
            Console.Title = "Лабораторна робота №6";
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
                    System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Student[] studs = ReadStudentsArray();
            stud.group = 10;
            stud.name = "aaa";
            stud.year = 2010;
            stud.surname = "bbb";
            int menu;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("MENU:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. Вивести інформацію про 1 студента\n2. Вивести інформацію про всіх студентів \n3. Обрахувати середнє арифметичне оцінок студента" +
                "\n4. Дізнатись предмет з найвищим балом \n5. Дізнатись предмет з найгіршим балом \n6. Найвищий та найнижчий середній бал " +
                "\n7. Відсортувати студентів за балами \n8. Відсортувати студентів по алфавіту \n0. Вихід");
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                      {
                            PrintStudent(stud);
                            break;
                       }
                    case 2:
                        {
                            PrintStudents(studs);
                            break;
                        }
                    case 3:
                        {
                            string name;
                            Console.Write("Введіть ім'я студента ");name = Console.ReadLine();
                            for (int i = 0; i < studs.Length; i++)
                                if (name == studs[i].name)
                                    Console.WriteLine($"{studs[i].GetAveragePoints()}");
                                

                            
                            break;

                        }
                    case 4:
                        {
                            string name;
                            Console.Write("Введіть ім'я студента "); name = Console.ReadLine();
                            for (int i = 0; i < studs.Length; i++)
                                if (name == studs[i].name)
                                    Console.WriteLine($"{studs[i].GetBestSubject()}");

                            break;
                        }
                    case 5:
                        {
                            string name;
                            Console.Write("Введіть ім'я студента ");name = Console.ReadLine();
                            for (int i = 0; i < studs.Length; i++)
                                if (name == studs[i].name)
                                    Console.WriteLine($"{studs[i].GetWorstSubject()}");
                            break;
                        }
                    case 6:
                        {
                            double a, b;
                            GetStudentsInfo(studs,out a,out b);
                            Console.WriteLine($"Найнижчий {b} Найвищий {a}");
                            break;
                        }
                    case 7:
                        {
                            SortStudentsByPoints(studs);
                            break;
                        }
                    case 8: {
                            SortStudentsByName(studs);


                            break; }
                        
                }
            } while (menu!=0);
        }
    }
}
