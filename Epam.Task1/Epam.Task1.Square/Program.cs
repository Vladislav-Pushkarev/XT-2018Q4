using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Square
{
    class Program
    {
        public static void PrintSquare(int n)
        {
            char ch = '*';
            char[,] squre = new char[n, n]; // crate a two-dimensional array


            for (int i = 0; i < n; i++)     // fill the array
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == n / 2 && i == n / 2)
                    {
                        squre[i, j] = ' ';
                    }
                    else squre[i, j] = ch;
                }
            }

            for (int i = 0; i < n; i++)     // print the array
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(squre[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("Enter N");
            n = int.Parse(Console.ReadLine());
            PrintSquare(n);
            Console.ReadLine();            
        }
    }
}
