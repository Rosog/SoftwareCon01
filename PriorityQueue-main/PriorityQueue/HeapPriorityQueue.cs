using System;
using System.Windows.Forms;

namespace PriorityQueue
{
    public class HeapPriorityQueue<T> : PriorityQueue<T>
    {

        private class HeapItem
        {
            public T Item {  get; set; }
            public int Priority { get; set; }

            public HeapItem(T item, int priority)
            {
                Item = item;
                Priority = priority;
            }

        }

        private HeapItem[] heap;
        private int size;
        private int capacity;

        public HeapPriorityQueue(int capacity)
        {
            this.capacity = capacity;
            heap = new HeapItem[capacity];
            size = 0;
        }

        public T Head()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            // Just return head as is sorted
            return heap[0].Item;
        }

        public void Add(T item, int priority)
        {
            if(size >= capacity)
            {
                throw new QueueOverflowException("Full...");

            }
            heap[size] = new HeapItem(item, priority);
            ShiftUp(size);
            size++;
        }

        public void Remove()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            heap[0] = heap[size - 1];
            size--;
            ShiftDown(0);
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "Empty...";
            }
            string result = "[";
            for (int i = 0; i < size; i++)
            {
                result += heap[i].Item+" ("+heap[i].Priority+")";
                if (i < size - 1)
                    result += ", ";
            }
            return result + "]";
        }

        private void ShiftUp(int index)
        {
            while (index > 0)
            {
                // Calc parent index and compare priority
                int parent = (index-1)/2;
                if (heap[index].Priority <= heap[parent].Priority)
                {
                    break;
                }
                // Swap and continue, if no conditions met.
                Swap(index, parent);
                index = parent;
            }
        }

        private void ShiftDown(int index)
        {
            while (index < size)
            {
                int max = index;
                int lf = 2 * index + 1;
                int ri = 2 * index + 2;
                // Check if left or right child has better priority. If so then replace max.
                if (lf < size && heap[lf].Priority > heap[max].Priority)
                {
                    max = lf;
                }
                if (ri < size && heap[ri].Priority > heap[max].Priority)
                {
                    max = ri;
                }
                if(max == index)
                {
                    break;
                }
                // Swap and continue, if no conditions met.
                Swap(index, max);
                index = max;
            }
        }

        // Swap two items within the heap
        private void Swap(int i, int j)
        {
            HeapItem t = heap[i];
            heap[i] = heap[j];
            heap[j] = t;
        }

    }
}
