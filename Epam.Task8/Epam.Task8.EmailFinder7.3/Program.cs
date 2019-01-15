using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Epam.Task8.EmailFinder7._3
{
    public class Program
    {
        private static readonly string GREETING = $"================\t Console EMAIL FINDER application \t================" +
            $"{Environment.NewLine}";

        private static readonly string FOUND = $"\tFollowing EMAILS were found:" +
            $"{Environment.NewLine}";

        private static readonly string NOTFOUND = $"\tEMAILS not found." +
            $"{Environment.NewLine}";

        public static string[] ParseEmails(string input)
        {
            string reg = @"([A-Za-z0-9]([\w-.])*?[A-Za-z0-9])@([A-Za-z0-9]+\.)+[A-Za-z]{2,6}";
            Regex regex = new Regex(reg);
            MatchCollection matches = regex.Matches(input);
            int count = matches.Count;
            string[] output;
            if (count > 0)
            {
                output = new string[count];
                for (int i = 0; i < count; i++)
                {
                    output[i] = matches[i].Value;
                }
                
                return output;
            }

            return null;
        }

        public static void Run()
        {
            string q = null;

            while (q != "q")
            {
                Console.WriteLine($"\t\t\t\tEnter your string");
                string input = Console.ReadLine();
                string[] result = ParseEmails(input);
                if (result != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(FOUND);
                    foreach (string email in result)
                    {
                        sb.Append(email);
                        sb.Append(" | ");
                    }

                    Console.WriteLine(sb.ToString());
                }
                else
                {
                    Console.WriteLine(NOTFOUND);
                }

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
