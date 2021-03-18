using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson2ClassWork
{
    class ArrayBasedList<T> : IEnumerable<T>
    {
        //class constant
        private const int DEFAULT_INITIAL_CAPACITY = 10;

        // fields
        private T[] _array;
        private int _count;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }

            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }

        //properties
        public int Count
        {
            get { return this._count; }
            private set
            {
                this._count = value;
            }
        }
        public ArrayBasedList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException("Capacity must be Positive!");
            this._array = new T[capacity];
            this.Count = 0;
        }

        public ArrayBasedList() : this(DEFAULT_INITIAL_CAPACITY) { }

        // instance methods
        public void Add(T item)
        {
            GrowIfNecessary();
            this._array[this.Count] = item;
            this.Count++;
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) == 1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this._array.Length; i++)
            {
                if (item.Equals(this._array[i]))
                    return i;
            }
            return -1;
        }

        public void Insert(T item, int index)
        {
            if (index < 0 || index > this.Count)
                throw new IndexOutOfRangeException();
            GrowIfNecessary();
            Array.Copy(this._array, index, this._array, index + 1, this.Count - index);
            this._array[index] = item;
        }

        public void Remove(T item)
        {
            int index = IndexOf(item);
            if (index > -1)
                RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            Array.Copy(this._array, index, this._array, index - 1, this.Count - index);
            Count--;
        }

        private void GrowIfNecessary()
        {
            if (this._count == this._array.Length)
            {
                this.Grow();
            }
        }
        private void Grow()
        {
            T[] copy = new T[this._array.Length * 2];
            Array.Copy(this._array, copy, this._array.Length);
            this._array = copy;
        }

        public IEnumerator<T> GetEnumerator() // does the work
        {
            //return ((IEnumerable<T>)array).GetEnumerator();
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            string s = "[";
            if (this._count > 0)
            {
                s += _array[0].ToString();
                if (this._count > 1)
                {
                    for (int i = 1; i < this._count; i++)
                    {
                        s += (", " + _array[i].ToString());
                    }
                    s += "]";
                }
            }
            return s;
        }
    }
}
