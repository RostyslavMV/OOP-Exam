using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam
{
    public class HashNode<TKey, TValue>
    {
        public TKey Key { get; private set; }

        public TValue Value { get; set; }
        public HashNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    public abstract class HashTable<TKey, TValue>
    {
        public abstract TValue Get(TKey key);
        public void Add(TKey key, TValue value)
        {
            Add(new HashNode<TKey, TValue>(key, value));
        }

        public abstract TValue Remove(TKey key);
        protected abstract void Add(HashNode<TKey, TValue> node);
        protected abstract int GetHash(TKey key);
    }
}
