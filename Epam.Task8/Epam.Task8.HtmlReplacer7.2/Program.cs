using System;
using System.Text.RegularExpressions;

namespace Epam.Task8.HtmlReplacer7._2
{
    public class Program
    {
        private static readonly string GREETING = $"================\t Console HTML REPLACER application \t================" +
            $"{Environment.NewLine}";

        private static readonly string REPLACEMENT = $"_";

        public static string ReplaceHtml(string input)
        {
            string reg = @"(<.*?>)";
            string output = Regex.Replace(input, reg, REPLACEMENT);
            
                return output;
        }

        public static void Run()
        {
            string q = null;

            while (q != "q")
            {
                Console.WriteLine($"\t\t\t\tEnter your string");
                string input = Console.ReadLine();
                string result = ReplaceHtml(input);
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
