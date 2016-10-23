using System;


namespace ConsoleApplication1
{
    public class NegativeSizeException : Exception
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        public int realSize = 0;

        public void init()
        {
            _internalStorage = new int[4];
        }

        public void init2(int size)
        {
            if (size < 0)
            {
                throw new NegativeSizeException();
            }
            else
            {
                _internalStorage = new int[size];
                realSize = size;
            }
        }

        public void Add(int item)
        {
            if (_internalStorage.Length == realSize)
            {
                Array.Resize(ref _internalStorage, _internalStorage.Length * 2);
            }
            _internalStorage[realSize] = item;
            ++realSize;
        }

        public bool RemoveAt(int index)
        {
            if (index >= realSize)
            {
                return false;
            }
            for (int i = index; i < realSize -1; ++i)
            {
                _internalStorage[i] = _internalStorage[i + 1]; 
            }
            --realSize;
            return true;
        }

        public bool Remove (int item)
        {
            int i;
            for (i =0; i < realSize; ++i)
            {
                if (_internalStorage[i] == item)
                {
                    break;
                }
            }
            return RemoveAt(i);
        }

        public int GetElement (int index)
        {
            if (index <= realSize)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int Count
        {
            get
            {
                return realSize;
            }
        }

        public int IndexOf(int item)
        {
            for (int i =0; i< realSize; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            Array.Clear(_internalStorage, 0, _internalStorage.Length);
            realSize = 0;
        }

        public bool Contains (int item)
        {
            for (int i =0; i< realSize; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
