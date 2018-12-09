using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.WordFrequency3._2
{
    public class Program
    {
        private static char[] splitter = { ' ', '.', ',' };
        private static string testString = "Microsoft first used the name C# in 1988 for a variant of the" +
            " C language designed for incremental compilation. " +
            "That project was not completed but the name lives on. " +
            "The name \"C sharp\" was inspired by the musical notation where" +
            " a sharp indicates that the written note should be made a semitone " +
            "higher in pitch. This is similar to the language name of C++," +
            " where \"++\" indicates that a variable should be incremented by 1 after being evaluated. " +
            "The sharp symbol also resembles a ligature of four \"+\" symbols (in a two-by-two grid), " +
            "further implying that the language is an increment of C++.";

        public static Dictionary<string, int> StringToDictionary(string inputStr)
        {
            Dictionary<string, int> strDict = new Dictionary<string, int>();
            string[] stringArray = inputStr.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(stringArray);
            string tempStr = stringArray[0];
            int count = 1;
            for (int i = 0; i < stringArray.Length; i++)
            {
                string currentStr = stringArray[i];

                if (tempStr.Equals(currentStr, StringComparison.InvariantCultureIgnoreCase))
                {
                    count++;
                }
                else
                {
                    strDict.Add(tempStr, count);
                    tempStr = currentStr;
                    count = 1;
                }
            }

            return strDict;
        }

        public static void PrintResult(Dictionary<string, int> strDict)
        {
            Console.WriteLine("\tFrequency of using words: ");
            foreach (KeyValuePair<string, int> entry in strDict)
            {
                Console.WriteLine($"{entry.Key.ToString()}\t- used {entry.Value.ToString()} - times.");
            }
        }

        public static void Main(string[] args)
        {
            Dictionary<string, int> strDict = StringToDictionary(testString);
            PrintResult(strDict);
        }
    }
}
