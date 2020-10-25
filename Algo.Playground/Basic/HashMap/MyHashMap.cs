using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic.HashMap
{
    // var hashMap = new MyHashMap();
    // hashMap.Put(3, "nayan");
    // hashMap.Put(3, "nayanUpdated");
    // hashMap.Put(103, "nayan1");
    // hashMap.Put(4, "kamal");
    // hashMap.Put(5, "jamal");
    //
    // var res1 = hashMap.Get(3);
    // var res2 = hashMap.Delete(3);
    public class MyHashMap
    {
        private readonly int _intiSize;
        private readonly LinkedList<KeyValuePair<int, string>>[] _bucket;

        public MyHashMap()
        {
            this._intiSize = 100;
            this._bucket = new LinkedList<KeyValuePair<int, string>>[this._intiSize];
        }

        public void Put(int key, string value)
        {
            var bucket = this.GetOrCreateCurrentKeyBucket(key);
            var pair = this.GetPair(key);

            if (!this.IsDefaultPair(pair))
                bucket.Remove(pair);
            
            bucket.AddLast(new KeyValuePair<int, string>(key, value));
        }

        public string Get(int key)
        {
            var pair = this.GetPair(key);
            if(this.IsDefaultPair(pair))
                throw new InvalidOperationException("No such key found");

            return pair.Value;
        }

        public bool Delete(int key)
        {
            var pair = this.GetPair(key);
            if (this.IsDefaultPair(pair))
                throw new InvalidOperationException("No suck key found");
            
            var bucket = this.GetOrCreateCurrentKeyBucket(key);
            return bucket.Remove(pair);
        }

        private KeyValuePair<int, string> GetPair(int key)
        {
            var index = this.GetHash(key);
            return this._bucket[index] == null ?
                default(KeyValuePair<int, string>) :
                this._bucket[index].FirstOrDefault(x => x.Key == key);
        }

        private LinkedList<KeyValuePair<int, string>> GetOrCreateCurrentKeyBucket(int key)
        {
            var index = this.GetHash(key);
            return this._bucket[index] ??= new LinkedList<KeyValuePair<int, string>>();
        }

        private bool IsDefaultPair(KeyValuePair<int, string> pair)
        {
            return pair.Equals(default(KeyValuePair<int, string>));
        }

        private int GetHash(int key)
        {
            return key % _intiSize;
        }
    }
}