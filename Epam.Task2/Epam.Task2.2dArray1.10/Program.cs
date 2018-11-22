using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._2dArray1._10
{
    class Program
    {
        public static int EvenSum(int[,] arr)
        {
            int sum = 0;
            int i = 1;
            int j = 1;
            while (i < arr.GetLength(0) || j < arr.GetLength(1))
            {
                sum += arr[i, j];
                j += 2;
                i += 2;
            }
            return sum;
        }

        public static int[,] CreateArray(int length1, int length2, int min, int max)
        {
            int[,] arr = new int[length1, length2];

            Random random = new Random();
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    arr[i, j] = random.Next(min, max);
                }
            }
            return arr;
        }

        public static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("\tArray created :");
            int[,] arr = CreateArray(4, 4, -100, 100);
            PrintArray(arr);

            Console.WriteLine("\tThe sum of numbers on the even position = {0}", EvenSum(arr));
        }
    }
}