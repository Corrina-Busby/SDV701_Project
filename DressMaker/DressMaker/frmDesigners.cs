using System;
using System.Windows.Forms;

/// <summary>
/// Displays the Designers name, retrieves from database 
/// Select a designer to view specific items etc to that designer
/// Need to hide this form on opening another form and show when exiting the frmdesigner
/// </summary>
namespace SimplyFashionAdmin
{
    public sealed partial class frmDesigners : Form
    {
        // ><{{{0> Singleton
        private static readonly frmDesigners _Instance = new frmDesigners();

        private frmDesigners()
        {
            InitializeComponent();
        }    

        public static frmDesigners Instance
        {
            get { return frmDesigners._Instance; }
        }

        //  ><(((0> Update
        public async void UpdateDisplay()
        {
            try
            {
                lstDesigners.DataSource = null;
                lstDesigners.DataSource = await ServiceClient.GetDesignersNamesAsync();

             //   lblTotalValue.Text = Convert.ToString(GetTotalValue());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server error");
            }
        }

        // ><(((*> Methods
        private void frmDesigners_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void OpenDesignerForm()
        {
            string lcKey;
            lcKey = Convert.ToString(lstDesigners.SelectedItem);
            if (lcKey != null)
             try
            {
                frmDesigner.Run(lstDesigners.SelectedItem as string);
                    frmDesigners.Instance.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Please select a Designer Name.");
            }
        }
        //  ><(((*> Clickables
        private void lstDesigners_DoubleClick(object sender, EventArgs e)
        {
            OpenDesignerForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOpenSelectedDesigner_Click(object sender, EventArgs e)
        {
            OpenDesignerForm();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            frmPendingOrder.Instance.Show();           
        }
    }
}




//private decimal GetTotalValue()
//{
//    decimal lcTotal = 0;
//    foreach (clsDesigners lcDesigners in Values)
//    {
//        lcTotal += lcDesigners.TotalValue;
//    }
//    return lcTotal;
//}