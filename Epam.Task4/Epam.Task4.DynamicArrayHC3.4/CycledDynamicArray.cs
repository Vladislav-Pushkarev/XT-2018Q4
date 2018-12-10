using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.DynamicArrayHC3._4
{
    public class CycledDynamicArray<T> : DynamicArray<T>
    {
        public new IEnumerator<T> GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator<T>(this);
        }
    }
}
