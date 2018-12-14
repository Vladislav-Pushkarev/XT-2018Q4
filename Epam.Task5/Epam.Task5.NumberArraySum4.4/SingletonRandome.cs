using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.NumberArraySum4._4
{
        public static class SingletonRandome
        {
            private static Random random = new Random();
            private static object sync = new object();

            public static int Next(int min, int max)
            {
                lock (sync)
                {
                    return random.Next(min, max);
                }
            }
        }
}
