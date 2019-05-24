using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectingTriangles
{
    class Program
    {
        public static bool VerticalLines(Triangle t1, Triangle t2)
        {

            if (t1.IsABVertical() && t2.IsABVertical()) // ако и двете страни АВ на триъгълника са вертикални
            {
                if (t1.aX == t2.aX)
                {
                    if (t1.aY == t2.aY && t1.bY == t2.bY)
                    {
                        return true;
                    }
                }
            }
            //ако само едната е (другата не е), то те се пресичат
            if (t1.IsABVertical())
            {
                return true;
            }
            if (t2.IsABVertical())
            {
                return true;
            }

            //проверка AB и BC 
            if (t1.IsABVertical() && t2.IsBCVertical())
            {
                if (t1.aX == t2.bX)
                {
                    if (t1.aY == t2.bY && t1.bY == t2.cY)
                    {
                        return true;
                    }
                }
            }
            if (t2.IsBCVertical())
            {
                return true;
            }

            //проверка AB и AC 
            if (t1.IsABVertical() && t2.IsACVertical())
            {
                if (t1.aX == t2.aX)
                {
                    if (t1.aY == t2.aY && t1.bY == t2.cY)
                    {
                        return true;
                    }
                }
            }
            if (t2.IsACVertical())
            {
                return true;
            }

            //и сега същите процедури за BC и AC (сверявайки ги за вертикалност с другите страни)
            if (t1.IsBCVertical() && t2.IsABVertical())
            {
                if (t1.bX == t2.aX)
                {
                    if (t1.bY == t2.aY && t1.cY == t2.bY)
                    {
                        return true;
                    }
                }
            }
            if (t1.IsBCVertical())
            {
                return true;
            }

            if (t1.IsBCVertical() && t2.IsBCVertical())
            {
                if (t1.bX == t2.bX)
                {
                    if (t1.bY == t2.bY && t1.cY == t2.cY)
                    {
                        return true;
                    }
                }
            }

            if (t1.IsBCVertical() && t2.IsACVertical())
            {
                if (t1.bX == t2.aX)
                {
                    if (t1.bY == t2.aY && t1.bY == t2.cY)
                    {
                        return true;
                    }
                }
            }

            if (t1.IsACVertical() && t2.IsABVertical())
            {
                if (t1.aX != t2.aX)
                {
                    if (t1.aY == t2.aY && t1.cY == t2.bY)
                    {
                        return true;
                    }
                }
            }
            if (t1.IsACVertical())
            {
                return true;
            }

            if (t1.IsACVertical() && t2.IsBCVertical())
            {
                if (t1.aX == t2.bX)
                {
                    if (t1.aY == t2.bY && t1.cY == t2.bY)
                    {
                        return true;
                    }
                }
            }
            if (t1.IsACVertical() && t2.IsACVertical())
            {
                if (t1.aX == t2.aX)
                {
                    if (t1.aY == t2.aY && t1.cY == t2.cY)
                    {
                        return true;
                    }

                }
            }

            return false; // ако след нито една проверка не е стигнало до true, връщаме false
        }

        public static bool ParallelLines(Triangle t1, Triangle t2)
        {

            //проверка за успоредни линии

            //използваме уравненията на страна 
            t1.CalculateConsts();
            t2.CalculateConsts();

            if (t1.AB_a == t2.AB_a)
            {
                if (t1.AB_b == t1.AB_b)
                {
                    if (t1.aX == t2.aX && t1.bX == t2.bX)
                    {
                        return true;
                    }
                }
            }

            if (t1.AB_a == t2.BC_a)
            {
                if (t1.AB_b == t1.BC_b)
                {
                    if (t1.aX == t2.bX && t1.bX == t2.cX)
                    {
                        return true;
                    }
                }
            }

            if (t1.AB_a == t2.AC_a)
            {
                if (t1.AB_b == t1.AC_b)
                {
                    if (t1.aX == t2.aX && t1.bX == t2.cX)
                    {
                        return true;
                    }
                }
            }

            if (t1.BC_a == t2.AB_a)
            {
                if (t1.BC_b == t1.AB_b)
                {
                    if (t1.bX == t2.aX && t1.cX == t2.bX)
                    {
                        return true;
                    }
                }
            }

            if (t1.BC_a == t2.BC_a)
            {
                if (t1.BC_b == t1.BC_b)
                {
                    if (t1.bX == t2.bX && t1.cX == t2.cX)
                    {
                        return true;
                    }
                }
            }

            if (t1.BC_a == t2.AC_a)
            {
                if (t1.BC_b == t1.AC_b)
                {
                    if (t1.bX == t2.aX && t1.cX == t2.cX)
                    {
                        return true;
                    }
                }
            }

            if (t1.AC_a == t2.AB_a)
            {
                if (t1.AC_b == t1.AB_b)
                {
                    if (t1.aX == t2.aX && t1.cX == t2.bX)
                    {
                        return true;
                    }
                }
            }

            if (t1.AC_a == t2.BC_a)
            {
                if (t1.AC_b == t1.BC_b)
                {
                    if (t1.aX == t2.bX && t1.cX == t2.cX)
                    {
                        return true;
                    }
                }
            }

            if (t1.AC_a == t2.AC_a)
            {
                if (t1.AC_b == t1.AC_b)
                {
                    if (t1.aX == t2.aX && t1.aX == t2.cX)
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        public static bool LinesIntersect(Triangle t1, Triangle t2)
        {
            if (VerticalLines(t1, t2))
            {
                return true;
            }

            if (ParallelLines(t1, t2))
            {
                return true;
            }
            else
            {

                //пресичане между AB и AB
                double x1 = -(t1.AB_b - t2.AB_b) / (t1.AB_a - t2.AB_a);
                if (Math.Min(t1.aX, t1.bX) < x1 && Math.Max(t1.aX, t1.bX) > x1 && Math.Min(t2.aX, t2.bX) < x1 && Math.Max(t2.aX, t2.bX) > x1)
                {
                    return true;
                }

                //пресичане между AB и BC
                double x2 = -(t1.AB_b - t2.BC_b) / (t1.AB_a - t2.BC_a);
                if (Math.Min(t1.aX, t1.bX) < x2 && Math.Max(t1.aX, t1.bX) > x2 && Math.Min(t2.bX, t2.cX) < x2 && Math.Max(t2.bX, t2.cX) > x2)
                {
                    return true;
                }


                //пресичане между AB и AC
                double x3 = -(t1.AB_b - t2.AC_b) / (t1.AB_a - t2.AC_a);
                if (Math.Min(t1.aX, t1.bX) < x3 && Math.Max(t1.aX, t1.bX) > x3 && Math.Min(t2.aX, t2.cX) < x3 && Math.Max(t2.aX, t2.cX) > x3)
                {
                    return true;
                }

                //пресичане между BC и AB
                double x4 = -(t1.BC_b - t2.AB_b) / (t1.BC_a - t2.AB_a);
                if (Math.Min(t1.bX, t1.cX) < x4 && Math.Max(t1.bX, t1.cX) > x4 && Math.Min(t2.aX, t2.bX) < x4 && Math.Max(t2.aX, t2.bX) > x4)
                {
                    return true;
                }

                //пресичане между BC и BC
                double x5 = -(t1.BC_b - t2.BC_b) / (t1.BC_a - t2.BC_a);
                if (Math.Min(t1.bX, t1.cX) < x5 && Math.Max(t1.bX, t1.cX) > x5 && Math.Min(t2.bX, t2.cX) < x5 && Math.Max(t2.bX, t2.cX) > x5)
                {
                    return true;
                }


                //пресичане между BC и AC
                double x6 = -(t1.BC_b - t2.AC_b) / (t1.BC_a - t2.AC_a);
                if (Math.Min(t1.bX, t1.cX) < x6 && Math.Max(t1.bX, t1.cX) > x6 && Math.Min(t2.aX, t2.cX) < x6 && Math.Max(t2.aX, t2.cX) > x6)
                {
                    return true;
                }

                //пресичане между AC и AB
                double x7 = -(t1.AC_b - t2.AB_b) / (t1.AC_a - t2.AB_a);
                if (Math.Min(t1.aX, t1.cX) < x7 && Math.Max(t1.aX, t1.cX) > x7 && Math.Min(t2.aX, t2.bX) < x7 && Math.Max(t2.aX, t2.bX) > x7)
                {
                    return true;
                }

                //пресичане между AC и BC
                double x8 = -(t1.AC_b - t2.BC_b) / (t1.AC_a - t2.BC_a);
                if (Math.Min(t1.aX, t1.cX) < x8 && Math.Max(t1.aX, t1.cX) > x8 && Math.Min(t2.bX, t2.cX) < x8 && Math.Max(t2.bX, t2.cX) > x8)
                {
                    return true;
                }


                //пресичане между AC и AC
                double x9 = -(t1.AC_b - t2.AC_b) / (t1.AC_a - t2.AC_a);
                if (Math.Min(t1.aX, t1.cX) < x9 && Math.Max(t1.aX, t1.cX) > x9 && Math.Min(t2.aX, t2.cX) < x9 && Math.Max(t2.aX, t2.cX) > x9)
                {
                    return true;
                }
            }
            return false;
        }

        public static void TrianglesIntersect(List<Triangle> list)
        {

            List<int> intersect = new List<int>();
            Console.WriteLine("Intersecting triangles: ");
            for (int i = 1; i < list.Count; i++)
            {               
                if (LinesIntersect(list.ElementAt(i), list.ElementAt(i - 1)))
                {    
                    Console.WriteLine("{0}, {1}", i, i + 1);
                    intersect.Add(i);
                    intersect.Add(i + 1);
                }
            }
            if (intersect.Count == 0) Console.WriteLine("No intersecting triangles.");
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Enter how many triangles you want to have.");
            int numberOfTriangles = int.Parse(Console.ReadLine());
            List<Triangle> triangles = new List<Triangle>(numberOfTriangles);
            int br = numberOfTriangles;

            Console.WriteLine("Now enter their coordinates (for Ax, Ay, Bx, By, Cx, Cy): ");
            do
            {
                string[] input = null; 
                input = Console.ReadLine().Split(' ');
                triangles.Add(new Triangle(input));
                br--;   
            }
            while (br != 0);

            Console.WriteLine("You have entered {0} triangles with coordinates: ", numberOfTriangles);
            foreach (var t in triangles)
            {

                t.Print();
            }

            TrianglesIntersect(triangles);
            Console.ReadKey();
        }
    }
}
