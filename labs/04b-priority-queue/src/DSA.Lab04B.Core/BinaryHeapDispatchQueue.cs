using System;
using System.Collections.Generic;

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
            _heap.Add(new PriorityEntry<T>(item,priority));
            SiftUp(_heap.Count-1);
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
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The dispatch queue is empty.");
            }
            // 1. Reject an empty queue.
            PriorityEntry<T> root = _heap[0];
            if (_heap.Count == 1)
            {
                _heap.RemoveAt(0);
                return root;
            }
            // 2. Remember the root: that is the minimum.
            _heap[0] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);
            SiftDown(0);
            
            // 3. Move the final heap entry to the root and remove the final slot.
            // 4. If anything remains, restore the invariant downward.
            // 5. Return the old root.
            Console.WriteLine(_heap);
            return root;
        }

        private void SiftUp(int index)
        {
            while (true)
            {
                if (_heap[index].Priority < _heap[ParentIndex(index)].Priority)
                {
                    Swap(index,ParentIndex(index));
                    index = ParentIndex(index);
                }
                else
                {
                    break;
                }
            }
            // TODO: compare the entry with its parent and swap while needed.
        }

        private void SiftDown(int index)
        {
            // TODO:
            while (true)
            {
                if (LeftChildIndex(index) >= _heap.Count)
                {
                    break;
                }

                int childIndex = LeftChildIndex(index);
 
                if (RightChildIndex(index) < _heap.Count && _heap[LeftChildIndex(index)].Priority > _heap[RightChildIndex(index)].Priority)
                {
                    childIndex = RightChildIndex(index);
                } 
                
                if (_heap[index].Priority > _heap[childIndex].Priority)
                {
                    Swap(index, childIndex);
                    index = childIndex;
                }

                else
                {
                    break;
                }
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
