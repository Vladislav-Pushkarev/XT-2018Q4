using System;
using System.Collections;
using System.Collections.Generic;

namespace Epam.Task4.DynamicArray3._3
{
    internal class DynamicArrayEnumerator<T> : IEnumerator<T>, IEnumerator
    {
        private DynamicArray<T> dynamicArray;
        private int cursor = -1;

        public DynamicArrayEnumerator(DynamicArray<T> dynamicArray)
        {
            this.dynamicArray = dynamicArray;
        }

        public object Current
        {
            get
            {
                if (this.cursor == -1 || this.cursor >= this.dynamicArray.Length)
                {
                    throw new InvalidOperationException();
                }

                return this.dynamicArray[this.cursor];
            }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                if (this.cursor == -1 || this.cursor >= this.dynamicArray.Length)
                {
                    throw new InvalidOperationException();
                }

                return this.dynamicArray[this.cursor];
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.cursor < this.dynamicArray.Length - 1)
            {
                this.cursor++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.cursor = -1;
        }
    }
}