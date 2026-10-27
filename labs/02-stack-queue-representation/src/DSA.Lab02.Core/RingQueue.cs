using System;

namespace DSA.Lab02
{
    public sealed class RingQueue<T>
    {
        private readonly T[] _items;
        private int _head;
        private int _tail;
        private int _count;

        public RingQueue(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
       
        }

        public int Count => _count;
        public int Capacity => _items.Length;

        public void Enqueue(T item)
        {
            // TODO: write at tail, advance tail with wrap-around, update count.
            if(_count>=Capacity)
            {
                throw new InvalidOperationException();
            }
            _items[_tail] = item;
            _tail = (_tail + 1) % Capacity;
            _count++;
        
        }

        public T Peek()
        {
            // TODO: return the item at head without removing it.
            return _items[_head];
        }

        public T Dequeue()
        {
            // TODO: read/clear at head, advance head with wrap-around, update count.
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }
           T itemToReturn = _items[_head];
            _head = (_head + 1) % Capacity;
            _count--;
            return itemToReturn;
        
        }
    }
}
