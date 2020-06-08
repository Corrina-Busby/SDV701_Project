using System.Collections.Generic;

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
