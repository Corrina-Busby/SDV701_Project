using System.Collections.Generic;

namespace SimplyFashionAdmin
{
    sealed class clsDateComparer : IComparer<clsAllItems>
    {
        public static readonly clsDateComparer Instance = new clsDateComparer();

        public int Compare(clsAllItems x, clsAllItems y)
        {
            return x.LastModified.CompareTo(y.LastModified);
        }
    }
}