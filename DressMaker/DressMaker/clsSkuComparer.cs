using System.Collections.Generic;

/// <summary>
/// author's name: Corrina Busby
/// date: 22/06/2020
/// </summary>

namespace SimplyFashionAdmin
{
    class clsSkuComparer : IComparer<clsAllItems>
    {
        public static readonly clsSkuComparer Instance = new clsSkuComparer();

        public int Compare(clsAllItems x, clsAllItems y)
        {
            return x.SkuCode.CompareTo(y.SkuCode);
        }
    }
}
