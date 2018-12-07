using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor2._7
{
    public class Round : Figure 
    {
        private static int count;
        private double r;
        private double length;
        private double area;

        public Round()
        {
            this.CoordX = 0;
            this.CoordY = 0;
            this.R = 10;
            count++;
        }

        public Round(int coordX, int coordY, int r)
        {
            this.CoordX = coordX;
            this.CoordY = coordY;
            this.R = r;
            this.area = this.Area;
            this.length = this.Length;
            count++;
        }

        public static int Count { get; }

        public int CoordX { get; set; }

        public int CoordY { get; set; }

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

        public double Area
        {
            get
            {
                if (this.area == 0)
                {
                    this.area = Math.PI * this.r * this.r;
                }

                return this.area;
            }
        }

        public override void Print()
        {
            Console.WriteLine($"Figure - Round, Coordinates: X- {CoordX}, Y- {CoordY}," +
                $"Area - {area}, Length - {length}, radius - {r}");
        }
    }
}
