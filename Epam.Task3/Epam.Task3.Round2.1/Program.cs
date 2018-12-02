using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Round2._1
{
    class Program
    {
        public static bool Compare(Round one, Round two)
        {
            if (one.Area() > two.Area())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            Round round1 = new Round(1, 2, 3);
            Round round2 = new Round(0, 0, 5);

            try
            {
                Round round3 = new Round(0, 0, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Total created {0} rounds", Round.Count);
            Console.WriteLine("First round bigger than second? - {0} ", Compare(round1, round2));

        }
    }
}
