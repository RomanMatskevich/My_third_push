using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Student : Entrant
    {
        protected int Course;
        public int course
        {
            set { Course = value; }
            get { return Course; }
        }
        protected string Group;
        public string group
        {
            set { Group = value; }
            get { return Group; }
        }
        protected string Faculty;
        public string faculty
        {
            set { Faculty = value; }
            get { return Faculty; }
        }
        protected string VNZ;
        public string vnz
        {

            set { VNZ = value; }
            get { return VNZ; }
        }
        public void studentkonst(int course,string group,string faculty,string vnz)
       {
            Course = course;
            Group = group;
            Faculty = faculty;
            VNZ = vnz;
        }
        public void studentkonst1(int course, string group)
        {
            Course = course;
            Group = group;
        }
        public Student()
        {
            Course = 1;
            Group = "IPZ202";
            Faculty = "FIKT";
            VNZ = "ZTU";
        }
        public Student(Student prev)
        {
            Course = prev.Course;
            Group = prev.Group;
            Faculty = prev.Faculty;
            VNZ = prev.VNZ;
        }
        public override void ShowInfo()
        {
            //base.ShowInfo();
            Console.WriteLine($" Ім'я {Name}\nПрізвище {Surname}\nДата народження {Date}\nОцінка ЗНО {MarkZNO}\nОцінка в школі {MarkCertificate}\nНазва школи {SchoolName}\nНомер курсу {Course}\nНомер групи" +
                $" {Group}\nФакультет {Faculty}\nVNZ {VNZ}");
        }

    }
}
