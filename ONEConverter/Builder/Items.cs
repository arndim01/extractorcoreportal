using ONEConverter.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONEConverter.Builder
{
    public class Items<T> : IEnumerable, IItem<T>
    {
        private List<T> _itemList = new List<T>();
        public void Add(T item)
        {
            _itemList.Add(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_itemList.ToList()).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
