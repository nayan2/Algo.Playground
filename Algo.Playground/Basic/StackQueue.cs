using System;
using System.Collections.Generic;

namespace Basic
{
    public class StackQueue<T> where T: IComparable
    {
        private readonly int _baseSize;
        private int _totalItemCount;
        private readonly Stack<T> _stack;
        private readonly Stack<T> _reverseStack;
        
        public StackQueue(int size)
        {
            this._baseSize = size;
            this._totalItemCount = 0;
            _stack = new Stack<T>(_baseSize);
            _reverseStack = new Stack<T>(_baseSize);
        }
    
        public void Enqueue(T item)
        {
            if (this._totalItemCount == this._baseSize)
                throw new InvalidOperationException();
            
            this._stack.Push(item);
            this._totalItemCount++;
        }
    
        public T Dequeue()
        {
            if (this._totalItemCount <= 0)
                throw new InvalidOperationException();
            
            if(this._reverseStack.Count == 0)
                this.ReverseStack(this._stack, this._reverseStack);
    
            this._totalItemCount--;
            return this._reverseStack.Pop();
        }
    
        private void ReverseStack(Stack<T> source, Stack<T> destination)
        {
            while (source.Count > 0) 
                destination.Push(source.Pop());
        }
    }
}