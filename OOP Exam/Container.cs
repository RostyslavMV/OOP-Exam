using OOP_Exam.BPlusTree;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OOP_Exam
{
    public class Container<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        private TValue[] sortedValues;

        public Container()
        {

        }

        public Container(RedBlackTree<TValue> redBlackTree, Collection<TKey> keys)
        {
            int i = 0;
            foreach (RedBlackTreeNode<TValue> node in redBlackTree)
            {
                var currentKey = keys[i];
                dictionary[currentKey] = node.Data;
                i++;
                if (i >= keys.Count)
                {
                    i = 0;
                }
            }
        }
        public Container(BPTree<TKey, TValue> bpTree)
        {
            foreach (var element in bpTree.AsPairEnumerable())
            {
                dictionary[element.Key] = element.Value;
            }
        }
        public Container(SLcircularList<TValue> list, Collection<TKey> keys)
        {
            int i = 0;
            foreach (ListNode<TValue> element in list)
            {
                var currentKey = keys[i];
                dictionary[currentKey] = element.Data;
                i++;
                if (i >= keys.Count)
                {
                    i = 0;
                }
            }
        }

        public Container(SeparateChainingHashTable<TKey,TValue> separateChainingHashTable)
        {
            foreach(Collection<HashNode<TKey, TValue>> row in separateChainingHashTable.hashTable)
            {
                foreach(HashNode<TKey, TValue> element in row)
                {
                    dictionary[element.Key] = element.Value;
                }
            }
        }

        public Container(SeparateChaining2ChoiceHashTable<TKey, TValue> chaining2ChoiceHashTable)
        {
            foreach (Collection<HashNode<TKey, TValue>> row in chaining2ChoiceHashTable.hashTable)
            {
                foreach (HashNode<TKey, TValue> element in row)
                {
                    dictionary[element.Key] = element.Value;
                }
            }
        }

        public Container(QuadraticHashTable<TKey, TValue> quadraticHashTable)
        {
            foreach(HashNode<TKey, TValue> element in quadraticHashTable.hashTable)
            {
                dictionary[element.Key] = element.Value;
            }
        }

        public TValue GetValue(TKey key)
        {
            TValue res;
            dictionary.TryGetValue(key, out res);
            return res;
        }

        public void AddOrUpdate(TKey key, TValue value)
        {
            dictionary[key] = value;
        }

        public void RemoveByKey(TKey key)
        {
            dictionary.Remove(key);
        }

        public TKey[] GetKeys()
        {
            return dictionary.Keys.ToArray();
        }

        public TValue[] GetValues()
        {
            sortedValues = dictionary.Values.ToArray();
            return sortedValues;
        }

        private void SortValues(Comparer<TValue> comparer)
        {
            sortedValues = dictionary.Values.ToArray();
            Array.Sort(sortedValues, comparer);
        }
        
        public TValue[] GetSortedValues(Comparer<TValue> comparer = null)
        {
            if (comparer == null)
            {
                comparer = Comparer<TValue>.Default;
            }
            SortValues(comparer);
            return sortedValues;
        }

        private TValue[] SubArray(TValue[] array, int firstIndex, int lastIndex)
        {
            TValue[] ret = new TValue[lastIndex-firstIndex+1];
            for (int i =firstIndex; i <= lastIndex; i++)
            {
                ret[i] = array[i];
            }
            return ret;
        }

        public  TValue[] GetSortedValuesNumber(int number, Comparer<TValue> comparer = null)
        {
            if (comparer == null)
            {
                comparer = Comparer<TValue>.Default;
            }
            SortValues(comparer);
            return SubArray(sortedValues, 0, number - 1);
        }

        public Dictionary<TKey, TValue> ToDictionary()
        {
            return dictionary;
        }
    }
}
