using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Ring2._6
{
    class Ring
    {
        private Round innerRound;
        private Round outerRound;
        private double lenght;

        public Ring(double coordX, double coordY, double rInner, double rOuter)
        {
            if (rOuter > rInner)
            {
                this.InnerRound = new Round(coordX, coordYy, rInner);
                this.OuterRound = new Round(coordX, coordYy, rOuter);
            }
            else
            {
                throw new ArgumentException("Outer radius cannot be smoller or equal to inner radius");
            }
        }

        public Round InnerRound { get; }

        public Round OuterRound { get; }

        public double Length
        {
           get 
           {
                return this.innerRound() + this.outerRound.Length();
           }
        }

        internal double Area
        {
             get 
           {
                this.outerRound.Area - this.innerRound.Area;
           }
        }
    }
}
