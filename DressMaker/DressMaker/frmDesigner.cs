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

/// <summary>
/// 
/// </summary>

namespace SimplyFashionAdmin
{
    public sealed partial class frmDesigner : Form
    {
        private clsDesigners _Designer;
        private List<clsAllItems> _ItemList;
        private List<clsAllOrders> _OrderList;

        public clsDesigners Designer { get => _Designer; set => _Designer = value; }
        public List<clsAllItems> ItemList { get => _ItemList; set => _ItemList = value; } 
        public List<clsAllOrders> OrderList { get => _OrderList; set => _OrderList = value; }

        // >>}}}0> Singleton
        public static readonly frmDesigner Instance = new frmDesigner();

        private frmDesigner()
        {
            InitializeComponent();
        }

        public static void Run(string prDesignerName)
        {
            if (string.IsNullOrEmpty(prDesignerName))
            {
                Instance.SetDetails(new clsDesigners());
            }
            else
            {
                Instance.loadDesignerFormDB(prDesignerName);
            }
            Instance.Show();
        }


        private async void loadDesignerFormDB(string prDesignerName)
        {
            SetDetails(await ServiceClient.GetDesignerAsync(prDesignerName));
        }

        private void SetDetails(clsDesigners prDesignerName)
        {
            _Designer = prDesignerName;
         //   UpdateDisplay();
        }

        //private void UpdateDisplay()
        //{

        //    lstItems.DataSource = null;
        //    if (_Designer.ItemList != null)
        //        lstItems.DataSource = _Designer.ItemList;
        //}
    }
}
