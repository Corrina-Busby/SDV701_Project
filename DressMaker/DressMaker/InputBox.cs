using System;
using System.Windows.Forms;

/// <summary>
/// author's name: Corrina Busby
/// date: 22/06/2020
/// </summary>

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
