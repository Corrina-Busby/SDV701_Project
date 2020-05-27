using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_admin
{
    public sealed partial class frmDesigners : Form
    {
        #region ><{{{0> Singleton
        private frmDesigners()
        {
            InitializeComponent();
        }
        private static readonly frmDesigners _Instance = new frmDesigners();

        public static frmDesigners Instance
        {
            get { return _Instance; }
        }
        #endregion

        #region ><(((*> Methods
        private void frmDesigners_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        public async void UpdateDisplay()
        {
            try
            {
                lstDesigners.DataSource = null;
                lstDesigners.DataSource = await ServiceClient.GetDesignerNamesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Check connection to server");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstDesigners_DoubleClick(object sender, EventArgs e)
        {
            OpenDesignerForm();
        }

        private void OpenDesignerForm()
        {
            if (lstDesigners.SelectedItem != null)
            {
                frmDesigner.Run(lstDesigners.SelectedItem as string);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            OpenDesignerForm();
        }


    }
}
