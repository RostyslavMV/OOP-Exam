using System.Collections;
using System.Collections.Generic;

namespace OOP_Exam
{
    public class ListNode<T>
    {
        public T Data { get; private set; }
        public ListNode<T> Next { get; private set; }
        public ListNode(T data)
        {
            Data = data;
        }
        public ListNode(T data, ListNode<T> next) : this(data)
        {
            Next = next;
        }

        public void SetNext(ListNode<T> nextNode)
        {
            Next = nextNode;
        }
    };

    public class SLcircularList<T> : IteratorAggregate
    {
        public ListNode<T> StartNode { get; private set; }
        private ListNode<T> LastNode { get; set; }

        public override IEnumerator GetEnumerator()
        {
            return new CircularListOperator<T>(this);
        }
        public SLcircularList()
        {
            StartNode = null;
            LastNode = null;
        }

        public SLcircularList(T data)
        {
            StartNode = new ListNode<T>(data, StartNode);
            LastNode = StartNode;
        }

        public void AddToEnd(T data)
        {
            ListNode<T> newNode = new ListNode<T>(data, StartNode);
            if (StartNode == null)
            {
                StartNode = newNode;
                StartNode.SetNext(StartNode);
                LastNode = StartNode;
            }
            else
            {
                LastNode.SetNext(newNode);
                LastNode = newNode;
            }
        }

        public void AddToBegin(T data)
        {
            ListNode<T> newNode = new ListNode<T>(data, StartNode);
            if (StartNode == null)
            {
                StartNode = newNode;
                StartNode.SetNext(StartNode);
                LastNode = StartNode;
            }
            else
            {
                StartNode = newNode;
                LastNode.SetNext(StartNode);
            }
        }

        public bool AddAfter(T prevData, T data)
        {
            ListNode<T> node = Search(prevData);
            if (StartNode == null || node == null)
                return false;
            ListNode<T> currentNode = StartNode;
            while (currentNode != LastNode)
            {
                if (currentNode == node)
                {
                    ListNode<T> newNode = new ListNode<T>(data, currentNode.Next);
                    currentNode.SetNext(newNode);
                    if (LastNode == currentNode)
                    {
                        LastNode = newNode;
                    }
                }
                currentNode = currentNode.Next;
            }
            if (currentNode == LastNode)
            {
                ListNode<T> newNode = new ListNode<T>(data, StartNode);
                LastNode.SetNext(newNode);
                LastNode = newNode;
            }
            return true;
        }

        public void Remove(T data)
        {
            if (StartNode == null)
            {
                throw new EntryNotFoundException();
            }
            if (EqualityComparer<T>.Default.Equals(StartNode.Data, data))
            {
                if (LastNode == StartNode)
                {
                    StartNode = null;
                    LastNode = StartNode;
                }
                else
                {
                    StartNode = StartNode.Next;
                    LastNode.SetNext(StartNode);
                }
            }
            else
            {
                ListNode<T> current = StartNode.Next;
                ListNode<T> prev = StartNode;
                while (current != LastNode)
                {
                    if (EqualityComparer<T>.Default.Equals(current.Data, data))
                    {
                        prev.SetNext(current.Next);
                        if (current == LastNode)
                        {
                            prev.SetNext(StartNode);
                            LastNode = prev;
                        }
                        return;
                    }
                    prev = current;
                    current = current.Next;
                }
            }

        }

        public ListNode<T> Search(T data)
        {
            ListNode<T> current = StartNode;
            while (current != LastNode)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, data))
                    return current;
                current = current.Next;
            }
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
                return current;
            return null;
        }
    }
}
