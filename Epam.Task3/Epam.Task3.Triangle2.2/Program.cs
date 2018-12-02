using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Triangle2._2
{
    public class Program
    {
        public static bool Compare(Triangle one, Triangle two)
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

        public static void Main(string[] args)
        {
            Triangle triangle1 = new Triangle(1, 2, 4);
            Triangle triangle2 = new Triangle(7.4, 2, 5);

            try
            {
                Triangle triangle3 = new Triangle(1, 2, 3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Total created {0} triangles", Triangle.Count);
            Console.WriteLine("First triangle bigger than second? - {0} ", Compare(triangle1, triangle2));

            Console.WriteLine("Side A = {0}, Side A = {1},Side A = {2}", triangle2.SideA, triangle2.SideB, triangle2.SideC);
            try
            {
                triangle2.SideC = 6;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
