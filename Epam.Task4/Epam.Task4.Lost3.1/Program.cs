using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam.Task4.Lost3._1
{
    public class Program
    {
        public static int ParseAndCheckN(string str)
        {
            int n;
            if (!int.TryParse(str, out n))
            {
                throw new ArgumentException("Input value must be a number.");
            }

            if (n < 2)
            {
                throw new ArgumentException("Input value must be geater or equal two.");
            }

            return n;
        }

        public static LinkedList<Person> CreateList(int n)
        {
            LinkedList<Person> list = new LinkedList<Person>();
            for (int i = 1; i <= n; i++)
            {
                Person person = new Person(i);

                list.AddLast(person);
            }

            return list;
        }

        public static LinkedList<Person> LostPerson(LinkedList<Person> list)
        {
            var current = list.First;
            while (list.Count() > 1)
            {
                var target = current.Next;
                if (target == null)
                {
                    target = list.First;
                }

                Console.WriteLine($"{target.Value.Index} - Removed");
                list.Remove(target);
                current = current.Next;
                if (current == null)
                {
                    current = list.First;
                }
            }

            return list;
        }

        public static void PrintList(LinkedList<Person> list)
        {
            StringBuilder str = new StringBuilder();
            str.Append("{ ");
            foreach (Person person in list)
            {
                str.Append(person.Index + " ");
            }

            str.Append("}");
            Console.WriteLine(str.ToString());
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("\tEnter the number of man: ");
            string inputN = Console.ReadLine();
            int n = ParseAndCheckN(inputN);
            Console.WriteLine("\tCreated list of man : ");
            LinkedList<Person> list = CreateList(n);
            PrintList(list);
            Console.WriteLine("\tRemoving:");
            LinkedList<Person> list2 = LostPerson(list);
            Console.WriteLine("\tFinally we got:");
            PrintList(list2);
        }
    }
}
