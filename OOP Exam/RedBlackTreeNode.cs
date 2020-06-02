namespace OOP_Exam
{
    public class Node
    {
        public Node Left;
        public Node Right;
        public Node Parent;
        public NodeColor Color;

        public bool IsHeader
        { get { return Color == NodeColor.Header; } }
    }


    public class RedBlackTreeNode<T> : Node
    {
        public T Data;

        public RedBlackTreeNode()
        {
            Left = this;
            Right = this;
            Parent = null;
            Color = NodeColor.Header;
        }

        public RedBlackTreeNode(T t)
        {
            Left = null;
            Right = null;
            Color = NodeColor.Black;
            Data = t;
        }

        public override string ToString()
        {
            string StringOut = "{";

            StringOut = StringOut + Data;

            StringOut = StringOut + "}";
            return StringOut;
        }
    }
}
