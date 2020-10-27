using System;

namespace Basic
{
    public class ArrayQueue<T>
    {
        private readonly int _baseSize;
        private int _totalItemCount;
        private readonly T[] _array;
        private int _head;
        private int _tail;
    
        public ArrayQueue(int size)
        {
            this._baseSize = size;
            this._head = this._tail = this._totalItemCount = 0;
            this._array = new T[this._baseSize];
        }
    
        public void Enqueue(T item)
        {
            if (this._totalItemCount == this._baseSize)
                throw new InvalidOperationException("Invalid Operation");
    
            this._array[this._tail++ % this._baseSize] = item;
            ++this._totalItemCount;
        }
    
        public T DeQueue()
        {
            if (this._totalItemCount == 0)
                throw new InvalidOperationException("Invalid Operation");
    
            var result = this._array[this._head++ % this._baseSize];
            --this._totalItemCount;
            return result;
        }
    }
}