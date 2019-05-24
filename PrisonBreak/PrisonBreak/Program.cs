using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    class Program
    {
        public static readonly int BOARD_SIZE = 15;
        public static int[,] board;
        private static bool thereIsAWayOut = false;
        private static List<Placement> points = new List<Placement>();
        private static List<Placement> blockingDoors = new List<Placement>();

        private static void BlockDoors(List<Placement> doors, int startX, int startY)
        {
            foreach (var door in doors)
            {
                // изчистване
                thereIsAWayOut = false;
                points.Clear();
                var stack = new Stack<Placement>();

                board[door.X, door.Y] = 1;

                PathFinder(stack, startX, startY);

                if (!points.Any())
                {
                    blockingDoors.Add(new Placement(door.X, door.Y));
                }

                board[door.X, door.Y] = 2;
            }
        }

        private static List<Placement> GetDoorsFromPath() // намираме вратите по 'пътя към свободата' на затворника
        {
            var doors = new List<Placement>();

            foreach (var p in points)
            {
                if (board[p.X, p.Y].Equals(2))
                {
                    doors.Add(new Placement(p.X, p.Y));
                }
            }

            return doors;
        }

        private static void PathFinder(Stack<Placement> stack, int startX, int startY)
        {
            //Връщаме първият изход, който намерим
            if (thereIsAWayOut)
            {
                return;
            }

            stack.Push(new Placement(startX, startY)); // Всяка точка от лабиринта, през която преминаваме я запазваме в стека

            if (IsOnExit(startX, startY))
            {
                points.AddRange(stack.Reverse());
                thereIsAWayOut = true;
            }
            else if (CanContinue(startX, startY))
            {
                var symbol = board[startX, startY]; // инициализирам променлива, с помощта на която ще проследявам откъде е минал затворника
                board[startX, startY] = 21; // стойността й няма значение 
                
                // Движението на затворника
                PathFinder(stack, startX - 1, startY); // нагоре
                PathFinder(stack, startX + 1, startY); // надолу
                PathFinder(stack, startX, startY + 1); // надясно
                PathFinder(stack, startX, startY - 1); // наляво

                board[startX, startY] = symbol;
                stack.Pop();
            }
            else
            {
                stack.Pop();
            }
        }

        private static bool IsOnExit(int startX, int startY) // затворникът успешно е "избягал"
        {
            if (startY.Equals(0) || startX.Equals(0) || startY == BOARD_SIZE - 1 || startX == BOARD_SIZE - 1) // ако местоположението му отговаря на едно от следните
            {
                if (board[startX, startY].Equals(0) || board[startX, startY].Equals(2))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        private static bool CanContinue(int startX, int startY) // Какво става когато затворника попадне на празно място/врата -> продължава напред, като Кобрата (или накъдето може)
        {
            if (board[startX, startY].Equals(0) || board[startX, startY].Equals(2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void printMaze()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Get random board
            board = PrisonBreakTools.getNewMaze(BOARD_SIZE);
            printMaze();

            // Get random staring point
            Random rand = new Random();
            int startX, startY;
            do
            {
                startX = rand.Next(0, BOARD_SIZE);
                startY = rand.Next(0, BOARD_SIZE);
            }
            while (board[startX, startY] != TileTypes.EMPTY || startX == 0 || startY == 0 || startX == BOARD_SIZE - 1 || startY == BOARD_SIZE - 1);

            Console.WriteLine("Start: {0} {1}", startX, startY);

            // Your output goes here

            var stack = new Stack<Placement>();

            PathFinder(stack, startX, startY); // ако има изход, то точките ще се съберат в стека

            if (!points.Any()) // ако няма изход
            {
                Console.WriteLine("No path.");
            }
            else 
            {
                Console.WriteLine("Exit: " + points.Last().ToString()); // изходни координати

                var doors = GetDoorsFromPath(); // взимаме вратите от изходния път

                if (!doors.Any()) // ако няма врати, извеждаме съобщение, че няма
                {
                    Console.WriteLine("No blocking doors.");
                }
                else
                {
                    BlockDoors(doors, startX, startY); // ако има ги извеждаме със стек

                    if (!blockingDoors.Any())
                    {
                        Console.WriteLine("No blocking doors!");
                    }
                    else
                    {
                        Console.WriteLine("Blocking doors: ");
                        Console.WriteLine(string.Join(Environment.NewLine, blockingDoors));
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
