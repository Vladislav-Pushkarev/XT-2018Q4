using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.ToIntOrNotToInt4._5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string str1 = "7,04E+21";
            string str2 = "31,4E+01";
            string str3 = "6,02214129E23";
            string str4 = "394 e-03";
            string str5 = "+3r944e-03";
            string str6 = "-323";
            string str7 = "323-4324";
            string str8 = "323,43,24";
            Console.WriteLine("\tDemonstration:");
            Console.WriteLine($"Is there - \"{str1}\" positive integer number? - {str1.ToInt()} ");
            Console.WriteLine($"Is there - \"{str2}\" positive integer number? - {str2.ToInt()} ");
            Console.WriteLine($"Is there - \"{str3}\" positive integer number? - {str3.ToInt()} ");
            Console.WriteLine($"Is there - \"{str4}\" positive integer number? - {str4.ToInt()} ");
            Console.WriteLine($"Is there - \"{str5}\" positive integer number? - {str5.ToInt()} ");
            Console.WriteLine($"Is there - \"{str6}\" positive integer number? - {str6.ToInt()} ");
            Console.WriteLine($"Is there - \"{str7}\" positive integer number? - {str7.ToInt()} ");
            Console.WriteLine($"Is there - \"{str8}\" positive integer number? - {str8.ToInt()} ");

            while (true)
            {
                Console.WriteLine("\tEnter 'q' - to quit or ==>\tTry your own number:");
                string str9 = Console.ReadLine();
                if (str9 == "q")
                {
                    break;
                }

                Console.WriteLine($"Is there - \"{str8}\" positive integer number? - {str9.ToInt()} ");
            }
        }
    }
}
