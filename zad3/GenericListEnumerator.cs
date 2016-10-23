using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class GenericListEnumerator<X> : IEnumerator<X> 
    {
        private GenericList<X> List;
        private int index;
        private X current;

        public GenericListEnumerator(GenericList<X> list)
        {
            List = list;
            index = -1;
            current = default(X);
        }

        public bool MoveNext ()
        {
            index++;
            if (index >= List.Count)
            {
                return false;
            }
            else
            {
                current = List.GetElement(index);
            }
            return true;
        }

        public void Reset ()
        {
            index = -1;
        }

        void IDisposable.Dispose() { }

        public X Current
        {
            get
            {
                return current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
    }
}
