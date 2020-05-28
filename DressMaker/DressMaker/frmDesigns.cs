using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplyFashionAdmin
{
    public partial class frmDesigner : Form
    {
        public frmDesigner()
        {
            InitializeComponent();
        }

        public static void Run(string prDesignerName)
        {
            if (string.IsNullOrEmpty(prDesignerName))
            {
                Instance.SetDetails(new clsDesigns());
            }
            else
            {
                Instance.refreshFormFromDB(prDesignerName);
            }
        }
    }
}
