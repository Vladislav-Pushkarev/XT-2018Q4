using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.SumOfNumbers1._5
{
    class Program
    {   
        public static int Sum(int n, int limit)
        {
            int number = n;
            int sum = 0;
            while (number < limit)
            {
                sum += number;
                number += n;
            }
            return sum;

        }
        static void Main(string[] args)
        {
            int result = Sum(3, 1000) + Sum(5, 1000) - Sum(3 * 5, 1000);
            Console.WriteLine("Sum of numbers less than 1000 and multiples of 5 and 3 = {0}", result);
        }
    }
}
