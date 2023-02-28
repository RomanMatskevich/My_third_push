using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HelloApp
{
  
     public struct Product
    {
        public string Name;
        public int Cost;
        public int Quantity;
        public string Producer;
        public int Weight;
       public struct Currency
        {
            public string name;
            public double ExRate;
            public Currency(string Name, double exrate)
            {
                name = Name;
                ExRate = exrate;
                
            }
        }

        public Product(string name, int cost, int quantity, string producer, int weight)
        {
            this.Name = name;
            this.Cost = cost;
            this.Quantity = quantity;
            this.Producer = producer;
            this.Weight = weight;
         }
     
        public string GetPriceInUAH(Product[]b,string names)
        {
            double a = 0;
            
            Currency quantity;
            quantity.ExRate = 27.5;
            quantity.name = "грн";
            for (int i = 0; i < b.Length; i++)
                if (b[i].Name == names)
                    a = quantity.ExRate * b[i].Cost;
            string c = a.ToString() + quantity.name;
            return c ;
        }
        public int GetTotalPriceInUAH(Product[]prod,string name)
        {
           
            int summary=0;
            for (int i = 0; i < prod.Length; i++)
            {
                if (prod[i].Name == name)
                    summary = prod[i].Cost * prod[i].Quantity;
            }
            return summary ;
        }
        public int GetTotalWeight(Product[]prod,string name)
        {
            int summary = 0;
            for (int i = 0; i < prod.Length; i++)
            {
                if (prod[i].Name == name)
                    summary = prod[i].Weight * prod[i].Quantity;
            }
            return summary;
        }  
    }
    
    class Program
    {
        public static void ReadProductsArray( int a)
        {
            bool ok;
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine($"Продукт номер {i + 1}");
                Console.Write("Назва:"); prod[i].Name = Console.ReadLine();
                do
                {
                    Console.Write("Ціна:");
                    ok = int.TryParse(Console.ReadLine(), out prod[i].Cost);
                    if (!ok)
                        Console.Write("  Помилка введення значення. Будь-ласка повторіть введення значення ще раз!");

                } while (!ok);
                do
                {
                    Console.Write("Кількість:");
                    ok = int.TryParse(Console.ReadLine(), out prod[i].Quantity);
                    if (!ok)
                        Console.Write("  Помилка введення значення Кількості. Будь-ласка повторіть введення значення ще раз!");

                } while (!ok);
                Console.Write("Виробник:"); prod[i].Producer = Console.ReadLine();
                do
                {
                    Console.Write("Вага:");
                    ok = int.TryParse(Console.ReadLine(), out prod[i].Weight);
                    if (!ok)
                        Console.Write("  Помилка введення значення ваги. Будь-ласка повторіть введення значення ще раз!");

                } while (!ok);
               
            
            }
            
        }
        static void PrintProduct()
        {
           
            Console.WriteLine($"{product.Cost}{product.Name}{product.Producer}{product.Quantity}{product.Weight}");
        }
        static void PrintProducts(int a)
        {
            
            for (int i=0;i<a;i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Продукт {prod[i].Name} ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Ціна {prod[i].Cost}\nВиробник {prod[i].Producer}\nКількість {prod[i].Quantity}\nВага{prod[i].Weight}\n");
              
            }

        }
        static  void GetProductsInfo(Product[]prod,out string expensive,out string cheap )
        {
            int sm1 = int.MaxValue, ex1 = int.MinValue;
            string sm = "", ex = "";

            for (int i = 0; i < prod.Length; i++)
            {
                if (prod[i].Cost < sm1)
                {
                    sm1 = prod[i].Cost;
                    sm = prod[i].Name;
                 
                }
                if (prod[i].Cost > ex1)
                {
                    ex1 = prod[i].Cost;
                    ex = prod[i].Name;
                }
            }
            expensive = ex;
            cheap = sm;
        }
        public static int sortproductsbyprice(Product a, Product b)
        {
            double avgA = a.Cost, avgB = b.Cost;
            if (avgA > avgB)
                return 1;
            if (avgA < avgB)
                return -1;
            return 0;
        }
        public static int sortproductsbycount(Product a, Product b)
        {
            int avgA = a.Quantity, avgB = b.Quantity;
            if (avgA > avgB)
                return 1;
            if (avgA < avgB)
                return -1;
            return 0;
        }
        static void SortProductsByPrice(Product[]prod)
        {
            Array.Sort(prod,sortproductsbyprice);
        }
        
        static void SortProductsByCount(Product[] prod)
        {
            Array.Sort(prod,sortproductsbycount);
        }
        public static Product product = new Product();
        

        public static Product[] prod;

        static void Main(string[] args)
        {
            Console.Title = "Лабораторна робота №5";
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
                    System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.Write("Введіть Кількість продуктів =");
            bool ok;
            int a;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out a);
                if (!ok)
                    Console.Write("  Помилка введення значення . Будь-ласка повторіть введення значення ще раз!");

            } while (!ok);
            product.Cost = 100;
            product.Weight = 100;
            product.Name = "names";
            product.Quantity = 50;
            product.Producer = "rud";
            prod = new Product[a];

            Console.WriteLine("Заповніть будь ласка Характеристики товарів:");
            ReadProductsArray(a);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("Меню"); 
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("1(Загальна ціна товарів певного виду)\t 2(Загальна вага продуктів певного виду)\t 3(Вивести всі товари на екран)\t 4(найдорожчий та найдешевший товар)\t 5(сортування за ціною) \t 6(Сортування за вагою)\t7(Ціна товару в гривнях) \t 8(Вивести інформацію про одиночний товар)\t 0(вихід)\n");
            int menu;
            string sm, bg,nume;
            do
            {
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        {
                            Console.WriteLine($"Введіть будь-ласка ім'я товару");nume = Console.ReadLine();
                            Console.WriteLine($"Загальна ціна продуктів:{product.GetTotalPriceInUAH(prod,nume)}");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"Введіть будь-ласка ім'я товару"); nume = Console.ReadLine();
                            Console.WriteLine($"Загальна вага продуктів:{product.GetTotalWeight(prod, nume)}");
                            break;
                        }
                    case 3:
                        {
                            PrintProducts(a);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
                            break;
                            
                        }
                    case 4:
                        {
                            GetProductsInfo(prod, out bg, out sm);
                            Console.WriteLine($"Найдорожчий продукт {bg} Найдешевший продукт {sm}");
                            break;
                        }
                    case 5:
                        {
                            SortProductsByPrice(prod);
                            PrintProducts(a);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
                            break;
                        }
                    case 6:
                        {
                            SortProductsByCount(prod);
                            PrintProducts(a);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Введіть назву товару");nume = Console.ReadLine();
                            Console.WriteLine( $"Ціна данного продукта в гривнях {product.GetPriceInUAH(prod,nume)}");

                            break;
                        }
                    case 8:
                        {
                            PrintProduct();
                             break;
                        }
                }
            } while (menu != 0);

        }
      
    }

}
