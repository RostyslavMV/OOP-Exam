using System.Collections;
using System.Diagnostics;

namespace OOP_Exam
{
    abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        // Retrun current element key
        public abstract int Key();

        // Return current element
        public abstract object Current();

        // Moves forward to next element
        public abstract bool MoveNext();

        // Goes back to ther first element
        public abstract void Reset();
    }

    public abstract class IteratorAggregate : IEnumerable
    {
        // Return current Iterator/IteratorAggregate for the implementing
        // object
        public abstract IEnumerator GetEnumerator();
    }

    class InOrderIterator<T> : Iterator
    {
        private RedBlackTree<T> tree;
        private RedBlackTreeNode<T> current;

        // Stores the current traversal position. An iterator may have a lot of
        // other fields for storing iteration state, especially when it is
        // supposed to work with a particular kind of collection.
        private int Position = -1;

        public InOrderIterator(RedBlackTree<T> tree)
        {
            this.tree = tree;
        }

        public override object Current()
        {
            return this.current;
        }

        public override int Key()
        {
            return this.Position;
        }

        public override bool MoveNext()
        {
            if (current == tree.RightMost)
            {
                return false;
            }
            if (current == null)
            {
                current = tree.LeftMost;
                return true;
            }
            if (current.Right != null)
            {
                current = (RedBlackTreeNode<T>)current.Right;
                while (current.Left != null)
                    current = (RedBlackTreeNode<T>)current.Left;
                return true;
            }
            while (current.Parent != null)
            {
                if (current.Parent.Left == current)
                {
                    current = (RedBlackTreeNode<T>)current.Parent;
                    return true;
                }
                current = (RedBlackTreeNode<T>)current.Parent;
            }
            return true;
        }

        public override void Reset()
        {
            this.Position = -1;
            current = null;
        }
    }

    class CircularListOperator<T> : Iterator
    {
        private SLcircularList<T> list;
        private ListNode<T> current;

        private int Position = -1;

        public CircularListOperator(SLcircularList<T> list)
        {
            this.list = list;
        }
        public override object Current()
        {
            current = list.StartNode;
            for (int i =0; i < Position; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public override int Key()
        {
            return this.Position;
        }

        public override bool MoveNext()
        {
            Position++;
            if (list.StartNode == null)
            {
                return false;
            }
            if (current == null)
            {
              
                current = list.StartNode;
                 System.Diagnostics.Debug.WriteLine(current.Data); 
                return true;
            }
            if (current.Next != list.StartNode)
            {
                current = current.Next;
                System.Diagnostics.Debug.WriteLine(current.Data); 
                return true;
            }
            //if (current.Next == list.StartNode)
            //{
            //    return false;
            //}
            return false;
        }

        public override void Reset()
        {
            this.Position = -1;
            //current = null;
        }
    }
}
