using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.Lost3._1
{
    public class Person
    {
        private int index;

        public Person(int index)
        {
            this.index = index;
        }

        public int Index { get => index; set => index = value; }
    }
}
