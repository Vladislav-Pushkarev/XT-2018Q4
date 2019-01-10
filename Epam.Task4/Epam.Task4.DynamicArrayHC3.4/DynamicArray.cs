using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Task4.DynamicArrayHC3._4
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {
        private int size;
        private T[] array;

        public DynamicArray()
        {
            this.array = new T[8];
            this.size = 0;
        }

        public DynamicArray(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"Illegal Capacity {capacity}");
            }

            this.array = new T[capacity];
            this.size = 0;
        }

        public DynamicArray(IEnumerable<T> c)
        {
            if (c == null)
            {
                throw new ArgumentNullException();
            }

            int count = c.Count();
            if (count == 0)
            {
                this.array = new T[8];
            }
            else
            {
                this.array = new T[count];
                int index = 0;
                foreach (var value in c)
                {
                    this.array[index] = value;
                    index++;
                    this.size++;
                }
            }
        }

        public int Length { get => this.size; }

        public int Capacity
        {
            get
            {
                return this.array.Length;
            }

            set
            {
                this.CapacityChange(value);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.size || index < -this.size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (index > -1)
                {
                    return this.array[index];
                }

                return this.array[this.size + index];
            }

            set
            {
                if (index >= this.size || index < -this.size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (index < 0)
                {
                    this.array[this.size + index] = value;
                }

                this.array[index] = value;
            }
        }

        public void Add(T t)
        {
            this.CheckAndExtend();
            this.array[this.size] = t;
            this.size++;
        }

        public void AddRange(IEnumerable<T> c)
        {
            if (c == null)
            {
                throw new ArgumentNullException();
            }

            int count = c.Count();
            this.CheckAndExtend(count);

            foreach (var item in c)
            {
               this.array[this.size] = item;
               this.size++;
            }
        }

        public bool Remove(T o)
        {
            if (o == null)
            {
                for (int i = 0; i < this.size; i++)
                {
                    if (this.array[i] == null)
                    {
                        this.RemoveAtIndex(i);
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.size; i++)
                {
                    if (o.Equals(this.array[i]))
                    {
                        this.RemoveAtIndex(i);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Insert(int index, T t)
        {
            if (index < 0 || index > this.size)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.CheckAndExtend();
            for (int i = this.size; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            this.array[index] = t;
            this.size++;
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }

        public T[] ToArray()
        {
            T[] simpleArr = new T[this.size];
            for (int i = 0; i < simpleArr.Length; i++)
            {
                simpleArr[i] = this.array[i];
            }

            return simpleArr;
        }

        public object Clone()
        {
            var newArr = new DynamicArray<T>(this);
            newArr.Capacity = this.Capacity;
            return newArr;
        }

        public override string ToString()
        {
            return $"Capacity - {Capacity}, items in array - {Length}";
        }

        private void CapacityChange(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (value == 0)
            {
                this.array = new T[0];
                this.size = 0;
            }
            else
            {
                if (value > 0)
                {
                    int limit = value < this.size ? value : this.size;
                    T[] newArr = new T[value];
                    this.size = limit;
                    for (int i = 0; i < limit; i++)
                    {
                        newArr[i] = this.array[i];
                    }

                    this.array = newArr;
                }
            }
        }

        private void RemoveAtIndex(int index)
        {
            this.array[index] = default(T);
            for (int i = index; i < this.size - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.size--;
        }

        private void CheckAndExtend(int count)
        {
            int arrayCapacity = this.array.Length;
            int multiplier = 2;
            int newCap = arrayCapacity;
            while (count > newCap - this.size)
            {
                newCap = arrayCapacity * multiplier;
                multiplier += 2;
            }

            T[] tempArray = this.array;
            this.array = new T[newCap];
            for (int i = 0; i < arrayCapacity; i++)
            {
                this.array[i] = tempArray[i];
            }
        }

        private void CheckAndExtend()
        {
            int arrayCapacity = this.array.Length;
            if (this.size == arrayCapacity)
            {
                T[] tempArray = this.array;
                this.array = new T[arrayCapacity * 2];
                for (int i = 0; i < arrayCapacity; i++)
                {
                    this.array[i] = tempArray[i];
                }
            }
        }
    }
}