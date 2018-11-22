using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.NoPositive1._8
{
    class Program
    {
        public static int[,,] CreateArray(int length1, int length2, int length3, int min, int max)
        {
            int[,,] arr = new int[length1, length2, length3];

            Random random = new Random();
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    for (int k = 0; k < length3; k++)
                    {
                        arr[i, j, k] = random.Next(min, max);
                    }
                }
            }
            return arr;
        }

        public static void PrintArray(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        Console.Write(arr[i, j, k] + " ");
                    }
                }
            }
        }

        public static void NoPositive(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("3 dementional array created: ");
            int[,,] arr = CreateArray(3, 2, 4, -100, 100);
            PrintArray(arr);

            Console.WriteLine("Positive numbers were replaced to zero: ");
            NoPositive(arr);
            PrintArray(arr);
        }
    }
}
