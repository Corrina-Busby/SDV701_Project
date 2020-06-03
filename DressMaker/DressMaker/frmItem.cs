using System;
using System.Windows.Forms;

namespace SimplyFashionAdmin
{
    public partial class frmItem : Form
    {
        private clsDesigners _Designers;
        private clsAllItems _DesignerItem;
        public clsAllItems DesignerItem { get => _DesignerItem; set => _DesignerItem = value; }
        public clsDesigners Designers { get => _Designers; set => _Designers = value; }

        public frmItem()
        {
            InitializeComponent();
        }
        public void SetDetails(clsAllItems prDesignerItem)
        {
            DesignerItem = prDesignerItem;
            UpdateForm();
            ShowDialog();
        }

        private async void btnSaveOK_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                pushData();
                DesignerItem.LastModified = txtDateNow.Text;
                if(txtSKU.Enabled)
                    MessageBox.Show(await ServiceClient.PostItemAsync(DesignerItem));
                else
                    MessageBox.Show(await ServiceClient.PutItemAsync(DesignerItem));
                Close();
            }
            else
            {
                MessageBox.Show("Test");
            }
        }

        protected virtual void pushData()
        {
            DesignerItem.SkuCode = txtSKU.Text;
            Designers.Name = txtDesignerNme.Text;
            DesignerItem.ItemDetails = txtDescription.Text;
            DesignerItem.LastModified = txtDateNow.Text;
            DesignerItem.ItemName = txtItem.Text;
            DesignerItem.QtyInStock = Convert.ToInt32(nudQuantity.Value);
            DesignerItem.BuyPrice = nudPrice.Value;

        }

        protected virtual void UpdateForm()
        {
            txtSKU.Enabled = string.IsNullOrEmpty(DesignerItem.Designer);
            txtSKU.Text = DesignerItem.SkuCode;
            txtDesignerNme.Text = Designers.Name;
            txtDescription.Text = DesignerItem.ItemDetails;
            txtDateNow.Text = DesignerItem.LastModified;
            txtItem.Text = DesignerItem.ItemName;
            nudQuantity.Value = DesignerItem.QtyInStock;
            nudPrice.Value = DesignerItem.BuyPrice;
        }


        protected virtual bool IsValid()
        {
            if (txtDesignerNme.Text != "" && txtDescription.Text != "" && txtDateNow.Text != "" && txtItem.Text != "" && txtSKU.Text != "" && nudQuantity.Value != 0 && nudPrice.Value != 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Something is missing");
            }
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
