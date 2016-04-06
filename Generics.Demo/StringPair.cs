using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Demo
{
    public class StringPair
    {
        public StringPair(string item1, string item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public string Item1 { get; set; }
        public string Item2 { get; set; }

        public void Swap()
        {
            string temp = Item1;
            Item1 = Item2;
            Item2 = temp;
        }

        public override string ToString()
        {
            return "(" + Item1.ToString() + ", " + Item2.ToString() + ")";
        }

    }
}
