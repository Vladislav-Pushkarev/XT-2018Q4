using System;
using System.Collections;
using System.Collections.Generic;

namespace Epam.Task4.DynamicArrayHC3._4
{
        internal class CycledDynamicArrayEnumerator<T> : IEnumerator<T>, IEnumerator
        {
            private DynamicArray<T> dynamicArray;
            private int cursor = -1;

            public CycledDynamicArrayEnumerator(CycledDynamicArray<T> dynamicArray)
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
                }
                else
                {
                    this.cursor = 0;
                }

                return true;
            }

            public void Reset()
            {
                this.cursor = -1;
            }
        }
    }