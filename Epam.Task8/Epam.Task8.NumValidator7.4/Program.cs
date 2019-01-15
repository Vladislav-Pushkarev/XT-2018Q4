using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.NumValidator7._4
{
    public class Program
    {
        private static readonly string GREETING = $"================\t Console NUMBER VALIDATOR application \t================" +
            $"{Environment.NewLine}";

        private static readonly string USUAL = "Это число в обычной нотации";

        private static readonly string SCIENTIFIC = "Это число в научной нотации";

        private static readonly string NOTNUM = "Это не число";

        public static string NumCheck(string input)
        {
            string regUsual = @"([+-]?\d+\.?\d*)";
            string regScientific = @"([-+^]?\d+\.?\d*)(e?([+-]?\d+\d*)|[×*x]?\d+\^?[-+]?\d+)";
            Regex regex = new Regex(regUsual);
            string match = regex.Match(input).Value;

            if (match == input)
            {
                return USUAL;
            }

            regex = new Regex(regScientific);
            match = regex.Match(input).Value;

            if (match == input)
            {
                return SCIENTIFIC;
            }

            return NOTNUM;
        }

        public static void Run()
        {
            string q = null;

            while (q != "q")
            {
                Console.WriteLine($"\t\t\t\tEnter your string");
                string input = Console.ReadLine();

                Console.WriteLine(NumCheck(input));
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
