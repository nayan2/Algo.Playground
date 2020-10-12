using System;

namespace Basic
{
    public class PriorityQueue<T> where T : IComparable
    {
        private int _count;
        private readonly T[] _array;

        public PriorityQueue(int size)
        {
            this._count = 0;
            this._array = new T[size];
        }

        public void Enqueue(T item)
        {
            if (this._count == this._array.Length) throw new InvalidOperationException();

            this._count++;
            for (var i = this._count - 1; i >= 0; i--)
            {
                if (this._array[i].CompareTo(item) > 0)
                    this._array[i + 1] = this._array[i];
                else
                {
                    this._array[i] = item;
                    break;
                }
            }
        }

        public T Dequeue()
        {
            this._array[--this._count] = default(T);
            return this._array[this._count];
        }
    }
}