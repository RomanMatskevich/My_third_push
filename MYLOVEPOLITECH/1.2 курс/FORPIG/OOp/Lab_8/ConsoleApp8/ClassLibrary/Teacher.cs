using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Teacher:Student
    {
        protected string Position;
        public string position
        { 
            set { Position = value; }
            get { return Position; }
        }
        protected string Chair;
        public string chair
        {
            set { Chair = value; }
            get { return Chair; }
        }
        protected string VNZTeach;
        public string vnzteach
        {
            set { VNZTeach = value; }
            get { return VNZTeach; }
        }
        public void teackkonst(string position,string chair,string vnzteach)
        {
            Position = position;
            Chair = chair;
            VNZTeach = vnzteach;
        }
        public void teackkonst1(string position, string chair)
        {
            Position = position;
            Chair = chair;
        }
        public Teacher()
        {
            Position = "Dekan";
            Chair = "Math";
            VNZTeach = "ZTU";
        }
        public Teacher(Teacher prev)
        {
            Position = prev.Position;
            Chair = prev.Chair;
            VNZTeach = prev.VNZTeach;
        }
        public override void ShowInfo()
        {
            //base.ShowInfo();
            Console.WriteLine($" Ім'я {Name}\nПрізвище {Surname}\nДата народження {Date}\nОцінка ЗНО {MarkZNO}\nОцінка в школі {MarkCertificate}\nНазва школи {SchoolName}\nНомер курсу {Course}\nНомер групи" +
               $" {Group}\nФакультет {Faculty}\nВНЗ {VNZ}\nПосада вчителя {Position}\nКафедра {Chair}\nУніверситет {VNZTeach} ");
        }

    }
}
