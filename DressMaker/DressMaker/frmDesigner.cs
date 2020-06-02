using DressMaker;
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
                UpdateForm();
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

        public void UpdateForm()
        {
            txtName.Text = _Designers.Name;
            txtPhone.Text = _Designers.Phone;
            UpdateDisplay();
        }
        // >>}})0> Buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
           int lcIndex = lstItems.SelectedIndex;
            try
            {
                    if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show(await ServiceClient.DeleteItem(lstItems.SelectedItem as clsAllItems));
                        loadDesignerFormDB(_Designers.Name);
                    frmDesigners.Instance.UpdateDisplay();
                    }
            }
            catch (Exception)
            {

                MessageBox.Show("ye");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clsAllItems lcDesignerItem = new clsAllItems();
            switch (cboPickState.Text)
            {
                case "Used":
                    lcDesignerItem.Type = "used";
                    lcDesignerItem.Designer = Designers.Name;
                    frmUsedItem.Run(lcDesignerItem);
                    break;
                case "New":
                    lcDesignerItem.Type = "new";
                    lcDesignerItem.Designer = Designers.Name;
                    frmNewItem.Run(lcDesignerItem);
                    break;
                default:
                    MessageBox.Show("Select Required");
                    break;
            }
            UpdateDisplay();

        }
    }
}
