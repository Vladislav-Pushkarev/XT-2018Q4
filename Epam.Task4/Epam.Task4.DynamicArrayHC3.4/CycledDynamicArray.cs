using System.Collections.Generic;

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
