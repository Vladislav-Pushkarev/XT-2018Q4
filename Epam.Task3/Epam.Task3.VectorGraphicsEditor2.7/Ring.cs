using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor2._7
{
    public class Ring : Figure
    {
        private Round innerRound;
        private Round outerRound;

        public Ring()
        {
            this.CoordX = 0;
            this.CoordY = 0;
            int radiusInner = 5;
            int radiusOuter = 10;
            this.innerRound = new Round(CoordX, CoordY, radiusInner);
            this.outerRound = new Round(CoordX, CoordY, radiusOuter);
        }

        public Ring(int coordX, int coordY, int radiusInner, int radiusOuter)
        {
            if (radiusOuter > radiusInner)
            {
                this.innerRound = new Round(coordX, coordY, radiusInner);
                this.outerRound = new Round(coordX, coordY, radiusOuter);
            }
            else
            {
                throw new ArgumentException("Outer radius cannot be smaller or equal to inner radius");
            }
        }

        public Round InnerRound { get; }

        public Round OuterRound { get; }

        public double Length
        {
            get
            {
                return this.innerRound.Length() + this.outerRound.Length();
            }
        }

        internal double Area
        {
            get
            {
                return this.outerRound.Area() - this.innerRound.Area();
            }
        }

        public override void Print()
        {
           Console.WriteLine($"Figure - Ring, Coordinates: X- {CoordX}, Y- {CoordY}," +
               $"Area - {Area}, Length - {Length}");
        }
    }
}
