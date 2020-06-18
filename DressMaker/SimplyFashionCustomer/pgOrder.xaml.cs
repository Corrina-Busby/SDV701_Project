using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
/// <summary>
/// messagebox dialog https://docs.microsoft.com/en-us/uwp/api/windows.ui.popups.messagedialog?view=winrt-19041
/// </summary>
namespace SimplyFashionCustomer
{
    public sealed partial class pgOrder : Page
    {
        public pgOrder()
        {
            this.InitializeComponent();
        }

        // Variables
        private clsAllItems _Item;
        public clsAllItems Item { get => _Item; set => _Item = value; }


        // private void pushData()
        private async Task PostOrderToDB()
        {
            clsAllOrders lcOrder = new clsAllOrders() //need to post order
            {
                CustomerName = txtUserName.Text,
                Date = DateTime.Today,
                Email = txtEmail.Text,
                Quantity = Convert.ToInt16(txtOrderQty.Text),
                SkuCode = Item.SkuCode,
                Price = Item.BuyPrice,

            };
            try
            {
                int addedQty = Convert.ToInt16(txtOrderQty.Text);
                if (addedQty > Item.QtyInStock)
                {
                    txtOrderQty.Text = Item.QtyInStock.ToString();
                    MessageDialog lcMessage = new MessageDialog("Sorry");
                }
                string lcConfirmOrder = await ServiceClient.PostOrderAsync(lcOrder);
                lblMessage.Text = "";
                btnConfirmPurchase.IsEnabled = true;
                UpdateForm();
            }
            catch (Exception)
            {
                lblMessage.Text = "Enter qty";
                btnConfirmPurchase.IsEnabled = false;
            }
        }

        // Methods
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                try
                {
                    // DesignerItem = await ServiceClient.GetDesignerItemsAsync(e.Parameter.ToString());
                    // DispatchDesignerItemContent(DesignerItem as clsAllItems);
                    Item = e.Parameter as clsAllItems;
                    UpdateForm();
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

        // Buttons
        private void btnCancelPurchase_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgDesigners));
        }

        private async void btnConfirmPurchase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(txtOrderQty.Text);

                await PostOrderToDB();

                Frame.Navigate(typeof(pgDesigners));
            }
            catch (Exception ex)
            {
                lblMessage.Text = "ERROR: " + ex.Message;
            }
        }
        // Update
        private void UpdateForm()
        {
            if (Item != null)
            {
                lblOrderTitle.Text = Item.Designer;
                lblMessage.Text = "";

                // lblMessage.Text = Item
                lblItemName.Text = Item.ItemName;
                lblSKU.Text = Item.SkuCode;
                lblQtyInStock.Text = Item.QtyInStock.ToString();
                lblBuyPrice.Text = Item.BuyPrice.ToString("C");
            }

            //if (Item.QtyInStock == 0)
            //{
            //    btnConfirmPurchase.IsEnabled = false;
            //    MessageDialog lcMessage = new MessageDialog("Sorry out of stock");
            //    lcMessage.Commands.Add(new UICommand("Go back"));
            //}
            //else
            //{
            //    lblMessage.Text = "Order on its way";
            //}
        }
    }
}
