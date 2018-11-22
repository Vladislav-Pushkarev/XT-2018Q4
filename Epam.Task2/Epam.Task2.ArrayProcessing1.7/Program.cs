using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.ArrayProcessing1._7
{
    class Program
    {
        public static int[] CreateArray(int length, int min, int max)
        {
            int[] arr = new int[length];

            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                arr[i] = random.Next(min, max);
            }
            return arr;
        }

        public static void PrintArray(int[] arr)
        {
            Console.Write("{ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine('}' + Environment.NewLine);
        }

        public static int[] Sort(int[] arr)
        {
            int length = arr.Length;
            int temp = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 1; j < length - i; j++)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            return arr;
        }

        public static int Min(int[] arr)
        {
            Sort(arr);
            return arr[0];
        }

        public static int Max(int[] arr)
        {
            Sort(arr);
            return arr[arr.Length - 1];
        }


        static void Main(string[] args)
        {
            Console.WriteLine("\tArray created :");
            int[] arr = CreateArray(10, -1000, 1000);
            PrintArray(arr);
            Console.WriteLine("The largest number in the array: " + Environment.NewLine + Max(arr));
            Console.WriteLine("The smallest number in the array: " + Environment.NewLine + Min(arr));
            Console.WriteLine("\tArray sorted :");
            PrintArray(arr);
        }
    }
}
