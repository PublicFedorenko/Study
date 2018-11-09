using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class CustomList<T>
    {
        private List<T> _list;

        public event EventHandler<ListEventArgs> OnItemAdded;
        public event EventHandler<ListEventArgs> OnItemInserted;
        public event EventHandler<ListEventArgs> OnItemRemoved;
        public event EventHandler<ListEventArgs> OnListCleared;

        public CustomList()
        {
            _list = new List<T>();
        }

        public void Add(T item)
        {
            OnItemAdded?.Invoke(this, new ListEventArgs("ItemAdded event fired.", _list.Count));
            _list.Add(item);
        }

        public void Insert(int index, T item)
        {
            OnItemInserted?.Invoke(this, new ListEventArgs("ItemInserted event fired.", _list.Count));
            _list.Insert(index, item);
        }

        public void Remove(T item)
        {
            OnItemRemoved?.Invoke(this, new ListEventArgs("ItemRemoved event fired.", _list.Count));
            _list.Remove(item);
        }

        public void Clear()
        {
            OnListCleared?.Invoke(this, new ListEventArgs("ListCleared event fired.", _list.Count));
            _list.Clear();
        }
    }
}
