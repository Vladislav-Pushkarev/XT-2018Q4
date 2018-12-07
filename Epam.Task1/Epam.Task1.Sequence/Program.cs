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
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 1; i < n; i++)
            {
                stringBuilder.Append(i + ", ");
            }
            stringBuilder.Append(n);
            Console.WriteLine(stringBuilder);
        }

        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("Enter N");
            n = int.Parse(Console.ReadLine()); 
            PrintSequence(n);
        }
    }
}
