using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimplyFashionAdmin;

/// <summary>
/// Displays the Designers name, retrieves from database 
/// Select a designer to view specific items etc to that designer
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
            get { return _Instance; }
        }

        //  ><(((0> Update
        public async void UpdateDisplay()
        {
            try
            {
                lstDesigners.DataSource = null;
                lstDesigners.DataSource = await ServiceClient.GetDesignersNamesAsync();
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
            if (lstDesigners.SelectedItem != null)
            {
                frmDesigner.Run(lstDesigners.SelectedItem as string);
            }
            else
            {
                MessageBox.Show("Please select a Designer Name.");
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

        private void btnOpenSelectedDes_Click(object sender, EventArgs e)
        {
            OpenDesignerForm();
        }
    }
}
