using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ONEConverter.Interfaces
{
    public interface IItem<T>: IEnumerable
    {
        void Add(T item);
    }
}
