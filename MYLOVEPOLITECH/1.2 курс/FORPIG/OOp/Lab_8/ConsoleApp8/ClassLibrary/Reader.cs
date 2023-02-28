using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Reader : Teacher
    {
        protected int TicketNumber;
        public int ticketnumber
        {
            set { TicketNumber = value; }
            get { return TicketNumber; }
        }
        protected int DateTicket;
        public int dateticket
        { 
            set { DateTicket = value; }
            get { return DateTicket; }
        }
        protected int Cost;
        public int cost
        {
            set { Cost = value; }
            get { return Cost; }
        }
        public Reader()
        {
            TicketNumber = 12;
            DateTicket = 23032001;
            Cost = 100;
        }
        public void reader(int a, int b, int c)
        {
            TicketNumber = a;
            DateTicket = b;
            Cost = c;
        }
        public Reader(int number, int date, int cost)
        {
            TicketNumber = number;
            DateTicket = date;
            Cost = cost;
        }
        public Reader(Reader prev)
        {
            TicketNumber = prev.TicketNumber;
            Cost = prev.Cost;
            DateTicket = prev.DateTicket;

        }
        public override void ShowInfo()
        {
            //base.ShowInfo();
            Console.WriteLine($" Ім'я {Name}\nПрізвище {Surname}\nДата народження {Date}\nОцінка ЗНО {MarkZNO}\nОцінка в школі {MarkCertificate}\nНазва школи {SchoolName}\nНомер курсу {Course}\nНомер групи" +
               $" {Group}\nФакультет {Faculty}\nВНЗ {VNZ}\nПосада вчителя {Position}\nКафедра {Chair}\nУніверситет {VNZTeach}\nНомер читацького квитка{TicketNumber}\nДата видачі{DateTicket}\nЩомісячний платіж {Cost}");

        
        }
    }
}
