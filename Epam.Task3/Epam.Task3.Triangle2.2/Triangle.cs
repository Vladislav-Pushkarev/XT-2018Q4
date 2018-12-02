using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Triangle2._2
{
    public class Triangle
    {
        private static int count;
        private double sideA;
        private double sideB;
        private double sideC;
        private double perimeter;
        private double area;

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (IsExist(sideA, sideB, sideC))
            {
                this.SideA = sideA;
                this.SideB = sideB;
                this.SideC = sideC;
                count++;
            }
            else
            {
                throw new ArgumentException("One of triangle sides should be bigger than sum of two other.");
            }
        }

        public static int Count { get => count; }

        public double SideA
        {
            get
            {
                return this.sideA;
            }

            set
            {
                if (value > 0 && IsExist(value, this.sideB, this.sideC))
                {
                    this.sideA = value;
                }
                else
                {
                    throw new ArgumentException("Triangle side cannot be negative, " +
                        "and one of triangle sides should be bigger than sum of other two.");
                }
            }
        }

        public double SideB
        {
            get
            {
                return this.sideB;
            }

            set
            {
                if (value > 0 && IsExist(this.sideA, value, this.sideC))
                {
                    this.sideB = value;
                }
                else
                {
                    throw new ArgumentException("Triangle side cannot be negative, " +
                        "and one of triangle sides should be bigger than sum of other two.");
                }
            }
        }

        public double SideC
        {
            get
            {
                return this.sideC;
            }

            set
            {
                if (value > 0 && IsExist(this.sideA, this.sideB, value))
                {
                    this.sideC = value;
                }
                else
                {
                    throw new ArgumentException("Triangle side cannot be negative, " +
                        "and one of triangle sides should be bigger than sum of other two.");
                }
            }
        }

        public double Perimeter()
        {
            if (this.perimeter == 0)
            {
                this.perimeter = this.sideA + this.sideB + this.sideC;
            }

            return this.perimeter;
        }

        public double Area()
        {
            if (this.area == 0)
            {
                double halfP = this.Perimeter() / 2;
                this.area = Math.Sqrt(halfP * (halfP - this.sideA) * (halfP - this.sideB) * (halfP - this.sideC));
                return this.area;
            }

            return this.area;
        }

        private static bool IsExist(double sideA, double sideB, double sideC)
        {
            if (sideA > sideB + sideC || sideB > sideA + sideC || sideC > sideB + sideA)
            {
                return true;
            }

            return false;
        }
    }
}
