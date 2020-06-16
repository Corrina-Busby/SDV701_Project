using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SimplyFashionCustomer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class pgDesignerItem : Page
    {
        private delegate void LoadDesignerItemControlDelegate(clsAllItems prDesignerItem);
        private Dictionary<char, Delegate> _DesignerItemContent;
        private void DispatchDesignerItemContent(clsAllItems prDesignerItem)
        {
            _DesignerItemContent[prDesignerItem.Type].DynamicInvoke(prDesignerItem);
            UpdateForm();
        }

        // Variables
        private clsAllItems _DesignerItem;
        public clsAllItems DesignerItem { get => _DesignerItem; set => _DesignerItem = value; }

        // Update
        private void UpdateForm()
        {
            lblMessage.Text = "";
            lblDesignerName.Text = DesignerItem.Designer;
            lblSKU.Text = DesignerItem.SkuCode;
            lblItemName.Text = DesignerItem.ItemName;
            lblItemDetails.Text = DesignerItem.ItemDetails;
            lblQtyInStock.Text = DesignerItem.QtyInStock.ToString();
            lblNzPrice.Text = DesignerItem.BuyPrice.ToString();

        }

        // Constructor
        public pgDesignerItem()
        {
            InitializeComponent();

            _DesignerItemContent = new Dictionary<char, Delegate>
            {
                {'N', new LoadDesignerItemControlDelegate(RunNewItem)},
                {'U', new LoadDesignerItemControlDelegate(RunUsedItem)}
            };

        }

        // Buttons
        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgOrder), DesignerItem);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgDesigner), DesignerItem.Designer);
        }

        // Methods

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                try
                {
                    //        DesignerItem = await ServiceClient.GetDesignerItemsAsync(e.Parameter.ToString());
                    //                    DispatchDesignerItemContent(DesignerItem as clsAllItems);
                    _DesignerItem = e.Parameter as clsAllItems;

                    DispatchDesignerItemContent(_DesignerItem);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.GetBaseException().Message;
                }
            }
            else
            {
                lblMessage.Text = "Error";
            }
        }

        // User Controls
        private void RunNewItem(clsAllItems prDesignerItem)
        {
            ctcDesignerItemSpecs.Content = new ucNewItem();
        }

        private void RunUsedItem(clsAllItems prDesignerItem)
        {
            ctcDesignerItemSpecs.Content = new ucUsedItem();
        }
    }
}
