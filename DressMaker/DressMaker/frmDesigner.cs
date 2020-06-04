
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
        private List<clsAllItems> _ItemList;
        private List<clsAllOrders> _OrderList;

        public clsDesigners Designers { get => _Designer; set => _Designer = value; }
        public List<clsAllItems> ItemList { get => _ItemList; set => _ItemList = value; } 
        public List<clsAllOrders> OrderList { get => _OrderList; set => _OrderList = value; }

        // >>}}}0> Singleton
        public static readonly frmDesigner Instance = new frmDesigner();

        private frmDesigner()
        {
            InitializeComponent();
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
             //   ItemList = await ServiceClient.GetDesignerItemsAsync(Designers.Name);
                UpdateDisplay();
                UpdateForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

        // >>}}}0> Updates
        private void UpdateDisplay()
        {
            lstItems.DataSource = null;
            if (_Designer.ItemList != null)
                lstItems.DataSource = _Designer.ItemList;
        }

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
                        refreshFormFromDB(_Designer.Name);
                    frmDesigners.Instance.UpdateDisplay();
                    }
            }
            catch (Exception)
            {

                MessageBox.Show("Contact I.T. support");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lcReply = new InputBox(clsAllItems.FACTORY_PROMPT).Choice;
            if (!string.IsNullOrEmpty(lcReply)) 
            {
                clsAllItems lcItemType = clsAllItems.NewDesignerItem(lcReply[0]);
                if (lcItemType != null)
                {
                    if (lblDesignersName.Enabled)
                    {
                        lcItemType.Designer = _Designer.Name;
                        frmItem.DispatchDesignerItemForm(lcItemType);
                        if (!string.IsNullOrEmpty(lcItemType.Designer))
                        {
                            refreshFormFromDB(_Designer.Name);
                            frmDesigners.Instance.UpdateDisplay();
                        }
                        
                    }
                }
            }
        }
    }
}


//clsAllItems lcDesignerItem = new clsAllItems();
//            switch (cboPickState.Text)
//            {
//                case "Used":
//                    lcDesignerItem.Type = "used";
//                    lcDesignerItem.Designer = Designers.Name;
//                 //   frmUsedItem.Run(lcDesignerItem);
//                    break;
//                case "New":
//                    lcDesignerItem.Type = "new";
//                    lcDesignerItem.Designer = Designers.Name;
//                  //  frmNewItem.Run(lcDesignerItem);
//                    break;
//                default:
//                    MessageBox.Show("Select Required");
//                    break;
//            }
//            UpdateDisplay();
