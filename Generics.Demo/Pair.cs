using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Demo
{
    public class Pair<T>
    {
        public Pair(T item1, T item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public T Item1 { get; set; }
        public T Item2 { get; set; }

        public void Swap()
        {
            T temp = Item1;
            Item1 = Item2;
            Item2 = temp;
        }

        public override string ToString()
        {
            return "(" + Item1.ToString() + ", " + Item2.ToString() + ")";
        }

    }
}

