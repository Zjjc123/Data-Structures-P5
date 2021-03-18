using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson3ClassWork
{
    class NodeBasedList<T> : IEnumerable<T>
    {
        // fields
        private Node _head;
        private Node _tail;
        private int _count;

        // properties
        public int Count
        {
            get { return this._count; }
            private set
            {
                this._count = value;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                Node curr = this._head;
                for (int i = 0; i < index; i++)
                {
                    curr = curr.Next;
                }
                return curr.Element;
            }

            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                Node curr = this._head;
                for (int i = 0; i < index; i++)
                {
                    curr = curr.Next;
                }
                curr.Element = value;
            }
        }

        // constructor
        public NodeBasedList()
        {
            this._head = null;
            this._tail = null;
            this._count = 0;
        }

        // instance methods
        public void Add (T item)
        {
            Node n = new Node(item);
            if (this.Count == 0)
            {
                this._head = n;
                this._tail = n;
            }
            else
            {
                this._tail.Next = n;
                this._tail = n;
            }
            this.Count++;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            Node prev = this._head;
            for (int i = 0; i < index - 1; i ++)
            {
                prev = prev.Next;
            }

            Node n = new Node(item, prev.Next == null ? null : prev.Next);

            if (index == 0)
            {
                this._head = n;
            }
            else
            {
                prev.Next = n;
            }
        }

        public void Clear()
        {
            this._head = null;
            this._tail = null;
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            int index = 0;
            Node curr = this._head;
            while (curr != null)
            {
                if (curr.Element.Equals(item))
                {
                    return index;
                }
                curr = curr.Next;
                index++;
            }
            return -1;
        }

        public int Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index != -1)
            {
                this.RemoveAt(index);
            }
            return index;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            Node prev = null;
            Node curr = this._head;
            for (int i = 0; i < index - 1; i++)
            {
                prev = curr;
                curr = curr.Next;
            }
            if (this.Count == 0)
            {
                this.Clear();
            }
            else if (index == 0)
            {
                this._head = curr.Next;
                curr.Next = null;
            }
            else
            {
                prev.Next = curr.Next;
            }

            if (index == Count)
            {
                this._tail = prev;
            }
            this.Count--;
            return curr.Element;
        }

        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            // constructors
            public Node(T Element, Node next)
            {
                this.Element = Element;
                this.Next = Next;
            }

            public Node(T element) : this(element, null) { }
        }

        public override string ToString()
        {
            String s = "[";
            if (this.Count > 0)
            {
                s += this._head.Element.ToString();
                Node curr = this._head.Next;
                while (curr != null)
                {
                    s += ", " + curr.Element.ToString();
                    curr = curr.Next;
                }
            }
            s += "]";
            return s;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node curr = this._head;
            while (curr != null)
            {
                yield return curr.Element;
                curr = curr.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
