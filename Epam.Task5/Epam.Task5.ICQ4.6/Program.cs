using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.ICQ4._6
{
    public static class Program
    {
        private static int[] testArray = new int[1000];
        private static int[] result;
        private static List<double> timeAverage = new List<double>();
        private static Stopwatch stopwatch = new Stopwatch();

        public static int[] PositiveNumbersSearch(int[] arr)
        {
            List<int> list = new List<int>();
            int[] positiveNumbers;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    list.Add(arr[i]);
                }
            }

            positiveNumbers = list.ToArray();

            return positiveNumbers;
        }

        public static int[] PositiveNumbersSearchUsingDelegate(int[] arr, Func<int, bool> func)
        {
            List<int> list = new List<int>();
            int[] positiveNumbers;
            for (int i = 0; i < arr.Length; i++)
            {
                if (func(arr[i]))
                {
                    list.Add(arr[i]);
                }
            }

            positiveNumbers = list.ToArray();

            return positiveNumbers;
        }

        public static bool Func(int arrItem)
        {
            return arrItem > 0;
        }

        public static int[] LinqSearch(int[] arr)
        {
            int[] positiveNumbers = arr.Where(x => x > 0).ToArray();

            return positiveNumbers;
        }

        public static void Main(string[] args)
        {
            string splitter = "********************************************************************************";
            FillArr();
            Console.WriteLine("\tDemonstration of different ways to search positive numbers in int array.");
            Console.WriteLine("We have the random array, lets try to found positive numbers in it!");
            Console.WriteLine(splitter);

            Console.WriteLine("Regular method - started up...");
            for (int i = 0; i < 50; i++)
            {
                stopwatch.Start();
                PositiveNumbersSearch(testArray);
                stopwatch.Stop();
                timeAverage.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            result = PositiveNumbersSearch(testArray);
            PrintArr(result);
            Console.WriteLine($"On average, it takes {timeAverage.Average()} milliseconds.");
            timeAverage.Clear();
            Console.WriteLine(splitter);

            Console.WriteLine("Method where the compare condition is passed through the delegate - started up...");
            for (int i = 0; i < 50; i++)
            {
                stopwatch.Start();
                PositiveNumbersSearchUsingDelegate(testArray, Func);
                stopwatch.Stop();
                timeAverage.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            result = PositiveNumbersSearchUsingDelegate(testArray, Func);
            PrintArr(result);
            Console.WriteLine($"On average, it takes {timeAverage.Average()} milliseconds.");
            timeAverage.Clear();
            Console.WriteLine(splitter);

            Console.WriteLine("Method where the compare condition is passed through anonymus method - started up...");
            for (int i = 0; i < 50; i++)
            {
                stopwatch.Start();
                PositiveNumbersSearchUsingDelegate(
                    testArray, 
                    delegate(int arrItem)
                    {
                        return arrItem > 0;
                    });
                stopwatch.Stop();
                timeAverage.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            result = PositiveNumbersSearchUsingDelegate(
                    testArray,
                    delegate(int arrItem)
                    {
                        return arrItem > 0;
                    });
            PrintArr(result);
            Console.WriteLine($"On average, it takes {timeAverage.Average()} milliseconds.");
            timeAverage.Clear();
            Console.WriteLine(splitter);

            Console.WriteLine("Method where the compare condition is passed through lambda - started up...");
            for (int i = 0; i < 50; i++)
            {
                stopwatch.Start();
                PositiveNumbersSearchUsingDelegate(testArray, arrItem => arrItem > 0);
                stopwatch.Stop();
                timeAverage.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            result = PositiveNumbersSearchUsingDelegate(testArray, arrItem => arrItem > 0);
            PrintArr(result);
            Console.WriteLine($"On average, it takes {timeAverage.Average()} milliseconds.");
            timeAverage.Clear();
            Console.WriteLine(splitter);

            Console.WriteLine("Search using linq method - started up...");
            for (int i = 0; i < 50; i++)
            {
                stopwatch.Start();
                LinqSearch(testArray);
                stopwatch.Stop();
                timeAverage.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            result = LinqSearch(testArray);
            PrintArr(result);
            Console.WriteLine($"On average, it takes {timeAverage.Average()} milliseconds.");
            timeAverage.Clear();
            Console.WriteLine(splitter);
        }

        private static void FillArr()
        {
            Random random = new Random();
            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = random.Next(-8000, 300);
            }
        }

        private static void PrintArr(int[] arr)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Found: [ ");
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append($"{arr[i]} ");
            }

            sb.Append($"]{Environment.NewLine}");

            Console.WriteLine(sb.ToString());
        }
    }
}
