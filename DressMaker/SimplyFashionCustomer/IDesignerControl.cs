using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyFashionCustomer
{
    interface IDesignerControl
    {
        void PushData(clsAllItems prDesignerItem);
        void UpdateControl(clsAllItems prDesignerItem);
    }
}
