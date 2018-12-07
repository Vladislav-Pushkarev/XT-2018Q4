using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.IsSimpeNum
{
    class Program
    {
        public static bool IsSimpleNum (int n)
        {
            if (n > 1)
            {
                for (int i = 2;  i < n; i++)
                {
                    if (n % i == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            int n;
            StringBuilder stringBuilder = new StringBuilder();

            while (true)
            {
            Console.WriteLine("Enter your number");
            n = int.Parse(Console.ReadLine());
                stringBuilder.Append(IsSimpleNum(n) ? n + " - prime number" : n + " - not a prime number");
            Console.WriteLine(stringBuilder.AppendLine());
                stringBuilder.Clear();
            }
        }
    }
}
