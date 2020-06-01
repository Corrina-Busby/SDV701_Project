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
        private clsDesigners _Designers;
        private List<clsAllItems> _ItemList;
        private List<clsAllOrders> _OrderList;

        public clsDesigners Designers { get => _Designers; set => _Designers = value; }
        public List<clsAllItems> ItemList { get => _ItemList; set => _ItemList = value; } 
        public List<clsAllOrders> OrderList { get => _OrderList; set => _OrderList = value; }

        // >>}}}0> Singleton
        public static readonly frmDesigner Instance = new frmDesigner();

        private frmDesigner()
        {
            InitializeComponent();
        }

        public static void Run(string prDesignersName)
        {
            if (string.IsNullOrEmpty(prDesignersName))
            {
                Instance.SetDetails(new clsDesigners());
            }
            else
            {
                Instance.loadDesignerFormDB(prDesignersName);
            }
            Instance.Show();
        }

        private async void loadDesignerFormDB(string prDesignersName)
        {
            SetDetails(await ServiceClient.GetDesignerAsync(prDesignersName));
        }

        public async void SetDetails(clsDesigners prDesigners)
        {
            Designers = prDesigners;
            try
            {
                ItemList = await ServiceClient.GetDesignerItemsAsync(Designers.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);;
            }
        }

        private void UpdateDisplay()
        {

            lstItems.DataSource = null;
            if (_Designers.ItemList != null)
                lstItems.DataSource = _Designers.ItemList;
        }
    }
}
