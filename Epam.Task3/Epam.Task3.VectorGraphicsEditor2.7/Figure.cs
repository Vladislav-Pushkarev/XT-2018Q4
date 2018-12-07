using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor2._7
{
    public abstract class Figure
    {
        private int coordX;
        private int coordY;

        protected int CoordX { get; set; }

        protected int CoordY { get; set; }

        public abstract void Print();
    }
}
