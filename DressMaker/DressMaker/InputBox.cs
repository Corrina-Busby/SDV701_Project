using System;
using System.Windows.Forms;

namespace SimplyFashionAdmin
{
    public partial class InputBox : Form
    {
        private string _Choice;

        public InputBox(string prQuestion)
        {
            InitializeComponent();
            lblQuestion.Text = prQuestion;
            lblError.Text = "";
            txtChoice.Focus();
            ShowDialog();
        }

        public string Choice
        {
            get { return _Choice; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _Choice = txtChoice.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
