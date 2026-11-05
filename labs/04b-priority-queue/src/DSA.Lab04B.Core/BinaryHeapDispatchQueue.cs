using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DSA.Lab04B
{
    /// <summary>
    /// Priority queue implemented with a binary min-heap.
    ///
    /// Invariant:
    /// each parent's Priority is <= the Priority of each of its children.
    ///
    /// The heap is NOT fully sorted.
    /// </summary>
    public sealed class BinaryHeapDispatchQueue<T>
    {
       private readonly List<PriorityEntry<T>> _heap = new List<PriorityEntry<T>>();

        public int Count => _heap.Count;

        public void Enqueue(T item, int priority)
        {
            // TODO:

            _heap.Add(new PriorityEntry<T>(item, priority));
            SiftUp(Count - 1);
            
            // 1. Append the new entry at the end.
            // 2. Restore the heap invariant upward.
            //throw new NotImplementedException();
        }
     
        public PriorityEntry<T> PeekNext()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The dispatch queue is empty.");
            }

            return _heap[0];
        }

        public PriorityEntry<T> DequeueNext()
        {
            // TODO:
          

            if ( _heap.Count == 0)
            {
                throw new InvalidOperationException();
            }
            PriorityEntry<T> oldRoot = _heap[0];
            // 1. Reject an empty queue.

            // 2. Remember the root: that is the minimum.
            // 3. Move the final heap entry to the root and remove the final slot.
            _heap[0] = _heap[Count-1];
            _heap.RemoveAt(Count - 1);
            // 4. If anything remains, restore the invariant downward.
            if(_heap.Count > 1)
            {
               
                SiftDown(0);
            }
            // 5. Return the old root.
            return oldRoot;
            //throw new NotImplementedException();

        }

        private void SiftUp(int index)
        {    
            int parentIndex = ParentIndex(index);
            if (_heap[parentIndex].Priority <= _heap[index].Priority)
            {
                return;
            }
            PriorityEntry<T> parent = _heap[parentIndex];
            Swap(parentIndex, index);
            SiftUp(parentIndex);
           
            // TODO: compare the entry with its parent and swap while needed.
            //throw new NotImplementedException();
        }

        private void SiftDown(int index)
        {
           
            // TODO:
            int rightChildIndex=RightChildIndex(index);
            int leftChildIndex = LeftChildIndex(index);

            bool rightExists = true;
           
            if (leftChildIndex > Count - 1)
            {
                
                return;
            }
            PriorityEntry<T> rightChild = default;
            PriorityEntry<T> leftChild = _heap[LeftChildIndex(index)];
            PriorityEntry<T> lowerChild=leftChild;
            int lowerIndex = leftChildIndex;
            
            if (rightChildIndex <= Count - 1)
            {
           
                rightChild = _heap[rightChildIndex];
            }
            else
            {
                rightExists = false;
            }

            if (rightExists)
            {
                if (rightChild.Priority < leftChild.Priority)
                {
                    lowerChild=rightChild;
                    lowerIndex = rightChildIndex;
                    
                }
            }

            if (_heap[index].Priority > lowerChild.Priority)
            {
                Swap(index, lowerIndex);
                SiftDown(lowerIndex);
            }
           
            
            // Compare the current entry with its children.
            // If a child should come first, swap with the smaller-priority child.
            //throw new NotImplementedException();
        }

        private static int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private static int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private static int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private void Swap(int a, int b)
        {
            PriorityEntry<T> temp = _heap[a];
            _heap[a] = _heap[b];
            _heap[b] = temp;
        }
    }
}
