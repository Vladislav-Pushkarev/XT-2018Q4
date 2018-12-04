using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Ring2._6
{
    public class Round
    {
        private static int count;
        private int coordX;
        private int coordY;
        private double r;
        private double length;
        private double area;

        public Round(int coordX, int coordY, int r)
        {
            this.CoordX = coordX;
            this.CoordY = coordY;
            this.R = r;
            count++;
        }

        public static int Count { get => count; }

        public int CoordX { get => this.coordX; set => this.coordX = value; }

        public int CoordY { get => this.coordY; set => this.coordY = value; }

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

        public double Length()
        {
            if (this.length == 0)
            {
                this.length = 2 * Math.PI * this.r;
            }

            return this.length;
        }

        public double Area()
        {
            if (this.area == 0)
            {
                this.area = Math.PI * this.r * this.r;
            }

            return this.area;
        }
    }
}
