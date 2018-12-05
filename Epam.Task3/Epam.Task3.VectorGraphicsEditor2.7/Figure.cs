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

        protected int CoordX { get => this.coordX; set => this.coordX = value; }

        protected int CoordY { get => this.coordY; set => this.coordY = value; }

        public abstract void Print();
    }
}
