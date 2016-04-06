using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Domain;
using Talent.Domain.TestData;

namespace Interfaces.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 02 - Interfaces:");

            DomainObjectStore store = new DomainObjectStore();

            Console.WriteLine("\r\nDisplay Genres:");
            foreach (Show show in store.Shows)
            {
                Console.WriteLine(show.Display());
            }

            Console.WriteLine("\r\nDisplay MPAA Ratings:");
            foreach (MpaaRating rating in store.MpaaRatings)
            {
                Console.WriteLine(rating.Display());
            }

            Console.WriteLine("\r\nPolymorphism via Base class:");
            List<LookupBase> lookups = new List<LookupBase>();
            lookups.AddRange(store.Genres);
            lookups.AddRange(store.MpaaRatings);
            foreach (LookupBase lookup in lookups)
            {
                Console.WriteLine(lookup.Display());
            }


            Console.WriteLine("\r\nDisplay Shows:");
            foreach(Show show in store.Shows)
            {
                Console.WriteLine(show.Display());
            }

            Console.WriteLine("\r\nPolymorphism via Interface:");
            List<IDisplayable> displayables = new List<IDisplayable>();
            displayables.AddRange(store.Shows);
            displayables.AddRange(store.MpaaRatings);
            foreach (IDisplayable displayable in displayables)
            {
                Console.WriteLine(displayable.Display());
            }

            Console.WriteLine("\r\nSorting People by Name");
            store.People.Sort();
            foreach(Person p in store.People)
            {
                Console.WriteLine(p.LastFirstName);
            }

            Console.WriteLine("\r\nUse the IEnumerator interface:");
            ArrayList arrayList = new ArrayList()
            {
                17, 45.67, 18.333M, store.People[0], "My String"
            };
            IEnumerator myEnumerator = arrayList.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                Console.WriteLine(myEnumerator.Current.ToString());
            }

            Console.ReadLine();
        }
    }
}
