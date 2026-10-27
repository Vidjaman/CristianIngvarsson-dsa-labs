using System;

namespace DSA.Lab02
{
    public sealed class ArrayStack<T>
    {
        private readonly T[] _items;
        private int _count;

        public ArrayStack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
            _count = 0;
        }

        public int Count => _count;
        public int Capacity => _items.Length;

        public void Push(T item)
        {
            // TODO: place the item at the logical top and update the state.
            if(_count>=Capacity||Capacity==0)
            {
                throw new InvalidOperationException();
            }
          
            _items[_count] = item;
            _count++;


            //throw new NotImplementedException();
        }

        public T Peek()
        {
            if (_count <= 0)
            {
                throw new InvalidOperationException();
            }
            return _items[_count - 1];
            // TODO: return the logical top without removing it.
            //throw new NotImplementedException();
        }
        public void Clear()
        {
            Array.Clear(_items,0, _count);
            _count = 0;
        }
        public T Pop()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }
            T itemToRemove= _items[_count - 1];
            _items[_count - 1] = default!;
            _count--;
            return itemToRemove;
            // TODO: remove and return the logical top.
            //throw new NotImplementedException();
        }
    }
}
