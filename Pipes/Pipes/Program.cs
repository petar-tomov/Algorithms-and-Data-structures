using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entry: ");
            double totalLiters = double.Parse(Console.ReadLine());
            double totalElements = int.Parse(Console.ReadLine());

            BinaryTree tree = new BinaryTree();
            tree.Insert(1, totalLiters); 

            for (int i = 1; i < totalElements; i += 2)
            {
                var line = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(Int32.Parse).ToArray();

                var pipeNumber = line[0];
                var currentElement = tree.FindElement(pipeNumber);

                var pipeLeftHeirNumber = line[1];
                var pipeLeftHeirValue = line[2] / 100.0 * currentElement.Value;
                var pipeRightHeirNumber = line[3];
                var pipeRightHeirValue = line[4] / 100.0 * currentElement.Value;

                tree.Insert(pipeLeftHeirNumber, pipeLeftHeirValue);
                tree.Insert(pipeRightHeirNumber, pipeRightHeirValue);
            }

            tree.Separate(tree.Root);

            Console.WriteLine();
            Console.WriteLine("Exit: ");

            foreach (var element in tree.MatchCollection)
            {
                Console.WriteLine("Pipe {0}: {1} litres", element.Number, element.Value);
            }

            Console.ReadKey();
        }
    }
}
