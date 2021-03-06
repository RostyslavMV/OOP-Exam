﻿using System;
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
        public Collection<HashNode<TKey, TValue>> hashTable { get; private set; }

        public QuadraticHashTable(int numberOfCells)
        {
            hashTable = new Collection<HashNode<TKey, TValue>>();
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
                    if (EqualityComparer<TKey>.Default.Equals(node.Key, hashTable[index].Key))
                    {
                        hashTable[index].Value = node.Value;
                        return;
                    }
                    index = GetHash(node.Key, i);
                    if (hashTable[index] == null)
                    {
                        hashTable[index] = node;
                        return;
                    }
                }
            }
        }

        protected int GetHash(TKey key, int i)
        {
            return (key.GetHashCode() + i * i) % NumberOfCells;
        }

        public override Collection<KeyValuePair<TKey, TValue>> ToCollection()
        {
            Collection<KeyValuePair<TKey, TValue>> collection = new Collection<KeyValuePair<TKey, TValue>>();
            for (int i = 0; i < NumberOfCells; i++)
            {
                if (hashTable[i]!=null)
                collection.Add(new KeyValuePair<TKey, TValue>(hashTable[i].Key, hashTable[i].Value));
            }
            return collection;
        }
    }
}
