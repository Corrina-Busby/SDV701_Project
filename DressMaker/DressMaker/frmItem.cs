using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplyFashionAdmin
{
    public partial class frmItem : Form
    {
        private clsDesigners _Designers;
      //  private clsAllItems _DesignerItem;
     //   public clsAllItems DesignerItem { get => _DesignerItem; set => _DesignerItem = value; }
        public clsDesigners Designers { get => _Designers; set => _Designers = value; }

        public delegate void LoadDesignerItemFormDelegate(clsAllItems prDesignerItem);
        public static Dictionary<char, Delegate> _DesignerItemForm = new Dictionary<char, Delegate>
        {
          //  {'U', new LoadDesignerItemFormDelegate(frmNewDesignerItem.Run) },
         //   {'N', new LoadDesignerItemFormDelegate(frmUsedDesignerItem.Run) }
        };

        public static void DispatchDesignerItemForm(clsAllItems prDesignerItem)
        {
            _DesignerItemForm[prDesignerItem.Type].DynamicInvoke(prDesignerItem);
        }
        protected clsAllItems _DesignerItem;

        public frmItem()
        {
            InitializeComponent();
        }
        public void SetDetails(clsAllItems prDesignerItem)
        {
            _DesignerItem = prDesignerItem;
            UpdateForm();
            ShowDialog();
        }

        private async void btnSaveOK_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                pushData();
                _DesignerItem.LastModified = txtDateNow.Text;
                if(txtSKU.Enabled)
                    MessageBox.Show(await ServiceClient.PostItemAsync(_DesignerItem));
                else
                    MessageBox.Show(await ServiceClient.PutItemAsync(_DesignerItem));
                Close();
            }
            else
            {
                MessageBox.Show("Test");
            }
        }

        protected virtual void pushData()
        {
            _DesignerItem.SkuCode = txtSKU.Text;
            Designers.Name = txtDesignerNme.Text;
            _DesignerItem.ItemDetails = txtDescription.Text;
            _DesignerItem.LastModified = txtDateNow.Text;
            _DesignerItem.ItemName = txtItem.Text;
            _DesignerItem.QtyInStock = Convert.ToInt32(nudQuantity.Value);
            _DesignerItem.BuyPrice = nudPrice.Value;

        }

        protected virtual void UpdateForm()
        {
            txtSKU.Enabled = string.IsNullOrEmpty(_DesignerItem.Designer);
            txtSKU.Text = _DesignerItem.SkuCode;
            txtDesignerNme.Text = Designers.Name;
            txtDescription.Text = _DesignerItem.ItemDetails;
            txtDateNow.Text = _DesignerItem.LastModified;
            txtItem.Text = _DesignerItem.ItemName;
            nudQuantity.Value = _DesignerItem.QtyInStock;
            nudPrice.Value = _DesignerItem.BuyPrice;
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
