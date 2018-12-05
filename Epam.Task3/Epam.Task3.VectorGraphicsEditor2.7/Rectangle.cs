using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor2._7
{
    public class Rectangle : Figure
    {
        private int sideA;
        private int sideB;

        public Rectangle()
        {
            this.CoordX = 0;
            this.CoordY = 0;
            this.sideA = 4;
            this.sideB = 5;
        }

        public override void Print()
        {
            Console.WriteLine($"Figure - Rectangle, Coordinates: X- {CoordX}, Y- {CoordY}," +
              $"Side A - {sideA}, Side B - {sideB}");
        }
    }
}
