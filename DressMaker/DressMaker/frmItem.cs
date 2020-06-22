using System;
using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// author's name: Corrina Busby
/// date: 22/06/2020
/// </summary>

namespace SimplyFashionAdmin
{
    public partial class frmItem : Form
    {
        public delegate void LoadDesignerItemFormDelegate(clsAllItems prDesignerItem);
        public static Dictionary<char, Delegate> _DesignerItemForm = new Dictionary<char, Delegate>
        {
           {'N', new LoadDesignerItemFormDelegate(frmNewItem.Run)},
           {'U', new LoadDesignerItemFormDelegate(frmUsedItem.Run)}
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
            // different
           // lblDesignersName.Enabled = string.IsNullOrEmpty(_DesignerItem.Designer);
            
            UpdateForm();
            ShowDialog();
        }

        private async void btnSaveOK_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                pushData();
                if(lblDesignersName.Enabled)
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

        protected virtual void UpdateForm()
        {
            txtSKU.Text = _DesignerItem.SkuCode;
            lblDesignersName.Enabled = string.IsNullOrEmpty(_DesignerItem.SkuCode);
            lblDesignersName.Text = _DesignerItem.Designer;
            lblCreationDate.Text = _DesignerItem.LastModified.ToShortDateString();
            txtDescription.Text = _DesignerItem.ItemDetails;
            txtItemName.Text = _DesignerItem.ItemName;
            nudQuantity.Value = _DesignerItem.QtyInStock;
            nudPrice.Value = _DesignerItem.BuyPrice;
        }

        protected virtual void pushData()
        {
            _DesignerItem.SkuCode = txtSKU.Text;
            _DesignerItem.Designer = lblDesignersName.Text;
            _DesignerItem.ItemDetails = txtDescription.Text;
            _DesignerItem.ItemName = txtItemName.Text;
            _DesignerItem.QtyInStock = Convert.ToInt32(nudQuantity.Value);
            _DesignerItem.BuyPrice = nudPrice.Value;

        }

        protected virtual bool IsValid()
        {
          //  if (lblDesignersName.Text != "" && txtDescription.Text != "" && txtDateNow.Text != "" && txtItemName.Text != "" && txtSKU.Text != "" && nudQuantity.Value != 0 && nudPrice.Value != 0)
            {
                return true;
            }
            //else
            //{
            //    MessageBox.Show("Something is missing");
            //}
            //return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
