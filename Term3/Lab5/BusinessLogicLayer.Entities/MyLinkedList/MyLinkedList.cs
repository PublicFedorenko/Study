using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities.MyLinkedList
{
    public class MyLinkedList<T> : ICollection<T>
    {
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }
        public int Count { get; set; }
        public bool IsReadOnly { get; set; }

        public MyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        public T this[int index]
        {
            get
            {
                if (Head == null)
                    throw new InvalidOperationException();
                if (index < 0 || index > Count - 1)
                    throw new IndexOutOfRangeException();

                Node<T> curr = Head;
                int i = 0;
                while (i++ != index)
                    curr = curr.Next;
                return curr.Value;
            }
            set
            {
                if (Head == null)
                    throw new InvalidOperationException();
                if (index < 0 || index > Count - 1)
                    throw new IndexOutOfRangeException();


            }
        }

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);
            Count++;
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            Tail.Next = node;
            node.Prev = Tail;
            Tail = node;
        }

        public void Insert(int index, T item)
        {
            if (Head == null && index == 0)
            {
                Add(item);
                return;
            }

            if (index < 0 || index > Count - 1)
                throw new IndexOutOfRangeException();

            Node<T> curr = Head;
            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    Node<T> node = new Node<T>(item);
                    if (curr.Prev != null)
                        curr.Prev.Next = node;
                    node.Prev = curr.Prev;
                    curr.Prev = node;
                    node.Next = curr;
                    Count++;
                    return;
                }
                curr = curr.Next;
            }
        }

        public bool Remove(T item)
        {
            if (Head == null)
                throw new InvalidOperationException();

            Node<T> curr = Head;
            while (curr != null)
            {
                if (curr.Value.Equals(item))
                {
                    if (curr.Prev != null)
                        curr.Prev.Next = curr.Next;
                    if (curr.Next != null)
                        curr.Next.Prev = curr.Prev;
                    Count--;
                    return true;
                }
                curr = curr.Next;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (Head == null)
                throw new InvalidOperationException();
            if (index < 0 || index > Count - 1)
                throw new IndexOutOfRangeException();

            Node<T> curr = Head;
            int i = 0;
            while (curr != null)
            {
                if (i == index)
                {
                    if (curr.Prev != null)
                        curr.Prev.Next = curr.Next;
                    if (curr.Next != null)
                        curr.Next.Prev = curr.Prev;
                    Count--;
                    return;
                }
                curr = curr.Next;
                i++;
            }
        }

        public void Clear()
        {
            if (IsReadOnly)
                throw new NotSupportedException();

            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            Node<T> curr = Head;
            while (curr != null)
            {
                if (curr.Value.Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentOutOfRangeException();
            if (arrayIndex < 0 || arrayIndex > array.Length - 1)
                throw new IndexOutOfRangeException();
            if (Count > array.Length - arrayIndex)
                throw new ArgumentException();

            int index = arrayIndex;
            while (index < array.Length)
            {
                array[index] = this[index];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (Node<T> curr = Head; curr != null; curr = curr.Next)
                yield return curr.Value;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
