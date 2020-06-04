using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Exam
{
    public class QuadraticHashTable<TKey, TValue> : HashTable<TKey, TValue>
    {
        private Collection<HashNode<TKey, TValue>> hashTable = new Collection<HashNode<TKey, TValue>>();

        public QuadraticHashTable(int numberOfCells)
        {
            NumberOfCells = numberOfCells;
            for (int i = 0; i < NumberOfCells; i++)
            {
                hashTable.Add(null);
            }
        }
        public QuadraticHashTable() : this(100) { }

        public override TValue Get(TKey key)
        {
            for (int i = 0; i < NumberOfCells*10; i++)
            {
                var index = GetHash(key, i);
                var element = hashTable[GetHash(key, i)];
                if (element!=null&& EqualityComparer<TKey>.Default.Equals(key, element.Key))
                {
                    return element.Value;
                }
            }
            return default;
        }

        public override TValue Remove(TKey key)
        {
            for (int i =0; i < NumberOfCells*10; i++)
            {
                var index = GetHash(key, i);
                var element = hashTable[GetHash(key, i)];
                if (EqualityComparer<TKey>.Default.Equals(key, element.Key))
                {
                    hashTable[index] = null;
                    return element.Value;
                }                  
            }
            return default;
        }

        protected override void Add(HashNode<TKey, TValue> node)
        {
            int index = GetHash(node.Key);
            if (hashTable[index] == null)
                hashTable[index] = node;
            else
            {
                for (int i = 1; i < NumberOfCells*10; i++)
                {
                    index = GetHash(node.Key, i);
                    if (hashTable[index] == null)
                    {
                        hashTable[index] = node;
                        return;
                    }
                }
            }
        }

        protected override int GetHash(TKey key)
        {
            return key.GetHashCode() % NumberOfCells;
        }
        protected int GetHash(TKey key, int i)
        {
            return (key.GetHashCode() + i * i) % NumberOfCells;
        }
    }
}
