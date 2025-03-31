using System;
using System.Windows.Forms;

namespace PriorityQueue
{
    public class UnorderedArrayPriorityQueue<T> : PriorityQueue<T>
    {
        private readonly PriorityItem<T>[] storage;
        private readonly int capacity;
        private int tailIndex;

        public UnorderedArrayPriorityQueue(int size)
        {
            storage = new PriorityItem<T>[size];
            capacity = size;
            tailIndex = -1;
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            // Loop through the array to find the highest priority element
            int highestPriorityIndex = 0;
            int highestPriority = -1;
            for(int i=0; i<tailIndex; i++)
            {
                if (storage[i].Priority > highestPriority)
                {
                    highestPriorityIndex = i - 1;
                }
            }
            return storage[highestPriorityIndex].Item;
        }

        public void Add(T item, int priority)
        {
            // Increase the end index and check if it is over capactity. If so then throw exception.
            tailIndex++;
            if (tailIndex >= capacity)
            {
                tailIndex--;
                throw new QueueOverflowException();
            }
            // Add new entry to the end of the array
            storage[tailIndex] = new PriorityItem<T>(item, priority);
        }

        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            // Loop through the array to find the highest priority element
            int highestPriorityIndex = 0;
            int highestPriority = -1;
            for (int i = 0; i < tailIndex; i++)
            {
                if (storage[i].Priority > highestPriority)
                {
                    highestPriorityIndex = i - 1;
                }
            }
            // Upon finding the element shift every along until the highest priority element is at the end
            // After reaching the end change to null
            for (int i=highestPriorityIndex; i < tailIndex; i++)
            {
                storage[i] = storage[i + 1];
            }
            storage[tailIndex] = null;
            tailIndex--;
        }

        public bool IsEmpty()
        {
            return tailIndex < 0;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("No items to display");
            }

            string result = "[";
            for (int i = 0; i <= tailIndex; i++)
            {
                if (i > 0)
                {
                    result += ", ";
                }
                result += storage[i];
            }
            result += "]";
            return result;
        }
    }
}
