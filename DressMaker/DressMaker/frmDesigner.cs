
using System;
using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// 
/// </summary>

namespace SimplyFashionAdmin
{
    public sealed partial class frmDesigner : Form
    {
        private clsDesigners _Designer;
        //  List<clsAllItems> _ItemList;
        private List<clsAllOrders> _OrderList;

        public clsDesigners Designers { get => _Designer; set => _Designer = value; }
        //public List<clsAllItems> ItemList { get => _ItemList; set => _ItemList = value; } 
        public List<clsAllOrders> OrderList { get => _OrderList; set => _OrderList = value; }

        private SortOption _SortBy;

       // private List<clsAllItems> _ItemsList = new List<clsAllItems>();

        // >>}}}0> Singleton
        public static readonly frmDesigner Instance = new frmDesigner();

        private frmDesigner()
        {
            InitializeComponent();
        }

        public void SortBySKU()
        {
            Designers.ItemList.Sort(clsSkuComparer.Instance);
            _SortBy = SortOption.SKU;
        }

        public void SortByDate()
        {
            Designers.ItemList.Sort(clsDateComparer.Instance);
            _SortBy = SortOption.DATE;
        }

        public SortOption SortBy
        {
            get { return _SortBy; }
            set { _SortBy = value; }
        }

        // >>}}}*> Methods
        public static void Run(string prDesignersName)
        {
            if (string.IsNullOrEmpty(prDesignersName))
            {
                Instance.SetDetails(new clsDesigners());
            }
            else
            {
                Instance.refreshFormFromDB(prDesignersName);
            }
            Instance.Show();
        }

        private async void refreshFormFromDB(string prDesignersName)
        {
            SetDetails(await ServiceClient.GetDesignerAsync(prDesignersName));
        }

        public void SetDetails(clsDesigners prDesigners)
        {
            Designers = prDesigners;
            try
            {
                lblDesignersName.Enabled = string.IsNullOrEmpty(_Designer.Name);
                UpdateForm();
                UpdateDisplay();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

        // >>}}}0> Updates
        private void UpdateDisplay()
        {

            

            if (SortBy == SortOption.SKU)
            {
                SortBySKU();
                //rbBySKU.Checked = true;
            }
            else if (SortBy == SortOption.DATE)
            {
                SortByDate();

                //rbByDate.Checked = true;
            }
            lstItems.DataSource = null;
            if (_Designer.ItemList != null)
                lstItems.DataSource = _Designer.ItemList;
            // lblTotal.Text = TotalSales().ToString();
        }
        //private decimal TotalSales()
        //{
        //    decimal lcTotalSales = 0;
        //    foreach (clsAllItems lcItemList in _ItemsList)
        //        lcTotalSales += lcItemList.BuyPrice;
        //    return lcTotalSales;
        //}

        public void UpdateForm()
        {
            lblDesignersName.Text = _Designer.Name;
            lblPhone.Text = _Designer.Phone;
        }

        private void pushData()
        {
            _Designer.Name = lblDesignersName.Text;
            _Designer.Phone = lblPhone.Text;
        }
        // >>}})0> Buttons
        private async void btnClose_Click(object sender, EventArgs e)
        {

           if (isValid() == true)
                try
                {
                    pushData();
                    if (lblDesignersName.Enabled)
                    {
                        MessageBox.Show(await ServiceClient.PutDesignerAsync(_Designer));
                        //MessageBox.Show(await ServiceClient.PostDesignerAsync(_Designer));
                        frmDesigners.Instance.UpdateDisplay();
                        lblDesignersName.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("You are about to leave this page");
                        //  MessageBox.Show(await ServiceClient.PutDesignerAsync(_Designer));
                        
                        frmDesigners.Instance.Show();
                        frmDesigner.Instance.Hide();
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }            
        }

        private Boolean isValid()
        {
            return true;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
           clsAllItems lcDesignerItem = lstItems.SelectedItem as clsAllItems;
            try
            {
                    if (lcDesignerItem != null && MessageBox.Show("Are you sure?", "Deleting Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        MessageBox.Show(await ServiceClient.DeleteItem(lcDesignerItem.SkuCode));
                        refreshFormFromDB(_Designer.Name);
                        frmDesigners.Instance.UpdateDisplay();
                    }
            }
            catch (Exception)
            {

                MessageBox.Show("Contact I.T. support");
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string lcReply = new InputBox(clsAllItems.FACTORY_PROMPT).Choice;
            if (!string.IsNullOrEmpty(lcReply)) 
            {
                clsAllItems lcItem = clsAllItems.NewDesignerItem(lcReply[0]);
                if (lcItem != null)
                {
                    if (lblDesignersName.Enabled)
                    {
                        pushData();
                        await ServiceClient.PostDesignerAsync(_Designer);
                        lblDesignersName.Enabled = false;
                    }
                    lcItem.Designer = _Designer.Name;
                    frmItem.DispatchDesignerItemForm(lcItem);
                    if (!string.IsNullOrEmpty(lcItem.ItemName))
                    {
                        refreshFormFromDB(_Designer.Name);
                        frmDesigners.Instance.UpdateDisplay();
                    }                                          
                }
            }
        }

        private void lstItems_DoubleClick(object sender, EventArgs e)
        {
            UpdateItem();
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            UpdateItem();
        }

        private void UpdateItem()
        {
            clsAllItems lcUpdateItem = lstItems.SelectedItem as clsAllItems;

            try
            {
                if (lcUpdateItem != null && MessageBox.Show("Hit Yes to edit this item", "Item has been updated", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmItem.DispatchDesignerItemForm(lcUpdateItem as clsAllItems);
                    refreshFormFromDB(_Designer.Name);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void rbBySKU_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBySKU.Checked)
            {
                SortBy = SortOption.SKU;
                UpdateDisplay();
            }       
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbByDate.Checked)
            {
                SortBy = SortOption.DATE;
                UpdateDisplay();
            }
        }
    }

    public enum SortOption {
        SKU,
        DATE
    }
}
