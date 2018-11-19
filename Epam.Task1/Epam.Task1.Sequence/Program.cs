using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Sequence
{
    class Program
    {

        public static void PrintSequence (int n)
        {
            for (int i = 1; i < n; i++)
            {
                Console.Write(i + ", ");
            }
            Console.Write(n);
        }

        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("Enter N");
            n = int.Parse(Console.ReadLine()); //read N 
            PrintSequence(n);    //print Sequence up to N
        }
    }
}
