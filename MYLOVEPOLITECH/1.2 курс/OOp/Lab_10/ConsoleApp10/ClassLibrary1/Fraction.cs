using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    public class Fraction
    {

        public int chis;
        public int znam;
        public Fraction()
        {
            chis = 1;
            znam = 2;
        }
        public static int nsk(int a, int b)
        {
            int a1 = a; int b1 = b;
            while (a != 0 && b != 0)
                if (a > b)
                    a = a % b;
                else b = b % a;
            int ret = a + b;
            return (a1 * b1) / ret;
        }
        public static int GCD(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else
            {
                var min = Math.Min(a, b);
                var max = Math.Max(a, b);
                return GCD(max - min, min);
            }
        }
        public Fraction(int a, int b)
        {
            chis = a;
            znam = b;
        }

        public static Fraction operator ++(Fraction a)
        {
            a.chis += a.znam;

            return a;
        }
        public static Fraction operator --(Fraction a)
        {
            a.chis -= a.znam;

            return a;
        }
       
        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction c3 = new Fraction(0, 0);
            int al = nsk(a.znam, b.znam);
            int tmp;
            tmp = al / a.znam;
            a.znam *= tmp;
            a.chis *= tmp;
            tmp = al / b.znam;
            b.znam *= tmp;
            b.chis *= tmp;
            c3.chis = a.chis + b.chis;
            c3.znam = b.znam;
            c3 = ToLow(c3);
            return c3;
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction c3 = new Fraction(0,0);
            int al = nsk(a.znam,b.znam);
            int tmp;
            tmp = al / a.znam;
            a.znam *= tmp;
            a.chis *= tmp;
            tmp = al / b.znam;
            b.znam *= tmp;
            b.chis *= tmp;
            c3.chis = a.chis - b.chis;
            c3.znam = b.znam;
            c3 = ToLow(c3);
            return c3;
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction c3 = new Fraction(0, 0);

            c3.chis = a.chis * b.chis;
            c3.znam = a.znam * b.znam;
            c3 = ToLow(c3);
            return c3;
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction c3 = new Fraction(0, 0);

            c3.chis = a.chis / b.chis;
            c3.znam = a.znam / b.znam;

            return c3;
        }
        public static bool operator >(Fraction a, Fraction b)
        {
            if (a.chis * b.znam > b.chis * a.znam)
                return true;
            else
                return false;

        }

        public static bool operator <(Fraction a, Fraction b)
        {
            if (a.chis * b.znam < b.chis * a.znam)
                return true;
            else
                return false;
        }
        public static bool operator >=(Fraction a, Fraction b)
        {
            if (a.chis * b.znam >= b.chis * a.znam)
                return true;
            else
                return false;

        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            if (a.chis * b.znam <= b.chis * a.znam)
                return true;
            else
                return false;
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            if (a.chis==b.chis&&a.znam==b.znam)
                return true;
            else
                return false;
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            if (a.chis != b.chis && a.znam != b.znam)
                return true;
            else
                return false;
        }
        public static explicit operator double(Fraction a)
        {
          
                return a.chis*1.0d/a.znam;
        }
        public static Fraction ToLow(Fraction a)
        {
            int b = GCD(a.znam, a.chis);
            a.znam /= b;
            a.chis /= b;
            return a;
        }
        public override string ToString()
        {
            return $"{chis}/{znam}";
        }


    }
}
