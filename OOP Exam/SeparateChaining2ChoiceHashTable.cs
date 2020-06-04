using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OOP_Exam
{
    public class SeparateChaining2ChoiceHashTable<TKey, TValue> : HashTable<TKey, TValue>
    {
        private Collection<Collection<HashNode<TKey, TValue>>> hashTable = new Collection<Collection<HashNode<TKey, TValue>>>();

        public SeparateChaining2ChoiceHashTable(int numberOfCells)
        {
            NumberOfCells = numberOfCells;
            for (int i = 0; i < NumberOfCells; i++)
            {
                hashTable.Add(new Collection<HashNode<TKey, TValue>>());
            }
        }

        public SeparateChaining2ChoiceHashTable() : this(100) { }
        public override TValue Get(TKey key)
        {
            int index1 = GetHash(key);
            int index2 = GetHash(key);
            if (hashTable[index1].Count == 1 && EqualityComparer<TKey>.Default.Equals(key, hashTable[index1][0].Key))
            {
                return hashTable[index1][0].Value;
            }
            if (hashTable[index2].Count == 1 && EqualityComparer<TKey>.Default.Equals(key, hashTable[index2][0].Key))
            {
                return hashTable[index2][0].Value;
            }
            if (hashTable[index1].Count < hashTable[index2].Count)
            {
                foreach (HashNode<TKey, TValue> node in hashTable[index1])
                {
                    if (EqualityComparer<TKey>.Default.Equals(key, node.Key))
                        return node.Value;
                }
            }
            else
            {
                foreach (HashNode<TKey, TValue> node in hashTable[index2])
                {
                    if (EqualityComparer<TKey>.Default.Equals(key, node.Key))
                        return node.Value;
                }
            }
            return default;
        }

        public override TValue Remove(TKey key)
        {
            int index1 = GetHash(key);
            int index2 = GetHash(key);
            if (hashTable[index1].Count == 1 && EqualityComparer<TKey>.Default.Equals(key, hashTable[index1][0].Key))
            {
                var element = hashTable[index1][0];
                hashTable[index1].RemoveAt(0);
                return element.Value;
            }
            if (hashTable[index2].Count == 1 && EqualityComparer<TKey>.Default.Equals(key, hashTable[index2][0].Key))
            {
                var element = hashTable[index2][0];
                hashTable[index2].RemoveAt(0);
                return element.Value;
            }
            if (hashTable[index1].Count < hashTable[index2].Count)
            {
                foreach (HashNode<TKey, TValue> node in hashTable[index1])
                {
                    var element = node;
                    if (EqualityComparer<TKey>.Default.Equals(key, node.Key))
                    {
                        hashTable[index1].Remove(node);
                        return element.Value;
                    }

                }
            }
            else
            {
                foreach (HashNode<TKey, TValue> node in hashTable[index2])
                {
                    var element = node;
                    {
                        hashTable[index2].Remove(node);
                        return element.Value;
                    }
                }
            }
            return default;
        }

        protected override void Add(HashNode<TKey, TValue> node)
        {
            int index1 = GetHash(node.Key);
            int index2 = GetHash(node.Key);
            foreach (HashNode<TKey, TValue> element in hashTable[index1])
            {
                if (EqualityComparer<TKey>.Default.Equals(element.Key, node.Key))
                {
                    element.Value = node.Value;
                    return;
                }
            }
            foreach (HashNode<TKey, TValue> element in hashTable[index2])
            {
                if (EqualityComparer<TKey>.Default.Equals(element.Key, node.Key))
                {
                    element.Value = node.Value;
                    return;
                }
            }
            if (hashTable[index1].Count <= hashTable[index2].Count)
            {
                hashTable[index1].Add(node);
            }
            else
            {
                hashTable[index2].Add(node);
            }
        }
        protected int GetHash2(TKey key)
        {
            return 2 * key.GetHashCode() % NumberOfCells;
        }
    }
}
