using System;

namespace Diamonds
{
    class Program
    {

        static int DiamondsUsed(int n, int combo)
        {
            Console.Write("The number of Diamonds used is: ");
            /*
             при n = 1 броят на парчетата са 3 => 1*3 = 3 <=> броят диаманти по доминото;
             при n = 2 броят на парчетата са 6 => 2*6 = 12 <=> броят диаманти по доминото;
             при n = 3 броят на парчетата са 10 => 3*10 = 30 <=> броят диаманти по доминото;
             при n = 4 броят на парчетата са 15 => 4*15 = 60 <=> броят диаманти по доминото;
             ...
             */
            return n * combo; 
        }

        static void Main(string[] args)
        {
            // Въвеждане
            int n;
            Console.WriteLine("Enter a number between 1 and 1000: ");
            do
            {
                Console.Write("n = ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n < 1 || n > 1000);

            // създаваме на променлива, с която ще намерим броя парчета
            int combo = 0;
            for (int i = 0; i <= n + 1; i++)
            {
                combo += i;
            }


            // извикваме метода
            Console.WriteLine(DiamondsUsed(n, combo));

            Console.ReadKey();
        }
    }
}
