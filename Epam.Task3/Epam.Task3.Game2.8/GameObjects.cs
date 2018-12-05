using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Game2._8
{
    public abstract class GameObjects
    {
        private int height;
        private int width;

        public int Height { get => this.width; set => this.width = value; }

        public int Width { get => this.width; set => this.width = value; }
    }
}
