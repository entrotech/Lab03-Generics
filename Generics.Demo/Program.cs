using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Domain;
using Talent.Domain.TestData;

namespace Generics.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 03 - Generics:");

            DemoWithoutGenerics();
            //DemoGenericPair();
            //DemoNullable();
            //DemoNillable();
            //DemoGenericList();

            Console.ReadLine();
        }

        private static void DemoWithoutGenerics()
        {
            IntPair intPair = new IntPair(7, 11);
            Console.WriteLine("\r\nintPair = " + intPair);
            intPair.Swap();
            Console.WriteLine("After Swap: " + intPair);

            StringPair stringPair = new StringPair("Left", "Right");
            Console.WriteLine("\r\nstringPair = " + stringPair);
            stringPair.Swap();
            Console.WriteLine("After Swap: " + stringPair);
        }

        private static void DemoGenericPair()
        {
            Pair<int> intPairG = new Pair<int>(7, 11);
            Console.WriteLine(String.Format("\r\nintPair: {0}", intPairG));
            intPairG.Swap();
            Console.WriteLine(String.Format("After Swap: {0}", intPairG));

            Pair<string> stringPairG = new Pair<string>("Left", "Right");
            Console.WriteLine(String.Format("\r\nstringPair: {0}", stringPairG));
            stringPairG.Swap();
            Console.WriteLine(String.Format("After Swap: {0}", stringPairG));

            Pair<Genre> genrePair = new Pair<Genre>(
                new Genre { Id = 1, Code = "Prog", Name = "Programming", DisplayOrder = 10 },
                new Genre { Id = 2, Code = "Adv", Name = "Adventure", DisplayOrder = 10 });
            Console.WriteLine(String.Format("\r\ngenrePair: {0}", genrePair));
            genrePair.Swap();
            Console.WriteLine(String.Format("After Swap: {0}", genrePair));
        }

        private static void DemoNullable()
        {
            Console.WriteLine("\r\nUsing Nullable<T>:\r\n");

            Console.WriteLine("\r\nWhen int? is assigned a value:");

            int? nonNullIndex = -4;
            // Equivalent "Long Form" syntax:
            //Nullable<int> nonNullIndex = new Nullable<int>(-4);

            // HasValue returns true
            Console.WriteLine("nonNullIndex.HasValue = " + (nonNullIndex.HasValue ? "T" : "F"));

            // We can get value
            Console.WriteLine("nonNullIndex.Value = " + nonNullIndex.Value);

            // And can cast to int
            Console.WriteLine("nonNullIndex as int = " + (int)nonNullIndex);

            Console.WriteLine("\r\nWhen int? is NOT assigned a value:");

            int? nullIndex = null;
            //Nullable<int> nullIndex = new Nullable<int>(); // previous line is shortcut for this

            // HasValue returns False
            Console.WriteLine("nullIndex.HasValue = " + (nullIndex.HasValue ? "T" : "F"));

            // If we try to get value or explicitly cast to int when HasValue is false, a 
            // System.InvalidOperationException is thrown
            //Console.WriteLine("nullIndex.Value = " + nullIndex.Value);

            // Explicit casting will also fail
            //Console.WriteLine("nullIndex as int = " + (int)nullIndex);

            Console.WriteLine("\r\nSafely getting value from int?:");

            Console.WriteLine("nullIndex = " 
                + (nullIndex.HasValue ? nullIndex.Value.ToString() : "No Value"));
            Console.WriteLine("nonNullIndex = " 
                + (nonNullIndex.HasValue ? nonNullIndex.Value.ToString() : "No Value"));

            Console.WriteLine("nullIndex = " + nullIndex.GetValueOrDefault());
            Console.WriteLine("nonNullIndex = " + nonNullIndex.GetValueOrDefault());

            // We can also safely replace a null value with a default value
            // by using the null coalescing operator, ??
            // This is useful when we want to replace null with a specific value.
            Console.WriteLine("nullIndex = " + (nullIndex ?? -1).ToString());
            Console.WriteLine("nonNullIndex = " + (nonNullIndex ?? -1).ToString()); 

        }

        private static void DemoNillable()
        {
            Console.WriteLine("\r\nUsing the Nillable<T> class: ");

            Nillable<int> p = new Nillable<int>(5);
            Nillable<int> q = new Nillable<int>();

            Console.WriteLine("p = " + (p.HasValue ? p.Value.ToString() : "No Value"));
            Console.WriteLine("q = " + (q.HasValue ? q.Value.ToString() : "No Value"));
        }

        private static void DemoGenericList()
        {
            Console.WriteLine("\r\nList<Genre>");
            DomainObjectStore dos = new DomainObjectStore();

            foreach (var g in dos.Genres)
            {
                Console.WriteLine(String.Format("\t({0}) {1}",
                    g.Code, g.Name));
            }

            Console.WriteLine("\r\nSorting People by Name");
            dos.People.Sort();
            foreach (Person p in dos.People)
            {
                Console.WriteLine(p.LastFirstName);
            }

            Console.WriteLine("\r\nSorting People by Age");
            dos.People.Sort(new PersonAgeComparer());
            foreach (Person p in dos.People)
            {
                Console.WriteLine(p.LastFirstName + " Age: " + 
                    ((p.Age.HasValue) ? p.Age.Value.ToString() : "Unknown"));
            }
        }
       
    }
}
