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
            rectangle.SideA = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the length of B side of the rectangle");
            rectangle.SideB = int.Parse(Console.ReadLine());

            Console.WriteLine("Area of rectangle = {0}", rectangle.Area());
        }

    class Rectangle
        {
            private int sideA;
            private int sideB;

            public int SideA
            {
                get => sideA;
                set
                {
                    while (value <= 0)
                    {
                        Console.WriteLine("Incorrect value");
                        Console.WriteLine("Enter the length of A side of the rectangle");
                        sideA = int.Parse(Console.ReadLine());
                    }
                    this.sideA = value;
                }
            }

            public int SideB
            {
                get => sideB;
                set
                {
                    while (value <= 0)
                    {
                        Console.WriteLine("Incorrect value");
                        Console.WriteLine("Enter the length of B side of the rectangle");
                        sideB = int.Parse(Console.ReadLine());
                    }
                    this.sideB = value;
                }
            }

            public int Area()
            {
                return SideA * sideB;
            }
        }

    }
}
