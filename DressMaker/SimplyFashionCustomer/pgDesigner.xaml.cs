using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SimplyFashionCustomer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgDesigner : Page
    {
        // Variables
        private clsDesigners _Designer;
        //private List<clsAllItems> _ItemList;

        //     public clsDesigners DesignerObject { get => _Designer; set => _Designer = value; }
        //public List<clsAllItems> ItemList { get => _ItemList; set => _ItemList = value; }

        // Constructor
        public pgDesigner()
        {
            this.InitializeComponent();
        }

        // Navigation

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode == NavigationMode.New)
                try
                {
                    if (e.Parameter != null)
                    {
                        string lcDesignersName = e.Parameter.ToString();
                        _Designer = await ServiceClient.GetDesignerAsync(lcDesignersName);
                        UpdateForm();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.GetBaseException().Message;
                }
        }

        // Methods
        private void SetItemList()
        {
            lstDesigner.ItemsSource = null;
            try
            {
                //ItemList = await ServiceClient.GetDesignerItemsAsync(Designers.Name);
                //if (ItemList != null)
                //{
                //    List<string> lcItemNames = new List<string>();
                //    foreach (clsAllItems item in ItemList)
                //    {
                //        lcItemNames.Add(item.ItemName + " " + item.Type + " " + item.BuyPrice);
                //    }
                //    lstDesigner.ItemsSource = lcItemNames;
                //}

                if (_Designer.ItemList != null)
                    lstDesigner.ItemsSource = _Designer.ItemList;
                else
                {
                    lblMessage.Text = "Sorry currently out of stock";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.GetBaseException().Message;
            }
        }

        public void OpenSelectedDesignerItem()
        {
            try
            {
                //string lcDesignerItemId = ItemList[lstDesigner.SelectedIndex].ItemName;
                //Frame.Navigate(typeof(pgDesignerItem), lcDesignerItemId);

                Frame.Navigate(typeof(pgDesignerItem), lstDesigner.SelectedItem as clsAllItems);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "yolo" + ex.GetBaseException().Message;
            }
        }

        // Update
        private void UpdateForm()
        {
            if (_Designer != null)  //  why is designer null upon return from item page???
            {
                lblDesignersName.Text = _Designer.Name;
                lblMessage.Text = "";

                SetItemList();
            }
        }

        private void lstDesigner_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            OpenSelectedDesignerItem();
        }

        private void btnOpenDesignerItem_Click(object sender, RoutedEventArgs e)
        {
            OpenSelectedDesignerItem();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pgDesigners));
        }
    }
}
