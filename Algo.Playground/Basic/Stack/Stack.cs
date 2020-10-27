using System;
using System.Linq;

namespace Basic.Stack
{
    public class Stack<T> where T : IComparable
    {
        private int _currentIndex;
        private readonly T[] _arr;

        public Stack()
        {
            _currentIndex = 0;
            _arr = new T[100];
        }

        public void Push(T value)
        {
            _arr[_currentIndex++] = value;
        }

        public T Pop()
        {
            return _arr[--_currentIndex];
        }

        public override string ToString()
        {
            return _arr.Aggregate(string.Empty, (x, y) => x.ToString() + ", " + y);
        }
    }
}