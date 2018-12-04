using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Ring2._6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Ring ring1 = new Ring(1, 2, 4, 10);
            Console.WriteLine(ring1.Area);
            Console.WriteLine(ring1.Length);

            try
            {
                Ring ring2 = new Ring(1, 2, 10, 4);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
