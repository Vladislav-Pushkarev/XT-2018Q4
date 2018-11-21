using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.ArrayProcessing1._7
{
    class Program
    {
        public static int [] CreateArray (int length, int min, int max)
        {
            int[] arr = new int[length];
           
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                arr[i] = random.Next(min, max);
            }
            return arr;
        }

        public static void PrintArray (int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void Main(string[] args)
        {
            PrintArray(CreateArray(10, -100, 100));
        }
    }
}
