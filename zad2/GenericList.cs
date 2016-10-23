using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class GenericList <X> : IGenericList<X>
    {
        private X[] _internalStorage;
        public int realSize = 0;

        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList (int size)
        {
            _internalStorage = new X[size];
        }

        public void Add(X item)
        {
            if (_internalStorage.Length == realSize)
            {
                Array.Resize(ref _internalStorage, _internalStorage.Length * 2);
            }
            _internalStorage[realSize] = item;
            realSize++;
        }

        public int IndexOf(X item)
        {
            for (int i =0; i<realSize; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool RemoveAt (int index)
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

        public bool Remove (X item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                return RemoveAt(index);
            }
            return false;
        }

        public X GetElement (int index)
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

        public void Clear()
        {
            Array.Clear(_internalStorage, 0, _internalStorage.Length);
        }

        public bool Contains(X item)
        {
            if (IndexOf(item) != -1)
            {
                return true;
            }
            return false;
        }
    }
}
