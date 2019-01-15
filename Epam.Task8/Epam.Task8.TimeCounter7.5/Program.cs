using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.TimeCounter7._5
{
    public class Program
    {
        private static readonly string GREETING = $"================\t Console TIME COUNTER application \t================" +
            $"{Environment.NewLine}";

        public static int TimeCount(string input)
        {
            string reg = @"(0?[0-9]|[0-1][\d]|2[0-3]):(0[0-9]|[0-5][\d])(:(0[0-9]|[0-5][\d]))?";
            Regex regex = new Regex(reg);
            MatchCollection matches = regex.Matches(input);
            return matches.Count;
        }

        public static void Run()
        {
            string q = null;

            while (q != "q")
            {
                Console.WriteLine($"\t\t\t\tEnter your string");
                string input = Console.ReadLine();
                int count = TimeCount(input);
                string result = $"В тексте нет времени.";
                if (count > 0)
                {
                    result = $"Время в тексте присутствует {count} раз(а).";
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
