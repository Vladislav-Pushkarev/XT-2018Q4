using System;
using System.Text;

namespace Epam.Task4.DynamicArray3._3
{
    public class Program
    {
        public static void PrintArray<T>(DynamicArray<T> list)
        {
            StringBuilder str = new StringBuilder();
            str.Append("{ ");
            foreach (int n in list)
            {
                str.Append(n + " ");
            }

            str.Append("}");
            Console.WriteLine(str.ToString());
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Dynamic Array created:");
            DynamicArray<int> list = new DynamicArray<int>();
            Console.WriteLine(list);
                for (int i = 0; i < 10; i++)
                {
                    list.Add(i);
                }

            Console.WriteLine("\tAdded 10 items.");
            PrintArray(list);
            Console.WriteLine(list);
            Console.WriteLine("\tRemoved 5 item.");
            list.Remove(5);
            PrintArray(list);
            Console.WriteLine(list);
            int[] simpleArr = new int[10];
            for (int i = 0; i < simpleArr.Length; i++)
            {
                simpleArr[i] = i + 10;
            }

            Console.WriteLine("\tAdded simple array with 10 items.");
            list.AddRange(simpleArr);
            PrintArray(list);
            Console.WriteLine(list);
            Console.WriteLine("\t666 - inserted at 10 index.");
            list.Insert(10, 666);
            PrintArray(list);
            Console.WriteLine(list);
            Console.WriteLine($"Get 3th item of list {list[2]}");
        }
    }
}
