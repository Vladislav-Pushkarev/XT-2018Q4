using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.NonNegativeSum1._9
{
    class Program
    {
        public static int NonNegativeSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    sum += arr[i];
                }
            }
            return sum;
        }

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


        static void Main(string[] args)
        {
            Console.WriteLine("\tArray created :");
            int[] arr = CreateArray(10, -1000, 1000);
            PrintArray(arr);

            Console.WriteLine("\tNon-negative sum of array = {0}", NonNegativeSum(arr));
        }
    }
}
