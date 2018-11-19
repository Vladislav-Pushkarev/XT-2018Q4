using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.AnotherTriangle1._3
{
    class Program
    {
        public static void Triangle(int n)
        {
        int numOfSpases = n - 1;
        int numOfAsterisk = 1;
          for (int i = 0; i < n; i++)
          {
                for (int j = 0; j < numOfSpases; j++)
                {
                    Console.Write(' ');
                }
                 for (int k= 0; k < numOfAsterisk; k++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
                numOfAsterisk +=2;
                numOfSpases--;             
          }
        }

        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("Enter N");
            n = int.Parse(Console.ReadLine());

            Triangle(n);
            Console.ReadLine();
        }
    }
}