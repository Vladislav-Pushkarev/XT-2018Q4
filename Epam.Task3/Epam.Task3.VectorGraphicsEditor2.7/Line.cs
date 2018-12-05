using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor2._7
{
    public class Line : Figure
    {
        private double length;

        public override void Print()
        {
            Console.WriteLine($"Figure - Line, Coordinates: X- {CoordX}, Y- {CoordY}," +
            $"Length - {length}");
        }
    }
}
