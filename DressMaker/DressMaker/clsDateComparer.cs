using System.Collections.Generic;

/// <summary>
/// author's name: Corrina Busby
/// date: 22/06/2020
/// </summary>

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