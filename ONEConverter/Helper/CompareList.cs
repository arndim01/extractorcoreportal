using System;
using System.Collections.Generic;
using System.Text;

namespace ONEConverter.Helper
{
    public class CompareList : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            if (x.Count != y.Count) return false;
            for(var i =0; i < x.Count; i++)
            {
                if (x[i] != y[i]) return false;
            }
            return true;
        }

        public int GetHashCode(List<string> obj)
        {
            return obj.Count;
        }
    }
}
