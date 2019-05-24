using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectingTriangles
{
    class Triangle
    {   //координати
        public int aX { get; set; }
        public int aY { get; set; }
        public int bX { get; set; }
        public int bY { get; set; }
        public int cX { get; set; }
        public int cY { get; set; }

        public Triangle(string[] s)
        {
            this.aX = Int32.Parse(s[0]);
            this.aY = Int32.Parse(s[1]);
            this.bX = Int32.Parse(s[2]);
            this.bY = Int32.Parse(s[3]);
            this.cX = Int32.Parse(s[4]);
            this.cY = Int32.Parse(s[5]);
        }

        //уравнение на права
        public double AB_a { get; set; }
        public double AB_b { get; set; }
        public double BC_a { get; set; }
        public double BC_b { get; set; }
        public double AC_a { get; set; }
        public double AC_b { get; set; }

        //проверка дали някоя от страните е вертикална
        public bool IsABVertical()
        {
            if (aX == bX) return true;
            else return false;
        }

        public bool IsBCVertical()
        {
            if (bX == cX) return true;
            else return false;
        }

        public bool IsACVertical()
        {
            if (aX == cX) return true;
            else return false;
        }

        //изчисляване ако няма вертикална страна
        public void CalculateConsts()
        {
            AB_a = (bY - aY) / (bX - aX);
            AB_b = aY - (AB_a * aX);

            BC_a = (cY - bY) / (cX - bX);
            BC_b = bY - (BC_b * bX);

            AC_a = (cY - aY) / (cX - aX);
            AC_b = aY - (AC_b * aX);

        }

        //просто принт метод
        public void Print()
        {
            Console.WriteLine("A ({0} , {1})  B ({2} , {3})  C ({4} , {5})"
                                , aX, aY, bX, bY, cX, cY);
        }

    }
}
