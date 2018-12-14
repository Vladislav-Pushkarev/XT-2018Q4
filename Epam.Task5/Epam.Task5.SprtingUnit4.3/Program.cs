using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.SprtingUnit4._3
{
    public class Program
    {
        private static string[] unsortedStrungArray;

        public static void FillStrungAraay()
        {
            string fileName = "SamplesForStringArray.txt";
            string path = @"..\..\";
            StreamReader reader = new StreamReader(Path.Combine(path, fileName));
            List<string> list = new List<string>();
            string str;
            while ((str = reader.ReadLine()) != null)
            {
                list.Add(str);
            }

            Console.WriteLine("\tArray successfully was filled from file.");
            unsortedStrungArray = list.ToArray();
        }

        public static void AfterSort()
        {
            Console.WriteLine($"And now we've got :{Environment.NewLine}{Environment.NewLine}");
            for (int i = 0; i < unsortedStrungArray.Length; i++)
            {
                Console.Write($"{unsortedStrungArray[i]} ");
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            EventHandler handler = new EventHandler();
            Sort.OnSort += handler.Massage;
            Sort.OnSort += AfterSort;

            Console.WriteLine($"\tDemonstration of custom sort in thread. {Environment.NewLine}");
            FillStrungAraay();
            Console.WriteLine($"We have an unsorted string array like this : {Environment.NewLine}{Environment.NewLine}");
            Func<string, string, int> func = Sort.CompareStringsByLength;

            for (int i = 0; i < unsortedStrungArray.Length; i++)
            {
                Console.Write($"{unsortedStrungArray[i]} ");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("------Sorting strings by length------");
            Sort.ThreadSort(unsortedStrungArray, Sort.CompareStringsByLength);
        }
    }
}
