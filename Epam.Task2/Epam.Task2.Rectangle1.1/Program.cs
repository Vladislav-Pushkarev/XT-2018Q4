using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.Rectangle1._1
{
    class Test
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();

            Console.WriteLine("Enter the length of A side of the rectangle");
            rectangle.SetSideA (int.Parse(Console.ReadLine()));

            Console.WriteLine("Enter the length of B side of the rectangle");
            rectangle.SetSideB(int.Parse(Console.ReadLine()));

            Console.WriteLine("Area of rectangle = {0}", rectangle.Area());
        }

    class Rectangle
        {
            private int sideA;
            private int sideB;

            public void SetSideA(int sideA)
            {
                while (sideA <= 0)
                {
                    Console.WriteLine("Incorrect value");
                    Console.WriteLine("Enter the length of A side of the rectangle");
                    sideA = int.Parse(Console.ReadLine());
                }
                    this.sideA = sideA;
            }

            public void SetSideB(int sideB)
            {
                while (sideB <= 0)
                {
                    Console.WriteLine("Incorrect value");
                    Console.WriteLine("Enter the length of B side of the rectangle");
                    sideB = int.Parse(Console.ReadLine());

                }
                this.sideB = sideB;
            }

            public int GetSideA()
            {
                return sideA;
            }

            public int GetSideB()
            {
                return sideB;
            }

            public int Area()
            {
                return sideA * sideB;
            }
        }

    }
}
