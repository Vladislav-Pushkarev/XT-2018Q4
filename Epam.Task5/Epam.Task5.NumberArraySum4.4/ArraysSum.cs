﻿namespace Epam.Task5.NumberArraySum4._4
{
    public static class ArraysSum
    {
        public static byte Sum(this byte[] array)
        {
            byte sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static float Sum(this float[] array)
        {
            float sum = 0.0F;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static short Sum(this short[] array)
        {
            short sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static double Sum(this double[] array)
        {
            double sum = 0.0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static int Sum(this int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static long Sum(this long[] array)
        {
            long sum = 0L;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static sbyte Sum(this sbyte[] array)
        {
            sbyte sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static ushort Sum(this ushort[] array)
        {
            ushort sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static uint Sum(this uint[] array)
        {
            uint sum = 0U;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static ulong Sum(this ulong[] array)
        {
            ulong sum = 0UL;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}