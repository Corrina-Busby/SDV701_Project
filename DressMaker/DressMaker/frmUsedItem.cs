namespace SimplyFashionAdmin
{
    public sealed partial class frmUsedItem : SimplyFashionAdmin.frmItem
    {
        // Singleton
        public static readonly frmUsedItem Instance = new frmUsedItem();

        public frmUsedItem()
        {
            InitializeComponent();
        }

        public static void Run(clsAllItems prUsedDesignerItem)
        {
            Instance.SetDetails(prUsedDesignerItem);
        }

        protected override void UpdateForm()
        {
            base.UpdateForm();
            txtCondition.Text = _DesignerItem.State;           
        }

        protected override void pushData()
        {
            base.pushData();
            _DesignerItem.State = txtCondition.Text;
        }
    }
}
