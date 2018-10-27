using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    public class DynamicArray<T>
    {
        private T[] data;
        private int size;
        private int capasity;
        private int growthFactor;
        private readonly int defaultCapasity = 5;

        public int Size { get => size; set => size = value; }

        public DynamicArray()
        {
            size = 0;
            capasity = defaultCapasity;
            growthFactor = 2;
            data = new T[capasity];
        }

        public T this[int index]
        {
            get => data[index];
            set => Add(value, index);
        }

        public void Add(T val)
        {
            EnsureCapasity(size + 1);
            data[size++] = val;
        }

        public void Add(T val, int index)
        {
            if (index < 0 || index > size)
                throw new IndexOutOfRangeException();
            if (size == index)
            {
                Add(val);
                return;
            }

            EnsureCapasity(size + 1);
            T[] newArray = new T[capasity];
            for (int i = 0, j = 0; i < size + 1; i++)
            {
                if (i == index)
                    newArray[i++] = val;
                newArray[i] = data[j++];
            }
            size++;
            data = newArray;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > size - 1)
                throw new IndexOutOfRangeException();

            T[] newArray = new T[capasity];
            for (int i = 0, j = 0; i < size; i++)
            {
                if (i != index)
                    newArray[j++] = data[i];
            }
            size--;
            data = newArray;
        }

        private void EnsureCapasity(int requiredSize)
        {
            if (requiredSize <= capasity)
                return;

            while (capasity < requiredSize)
                capasity *= growthFactor;
            T[] increasedArray = new T[capasity];
            data.CopyTo(increasedArray, 0);
            data = increasedArray;
        }

        public void Clear()
        {
            size = 0;
            capasity = defaultCapasity;
            data = null;
        }
    }
}
