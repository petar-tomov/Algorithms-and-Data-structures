using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes
{
    class BinaryTreeElement
    {
        public int Number { get; set; }
        public double Value { get; set; }
        public BinaryTreeElement Left { get; set; }
        public BinaryTreeElement Right { get; set; }

        public BinaryTreeElement(int number, double value)
        {
            this.Number = number;
            this.Value = value;
            this.Right = null;
            this.Left = null;
        }

        public bool HasNext()
        {
            return this.Left != null && this.Right != null;
        }

        public void SetRightElement(BinaryTreeElement right)
        {
            this.Right = right;
        }

        public void SetLeftElement(BinaryTreeElement left)
        {
            this.Left = left;
        }
    }
}
