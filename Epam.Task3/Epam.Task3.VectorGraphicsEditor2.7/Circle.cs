using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor2._7
{
    public class Circle : Figure
    {
        private double r;
        private double length;

        public Circle()
        {
            this.CoordX = 0;
            this.CoordY = 0;
            this.R = 10;
        }

        public double R
        {
            get
            {
                return this.r;
            }

            set
            {
                if (value > 0)
                {
                    this.r = value;
                }
                else
                {
                    throw new ArgumentException("Radius cannot be negative");
                }
            }
        }

        public double Length
        {
            get
            {
                if (this.length == 0)
                {
                    this.length = 2 * Math.PI * this.r;
                }

                return this.length;
            }
        }

        public override void Print()
        {
            Console.WriteLine($"Figure - Circle, Coordinates: X- {base.CoordX}, Y- {base.CoordY}," +
                $"Length - {length}, radius - {r}");
        }
    }
}
