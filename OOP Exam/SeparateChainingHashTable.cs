using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OOP_Exam
{
    public class SeparateChainingHashTable<TKey, TValue> : HashTable<TKey, TValue>
    {
        private Collection<Collection<HashNode<TKey, TValue>>> hashTable = new Collection<Collection<HashNode<TKey, TValue>>>();

        public SeparateChainingHashTable(int numberOfCells)
        {
            NumberOfCells = numberOfCells;
            for (int i = 0; i < NumberOfCells; i++)
            {
                hashTable.Add(new Collection<HashNode<TKey, TValue>>());
            }
        }

        public SeparateChainingHashTable() : this(100) { }

        protected override void Add(HashNode<TKey, TValue> node)
        {
            int index = GetHash(node.Key);
            foreach (HashNode<TKey, TValue> element in hashTable[index])
            {
                if (EqualityComparer<TKey>.Default.Equals(element.Key, node.Key))
                {
                    element.Value = node.Value;
                    return;
                }
            }
            hashTable[index].Add(node);
        }

        public override TValue Get(TKey key)
        {
            int index = GetHash(key);
            if (hashTable[index].Count == 1)
            {
                return hashTable[index][0].Value;
            }
            else
            {
                foreach (HashNode<TKey, TValue> node in hashTable[index])
                {
                    if (EqualityComparer<TKey>.Default.Equals(key, node.Key))
                        return node.Value;
                }
            }
            return default;
        }

        public override TValue Remove(TKey key)
        {
            int index = GetHash(key);
            if (hashTable[index].Count == 1)
            {
                var element = hashTable[index][0];
                if (EqualityComparer<TKey>.Default.Equals(key, element.Key))
                {
                    hashTable[index].RemoveAt(0);
                    return element.Value;
                }
            }
            else
            {
                foreach (HashNode<TKey, TValue> node in hashTable[index])
                {
                    var element = node;
                    if (EqualityComparer<TKey>.Default.Equals(key, node.Key))
                    {
                        hashTable[index].Remove(node);
                        return element.Value;
                    }
                }
            }
            return default;
        }
    }
}
