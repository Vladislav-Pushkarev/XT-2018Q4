using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.DateExistance7._1
{
    public class Program
    {
        private static readonly string GREETING = $"================\t Console DATE EXISTANCE application \t================" +
            $"{Environment.NewLine}";

        private static readonly string STARTER = "В тексте";

        private static readonly string CONTAINS = "содержится дата.";

        private static readonly string DOESNOTCONTAINS = "не содержится дата.";

        public static bool DateExistance(string input)
        {
            string reg = @"((0[0-9]|[1-2][\d]|3[0-1])[ /.-])((0[0-9]|1[0-2])[ /.-])(\d{4})";
            Regex regex = new Regex(reg);
            MatchCollection matches = regex.Matches(input);
            return matches.Count > 0;
        }

        public static void Run()
        {
            string q = null;
            
            while (q != "q")
            {
                Console.WriteLine($"\t\t\t\tEnter your string");
                string input = Console.ReadLine();
                string result;
                if (DateExistance(input))
                {
                    result = $"{STARTER} \"{input}\" {CONTAINS}";
                }
                else
                {
                    result = $"{STARTER} \"{input}\" {DOESNOTCONTAINS}";
                }

                Console.WriteLine(result);
                Console.WriteLine($"\tPush ENTER - to try again\t\t\tq - to QUIT");
                q = Console.ReadLine();
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(GREETING);
            Run();
        }
    }
}
