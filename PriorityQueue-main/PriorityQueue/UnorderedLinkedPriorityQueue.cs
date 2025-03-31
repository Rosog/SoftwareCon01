using System;
using System.Windows.Forms;

namespace PriorityQueue
{
    public class UnorderedLinkedPriorityQueue<T> : PriorityQueue<T>
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

        public UnorderedLinkedPriorityQueue()
        {
            head = null;
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            // Loop through the nodes to find the highest priority element
            Node currentNode = head;
            Node highestNode = head;
            while (currentNode != null)
            {
                if(currentNode.Priority > highestNode.Priority)
                {
                    highestNode = currentNode;
                }
                currentNode = currentNode.NextNode;
            }
            return highestNode.Item;
        }

        public void Add(T item, int priority)
        {
            Node newNode = new Node(item, priority);
            if (head != null)
            {
                newNode.NextNode = head;
            }
            head = newNode;
        }

        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            // Find the highest priority element
            Node currentNode = head;
            Node highestNode = head;
            Node lastHighest = null;
            Node last = null;
            while (currentNode != null)
            {
                if (currentNode.Priority > highestNode.Priority)
                {
                    // Replace Highest Element With New Value and Second With Previous
                    highestNode = currentNode;
                    lastHighest = last;
                }
                // Advance to Next Node
                last = currentNode;
                currentNode = currentNode.NextNode;
            }
            // Upon finding the element shift every along until the highest priority element is at the end
            // After reaching the end change to null
            if (lastHighest == null)
            {
                head = head.NextNode;
            } else
            {
                lastHighest.NextNode = highestNode.NextNode;
            }

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
