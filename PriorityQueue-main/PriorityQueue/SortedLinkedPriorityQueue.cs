using System;
using System.Windows.Forms;

namespace PriorityQueue
{
    public class SortedLinkedPriorityQueue<T> : PriorityQueue<T>
    {

        private Node head;

        private class Node
        {
            public T Item {  get; set; }
            public int Priority { get; set; }
            public Node NextNode { get; set; }

            public Node(T item, int priority)
            {
                Item = item;
                Priority = priority;
                NextNode = null;
            }

        }

        public SortedLinkedPriorityQueue()
        {
            head = null;
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            // Just return head as is sorted
            return head.Item;
        }

        public void Add(T item, int priority)
        {
            Node newNode = new Node(item, priority);
            // Set Head to New Highest Value
            if (head == null || priority > head.Priority)
            {
                newNode.NextNode = head;
                head = newNode;
            } else
            {
                // Move through the list in order to find out where new value belongs
                Node currentNode = head;
                while (currentNode.NextNode != null && currentNode.NextNode.Priority >= priority)
                {
                    currentNode = currentNode.NextNode;
                }
                newNode.NextNode = currentNode.NextNode;
                currentNode.NextNode = newNode;
            }
        }

        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            head = head.NextNode;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }
            Node currentNode = head;
            string result = "[";
            while (currentNode != null)
            {
                if (currentNode != head)
                {
                    result += ", ";
                }
                result += currentNode.Item+" ("+currentNode.Priority+")";
                currentNode = currentNode.NextNode;
            }
            result += "]";
            return result;
        }
    }
}
