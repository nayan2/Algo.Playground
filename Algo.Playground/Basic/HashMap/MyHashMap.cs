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
            var index = this.GetHash(key);
            this._bucket[index] ??= new LinkedList<KeyValuePair<int, string>>();
            var bucket = this._bucket[index];
            var result = this._bucket[index].FirstOrDefault(x => x.Key == key);

            if (!result.Equals(default(KeyValuePair<int, string>)))
                bucket.Remove(result);
            
            bucket.AddLast(new KeyValuePair<int, string>(key, value));
        }

        public string Get(int key)
        {
            var index = this.GetHash(key);
            if(this._bucket[index] == null)
                throw new InvalidOperationException("No such key found");
            
            var result = this._bucket[index].FirstOrDefault(x => x.Key == key);
            if (result.Equals(default(KeyValuePair<int, string>)))
                throw new InvalidOperationException("No such key found");

            return result.Value;
        }

        public bool Delete(int key)
        {
            var index = this.GetHash(key);
            var bucket = this._bucket[index];

            if (bucket == null)
                throw new InvalidOperationException("No suck key found");

            var result = bucket.FirstOrDefault(x => x.Key == key);
            if (result.Equals(default(KeyValuePair<int, string>)))
                throw new InvalidOperationException("No such key found");

            return bucket.Remove(result);
        }

        private int GetHash(int key)
        {
            return key % _intiSize;
        }
    }
}