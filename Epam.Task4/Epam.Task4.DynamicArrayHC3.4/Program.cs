using System;
using System.Text;

namespace Epam.Task4.DynamicArrayHC3._4
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

        public static void PrintArr(int[] list)
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

                    Console.WriteLine("\tGet -10 item of list.");
            Console.WriteLine(list[-10]);

                    Console.WriteLine("\tGet -3 item of list.");
            Console.WriteLine(list[-3]);

                    Console.WriteLine("\tChange capacity to 50.");
            list.Capacity = 50;
            PrintArray(list);
            Console.WriteLine(list);

                    Console.WriteLine("\tChange capacity to 7.");
            list.Capacity = 7;
            PrintArray(list);
            Console.WriteLine(list);
            var newList = list.Clone();
            PrintArray((DynamicArray<int>)newList);
            Console.WriteLine(newList);

                    Console.WriteLine("\tToArray demonstration:");
            var simpleArr = list.ToArray();
            PrintArr(simpleArr);

            Console.WriteLine($"{Environment.NewLine} \tCycled Dynamic Array demonstration.");
            Console.WriteLine("Cycled Dynamic Array created:");
            CycledDynamicArray<int> cycledList = new CycledDynamicArray<int>();
            Console.WriteLine(cycledList);
            for (int i = 0; i < 10; i++)
            {
                cycledList.Add(i);
            }

            Console.WriteLine("\tAdded 10 items.");
            PrintCycledArray(cycledList, 10);
            Console.WriteLine(cycledList);

            Console.WriteLine("\tGet -10 item of list.");
            Console.WriteLine(cycledList[-10]);
        }

        private static void PrintCycledArray<T>(CycledDynamicArray<T> list, int stop)
        {
            int count = 0;
            int circle = list.Length;
            int circleCounter = 0;
            foreach (var n in list)
            {
                Console.Write(n);
                Console.Write(' ');
                count++;
                if (count == circle)
                {
                    count = 0;
                    circleCounter++;
                    Console.WriteLine($"\t====> Circle counter - {circleCounter}");
                }

                if (circleCounter == stop)
                {
                    break;
                }
            }
        }
    }
}
