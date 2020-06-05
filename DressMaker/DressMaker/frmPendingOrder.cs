using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimplyFashionAdmin
{
    public sealed partial class frmPendingOrder : Form
    {
        // >>}}}0> Singleton
        private frmPendingOrder()

        {
            InitializeComponent();
        }

        public static readonly frmPendingOrder Instance = new frmPendingOrder();
        
        // Vars
        private List<clsAllOrders> _OrderList = new List<clsAllOrders>();        

        // Methods
        private void frmPendingOrder_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        // Updates
        public async void UpdateDisplay()
        {
            _OrderList = await ServiceClient.GetOrderAsync();
            try
            {                
                lstOrderView.DataSource = null;
                lstOrderView.DataSource = _OrderList;
                lblTotalSales.Text = TotalSales().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Breakpoint, Error");
            }
        }

        public decimal TotalSales()
        {
            decimal lcTotalSales = 0;
            foreach (clsAllOrders lcOrders in _OrderList)
                lcTotalSales += lcOrders.Price;
            return lcTotalSales;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int lcIndex = lstOrderView.SelectedIndex;
            try
            {
                if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                 //   MessageBox.Show(await ServiceClient.DeleteOrder(lstOrderView.SelectedItem as clsAllOrders));
                   
                    frmPendingOrder.Instance.UpdateDisplay();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Contact I.T. support");
            }
        }
    }
}
