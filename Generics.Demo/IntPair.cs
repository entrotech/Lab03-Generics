using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Demo
{
    public class IntPair
    {
        public IntPair(int item1, int item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public int Item1 { get; set; }
        public int Item2 { get; set; }

        public void Swap()
        {
            int temp = Item1;
            Item1 = Item2;
            Item2 = temp;
        }

        public override string ToString()
        {
            return "(" + Item1.ToString() + ", " + Item2.ToString() + ")";
        }

    }
}

