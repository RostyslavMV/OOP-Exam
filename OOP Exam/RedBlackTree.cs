using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OOP_Exam
{
    public class RedBlackTree<T> : IteratorAggregate
    {
        RedBlackTreeNode<T> Header;
        IComparer<T> Comparer;
        ulong Nodes;

        public RedBlackTree()
        {
            Comparer = Comparer<T>.Default;
            Header = new RedBlackTreeNode<T>();
            Nodes = 0;
        }

        public RedBlackTree(IComparer<T> c)
        {
            Comparer = c;
            Header = new RedBlackTreeNode<T>();
            Nodes = 0;
        }

        public override IEnumerator GetEnumerator()
        {
            return new InOrderIterator<T>(this);
        }
        public RedBlackTreeNode<T> Root
        {
            get { return (RedBlackTreeNode<T>)Header.Parent; }
            private set { Header.Parent = value; }
        }


        public RedBlackTreeNode<T> LeftMost
        {
            get { return (RedBlackTreeNode<T>)Header.Left; }
            private set { Header.Left = value; }
        }

        public RedBlackTreeNode<T> RightMost
        {
            get { return (RedBlackTreeNode<T>)Header.Right; }
            private set { Header.Right = value; }
        }


        static Node Minimum(Node x)
        {
            while (x.Left != null) x = x.Left;
            return x;
        }

        static Node Maximum(Node x)
        {
            while (x.Right != null) x = x.Right;
            return x;
        }
        static void RotateLeft(Node x,
                               ref Node Root)
        {
            Node y = x.Right;

            x.Right = y.Left;
            if (y.Left != null)
                y.Left.Parent = x;
            y.Parent = x.Parent;

            if (x == Root)
                Root = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;
            else
                x.Parent.Right = y;
            y.Left = x;
            x.Parent = y;
        }

        static void RotateRight(Node x,
                                ref Node Root)
        {
            Node y = x.Left;

            x.Left = y.Right;
            if (y.Right != null)
                y.Right.Parent = x;
            y.Parent = x.Parent;

            if (x == Root)
                Root = y;
            else if (x == x.Parent.Right)
                x.Parent.Right = y;
            else
                x.Parent.Left = y;
            y.Right = x;
            x.Parent = y;
        }

        public static void Rebalance(Node x,
                                     ref Node Root)
        {
            x.Color = NodeColor.Red;
            while (x != Root && x.Parent.Color == NodeColor.Red)
            {
                if (x.Parent == x.Parent.Parent.Left)
                {
                    Node y = x.Parent.Parent.Right;
                    if (y != null && y.Color == NodeColor.Red)
                    {
                        x.Parent.Color = NodeColor.Black;
                        y.Color = NodeColor.Black;
                        x.Parent.Parent.Color = NodeColor.Red;
                        x = x.Parent.Parent;
                    }
                    else
                    {
                        if (x == x.Parent.Right)
                        {
                            x = x.Parent;
                            RotateLeft(x, ref Root);
                        }
                        x.Parent.Color = NodeColor.Black;
                        x.Parent.Parent.Color = NodeColor.Red;
                        RotateRight(x.Parent.Parent, ref Root);
                    }
                }
                else
                {
                    Node y = x.Parent.Parent.Left;
                    if (y != null && y.Color == NodeColor.Red)
                    {
                        x.Parent.Color = NodeColor.Black;
                        y.Color = NodeColor.Black;
                        x.Parent.Parent.Color = NodeColor.Red;
                        x = x.Parent.Parent;
                    }
                    else
                    {
                        if (x == x.Parent.Left)
                        {
                            x = x.Parent;
                            RotateRight(x, ref Root);
                        }
                        x.Parent.Color = NodeColor.Black;
                        x.Parent.Parent.Color = NodeColor.Red;
                        RotateLeft(x.Parent.Parent, ref Root);
                    }
                }
            }
            Root.Color = NodeColor.Black;
        }
        static void TSwap<X>(ref X u, ref X v) { X t = u; u = v; v = t; }
        public static Node RebalanceForRemove(Node z,
                                              ref Node Root,
                                              ref Node Leftmost,
                                              ref Node Rightmost)
        {
            Node y = z;
            Node x = null;
            Node x_Parent = null;

            if (y.Left == null)
                x = y.Right;
            else
                if (y.Right == null)
                x = y.Left;
            else
            {
                y = y.Right;
                while (y.Left != null) y = y.Left;
                x = y.Right;
            }

            if (y != z)
            {
                z.Left.Parent = y;
                y.Left = z.Left;
                if (y != z.Right)
                {
                    x_Parent = y.Parent;
                    if (x != null) x.Parent = y.Parent;
                    y.Parent.Left = x;
                    y.Right = z.Right;
                    z.Right.Parent = y;
                }
                else
                    x_Parent = y;

                if (Root == z)
                    Root = y;
                else if (z.Parent.Left == z)
                    z.Parent.Left = y;
                else
                    z.Parent.Right = y;
                y.Parent = z.Parent;
                TSwap(ref y.Color, ref z.Color);
                y = z;
            }
            else  // y == z
            {
                x_Parent = y.Parent;
                if (x != null) x.Parent = y.Parent;
                if (Root == z)
                    Root = x;
                else
                    if (z.Parent.Left == z)
                    z.Parent.Left = x;
                else
                    z.Parent.Right = x;
                if (Leftmost == z)
                    if (z.Right == null)
                        Leftmost = z.Parent;
                    else
                        Leftmost = Minimum(x);
                if (Rightmost == z)
                    if (z.Left == null)
                        Rightmost = z.Parent;
                    else
                        Rightmost = Maximum(x);
            }
            if (y.Color != NodeColor.Red)
            {
                while (x != Root && (x == null || x.Color == NodeColor.Black))
                    if (x == x_Parent.Left)
                    {
                        Node w = x_Parent.Right;
                        if (w.Color == NodeColor.Red)
                        {
                            w.Color = NodeColor.Black;
                            x_Parent.Color = NodeColor.Red;
                            RotateLeft(x_Parent, ref Root);
                            w = x_Parent.Right;
                        }
                        if ((w.Left == null || w.Left.Color == NodeColor.Black) &&
                            (w.Right == null || w.Right.Color == NodeColor.Black))
                        {
                            w.Color = NodeColor.Red;
                            x = x_Parent;
                            x_Parent = x_Parent.Parent;
                        }
                        else
                        {
                            if (w.Right == null || w.Right.Color == NodeColor.Black)
                            {
                                if (w.Left != null) w.Left.Color = NodeColor.Black;
                                w.Color = NodeColor.Red;
                                RotateRight(w, ref Root);
                                w = x_Parent.Right;
                            }
                            w.Color = x_Parent.Color;
                            x_Parent.Color = NodeColor.Black;
                            if (w.Right != null) w.Right.Color = NodeColor.Black;
                            RotateLeft(x_Parent, ref Root);
                            break;
                        }
                    }
                    else
                    {
                        Node w = x_Parent.Left;
                        if (w.Color == NodeColor.Red)
                        {
                            w.Color = NodeColor.Black;
                            x_Parent.Color = NodeColor.Red;
                            RotateRight(x_Parent, ref Root);
                            w = x_Parent.Left;
                        }
                        if ((w.Right == null || w.Right.Color == NodeColor.Black) &&
                            (w.Left == null || w.Left.Color == NodeColor.Black))
                        {
                            w.Color = NodeColor.Red;
                            x = x_Parent;
                            x_Parent = x_Parent.Parent;
                        }
                        else
                        {
                            if (w.Left == null || w.Left.Color == NodeColor.Black)
                            {
                                if (w.Right != null) w.Right.Color = NodeColor.Black;
                                w.Color = NodeColor.Red;
                                RotateLeft(w, ref Root);
                                w = x_Parent.Left;
                            }
                            w.Color = x_Parent.Color;
                            x_Parent.Color = NodeColor.Black;
                            if (w.Left != null) w.Left.Color = NodeColor.Black;
                            RotateRight(x_Parent, ref Root);
                            break;
                        }
                    }
                if (x != null) x.Color = NodeColor.Black;
            }
            return y;
        }
        RedBlackTreeNode<T> Add(T Key,
                       RedBlackTreeNode<T> y,
                       Direction From)
        {
            RedBlackTreeNode<T> z = new RedBlackTreeNode<T>(Key);
            Nodes++;

            if (y == Header)
            {
                Root = z;
                RightMost = z;
                LeftMost = z;
            }
            else if (From == Direction.FromLeft)
            {
                y.Left = z;
                if (y == LeftMost) LeftMost = z;
            }
            else
            {
                y.Right = z;
                if (y == RightMost) RightMost = z;
            }

            z.Parent = y;
            Rebalance(z, ref Header.Parent);
            return z;
        }

        public RedBlackTreeNode<T> Add(T Key)
        {
            RedBlackTreeNode<T> y = Header;
            RedBlackTreeNode<T> x = Root;

            int c = -1;
            while (x != null)
            {
                y = x;
                c = Comparer.Compare(Key, x.Data);
                if (c < 0)
                    x = (RedBlackTreeNode<T>)x.Left;
                else if (c > 0)
                    x = (RedBlackTreeNode<T>)x.Right;
                else return null;
                    //throw new EntryAlreadyExistsException();
            }

            Direction From = c < 0 ? Direction.FromLeft : Direction.FromRight;
            return Add(Key, y, From);
        }

        public void Remove(T Key)
        {
            RedBlackTreeNode<T> root = Root;

            for (; ; )
            {
                if (root == null)
                    return;
                    //throw new EntryNotFoundException();

                int Compare = Comparer.Compare(Key, root.Data);

                if (Compare < 0)
                    root = (RedBlackTreeNode<T>)root.Left;

                else if (Compare > 0)
                    root = (RedBlackTreeNode<T>)root.Right;

                else // Item is found
                {
                    RebalanceForRemove(root, ref Header.Parent, ref Header.Left, ref Header.Right);
                    Nodes--;
                    break;
                }
            }
        }

        public RedBlackTreeNode<T> Search(T Key)
        {
            if (Root == null)
                return null;
            else
            {
                RedBlackTreeNode<T> search = Root;

                do
                {
                    long result = Comparer.Compare(Key, search.Data);

                    if (result < 0) search = (RedBlackTreeNode<T>)search.Left;

                    else if (result > 0) search = (RedBlackTreeNode<T>)search.Right;

                    else break;

                } while (search != null);

                return search;
            }
        }

        public Collection<T> ToCollection()
        {
            Collection<T> collection = new Collection<T>();
            foreach (RedBlackTreeNode<T> node in this)
            {
                if (node.Data != null)
                    collection.Add(node.Data);
            }
            return collection;
        }
    }

    public class EntryNotFoundException : Exception
    {
        static String message = "The requested entry could not be located in the specified collection.";

        public EntryNotFoundException() : base(message) { }
    }

    public class EntryAlreadyExistsException : Exception
    {
        static String message = "The set entry already exists.";

        public EntryAlreadyExistsException() : base(message) { }
    }
}
