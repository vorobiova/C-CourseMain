using System.Collections;
using System.Collections.Generic;

namespace C_CourseMain
{
    public class DataContent<T>
    {
        public T Data { get; private set; }
        public DataContent<T> Next { get; set; }
        public DataContent<T> Previous { get; set; }

        public DataContent(T data)
        {
            Data = data;
        }        
    }

    public class DataList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        private DataContent<T> _firstItem;
        private DataContent<T> _lastItem;        

        public void Add(T data)
        {
            DataContent<T> item = new DataContent<T>(data);

            if (_firstItem == null)
                _firstItem = item;
            else
            {
                _lastItem.Next = item;
                item.Previous = _lastItem;
            }
            _lastItem = item;
            Count++;
        }

        public bool Remove(T data)
        {
            DataContent<T> item = GetListItem(data);    

            if (item != null)
            {              
                if (item.Next != null)
                    item.Next.Previous = item.Previous;
                else
                    _lastItem = item.Previous;

                if (item.Previous != null)
                    item.Previous.Next = item.Next;
                else
                    _firstItem = item.Next;

                Count--;
                return true;
            }
            return false;
        }                 

        public bool Contains(T data)
        {
            return GetListItem(data) == null ? false : true;
        }

        public void Clear()
        {
            _firstItem = _lastItem = null;
            Count = 0;
        }

        private DataContent<T> GetListItem(T data)
        {
            DataContent<T> item = _firstItem;
            while (item != null)
            {
                if (item.Data.Equals(data))
                    return item;
                item = item.Next;
            }
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DataContent<T> current = _firstItem;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            DataContent<T> current = _lastItem;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}

