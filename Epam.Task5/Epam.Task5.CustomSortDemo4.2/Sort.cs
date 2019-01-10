using System;

namespace Epam.Task5.CustomSortDemo4._2
{
    public class Sort
    {
        public static int CompareStrings(string one, string two)
        {
            int minLength = one.Length <= two.Length ? one.Length : two.Length;
            for (int i = 0; i < minLength; i++)
            {
                if (char.ToLower(one[i]) != char.ToLower(two[i]))
                {
                    return char.ToLower(one[i]) - char.ToLower(two[i]);
                }
            }

            return one.Length - two.Length;
        }

        public static int CompareStringsByLength(string one, string two)
        {
            if (one.Length == two.Length)
            {
                for (int i = 0; i < one.Length; i++)
                {
                    if (char.ToLower(one[i]) != char.ToLower(two[i]))
                    {
                        return char.ToLower(one[i]) - char.ToLower(two[i]);
                    }
                }
            }

            return one.Length - two.Length;
        }

        public static void CustomQuicksort<T>(T[] array, Func<T, T, int> func, int left, int right)
        {
            int i = left;
            int j = right;
            T pivot = array[left + ((right - left) / 2)];

            while (i <= j)
            {
                while (func(array[i], pivot) < 0)
                {
                    i++;
                }

                while (func(array[j], pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                CustomQuicksort(array, func, left, j);
            }

            if (i < right)
            {
                CustomQuicksort(array, func, i, right);
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine($"\tDemonstration of custom sort. {Environment.NewLine}");
            Console.WriteLine("We have an unsorted string array like this :");
            Func<string, string, int> func = CompareStringsByLength;

            string[] unsortedStrungArray = { "You", "underestimate", "the", "power", "of", "the", "dark", "side" };

            for (int i = 0; i < unsortedStrungArray.Length; i++)
            {
                Console.Write($"{unsortedStrungArray[i]} ");
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("------Sorting strings by length------");
            CustomQuicksort(unsortedStrungArray, func, 0, unsortedStrungArray.Length - 1);
            Console.WriteLine("And now we've got :");
            for (int i = 0; i < unsortedStrungArray.Length; i++)
            {
                Console.Write($"{unsortedStrungArray[i]} ");
            }

            Console.WriteLine();
        }
    }
}
