using OOP_Exam.BPlusTree;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam
{
    public class Set<TValue>
    {
        public HashSet<TValue> set { get; private set; } = new HashSet<TValue>();

        public Set(RedBlackTree<TValue> redBlackTree)
        {
            foreach (RedBlackTreeNode<TValue> element in redBlackTree)
            {
                set.Add(element.Data);
            }
        }

        public Set(BPTree<Type, TValue> bpTree)
        {
            foreach (var element in bpTree)
            {
                set.Add(element);
            }
        }

        public Set(SLcircularList<TValue> list)
        {
            foreach (ListNode<TValue> element in list)
            {
                set.Add(element.Data);
            }
        }

        public Set(SeparateChainingHashTable<Type, TValue> separateChainingHashTable)
        {
            foreach (Collection<HashNode<Type, TValue>> row in separateChainingHashTable.hashTable)
            {
                foreach (HashNode<Type, TValue> element in row)
                {
                    set.Add(element.Value);
                }
            }
        }

        public Set(SeparateChaining2ChoiceHashTable<Type, TValue> chaining2ChoiceHashTable)
        {
            foreach (Collection<HashNode<Type, TValue>> row in chaining2ChoiceHashTable.hashTable)
            {
                foreach (HashNode<Type, TValue> element in row)
                {
                    set.Add(element.Value);
                }
            }
        }

        public Set(QuadraticHashTable<Type, TValue> quadraticHashTable)
        {
            foreach (HashNode<Type, TValue> element in quadraticHashTable.hashTable)
            {
                set.Add(element.Value);
            }
        }

        public void Add(TValue value)
        {
            set.Add(value);
        }
        
        public void Remove(TValue value)
        {
            set.Remove(value);
        }

        public Set<TValue> UnionWith(Set<TValue> other)
        {
            set.UnionWith(other.set);
            return this;
        }

        public Set<TValue> IntersectWith(Set<TValue> other)
        {
            set.IntersectWith(other.set);
            return this;
        }

        public Set<TValue> ExceptWith(Set<TValue> other)
        {
            set.ExceptWith(other.set);
            return this;
        }

        public Set<TValue> SymmetricExceptWith(Set<TValue> other)
        {
            set.SymmetricExceptWith(other.set);
            return this;
        }
    }
}
