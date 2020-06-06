using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimplyFashionAdmin
{
    public sealed partial class frmNewItem : SimplyFashionAdmin.frmItem
    {
        // Singleton
        private static readonly frmNewItem Instance = new frmNewItem();

        private frmNewItem()
        {
            InitializeComponent();
        }

        public static void Run(clsAllItems prNewDesignerItem)
        {
            Instance.SetDetails(prNewDesignerItem);
        }

        protected override void UpdateForm()
        {
            base.UpdateForm();
            txtIntroduced.Text = _DesignerItem.Introduced;
        }

        protected override void pushData()
        {
            base.pushData();
            _DesignerItem.Introduced = txtIntroduced.Text;
        }
    }
}
