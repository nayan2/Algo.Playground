using System;

namespace Basic.HashMap
{
    public class MyKeyValuePair<TK, TV>: IComparable
    {
        public MyKeyValuePair(TK key, TV value)
        {
            this.Key = key;
            this.Value = value;
        }

        public TK Key { get; set; }
        public TV Value { get; set; }
        
        public int CompareTo(object? obj)
        {
            return obj is MyKeyValuePair<TK, TV> pair && pair.CompareTo(obj) > 0 ? 1 : 0;
        }
    }
}