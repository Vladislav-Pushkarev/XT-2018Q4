using System;
using System.Diagnostics;
using System.Threading;

namespace Epam.Task5.SprtingUnit4._3
{
    public class Sort
    {
        private static string inTime;

        public delegate void HandlerContainer();

        public static event HandlerContainer OnSort;

        public static string InTime { get => inTime; }

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

        public static void ThreadSort<T>(T[] array, Func<T, T, int> func)
        {
            int left = 0;
            int right = array.Length - 1;
            void Sorted()
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                CustomQuicksort(array, func, left, right);
                stopwatch.Stop();
                inTime = $"It took {stopwatch.Elapsed.TotalMilliseconds} milliseconds.";
                OnSort();
            }

            Thread thread = new Thread(() => Sorted());
                
                thread.Start();
        }
    }
}