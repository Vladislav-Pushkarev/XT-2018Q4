using System;

namespace Epam.Task5.NumberArraySum4._4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\tNumber Arrays sum demonstration.");
            int[] sampleArr = new int[18];
            for (int i = 0; i < sampleArr.Length; i++)
            {
                sampleArr[i] = SingletonRandome.Next(-666, 666);
            }

            Console.WriteLine("Array was filled with random numbers.");
            Console.WriteLine("Our array: ");
            for (int i = 0; i < sampleArr.Length; i++)
            {
                Console.Write($"{sampleArr[i]} ");
            }

            Console.WriteLine($"\t\tCall the array method \"Sum\". {Environment.NewLine}" +
                $"Sum of array items: {sampleArr.Sum()}");
        }
    }
}
