using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.X_mas1._4
{

    class Programm
    {
        public static void Xmas(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(' ');
            }

            Console.WriteLine('*');

            for (int i = 0; i < n; i++)
            {
                Triangle(i + 2, n);
            }
       
        }

        public static void Triangle(int n, int spaces)
        {
            int numOfSpases = spaces;
            int numOfAsterisk = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < numOfSpases; j++)
                {
                    Console.Write(' ');
                }
                for (int k = 0; k < numOfAsterisk; k++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
                numOfAsterisk += 2;
                numOfSpases--;
            }
        }

        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("Enter N");
            n = int.Parse(Console.ReadLine());

            Xmas(n);
        }
    }
}
