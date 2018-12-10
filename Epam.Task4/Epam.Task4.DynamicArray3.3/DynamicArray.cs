﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4.DynamicArray3._3
{
    public sealed class DynamicArray<T> : IEnumerable<T>, IEnumerable
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

        public int Capacity { get => this.array.Length; }

        public T this[int index]
        {
            get
            {
                if (index == -1 || index >= this.size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.array[index];
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

        public void RemoveAtIndex(int index)
        {
            this.array[index] = default(T);
            for (int i = index; i < this.size - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.size--;
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

        public override string ToString()
        {
            return $"Capacity - {Capacity}, items in array - {Length}";
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