using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.AvarageStringLength1._11
{
    class Program
    {
        public static double AverageLetters(string str)
        {
            char[] c = str.ToCharArray();
            int countOfLetters = 0;
            int countOfWords = 0;
            double averageLetters;

            for (int i = 0; i < c.Length; i++)
            {
                if (char.IsLetter(c[i]))
                {
                    countOfLetters++;
                    if (i < c.Length - 1 && (!char.IsLetter(c[i + 1]) || i + 1 == c.Length - 1))
                    {
                        countOfWords++;
                    }
                }

            }
            averageLetters = (double)countOfLetters / countOfWords;
            return averageLetters;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sentence.");
            string str = Console.ReadLine();

            Console.WriteLine("Average number of letters in a word : {0}", AverageLetters(str));
        }
    }
}
