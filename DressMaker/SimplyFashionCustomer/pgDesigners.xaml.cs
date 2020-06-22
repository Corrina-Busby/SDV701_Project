using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SimplyFashionCustomer
{
    /// <summary>
    /// author's name: Corrina Busby
    /// date: 22/06/2020
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pgDesigners : Page
    {
        // Constructor
        public pgDesigners()
        {
            this.InitializeComponent();
        }

        // Load Event 
        private async void pgDesigners1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                lstDesigners.ItemsSource = await ServiceClient.GetDesignersNamesAsync();
            }
            catch (Exception ex)
            {

                txbMessage.Text = "Something has gone wrong" + ex.GetBaseException().Message;
            }
        }

        // Call methods
        public void OpenDesigners()
        {
            try
            {
                Frame.Navigate(typeof(pgDesigner), lstDesigners.SelectedItem);
            }
            catch (Exception ex)
            {
                txbMessage.Text = "Whoops Error" + ex.GetBaseException().Message;
            }
        }

        // Button
        private void btnOpenSelectedDesigners_Click(object sender, RoutedEventArgs e)
        {
            if (lstDesigners.SelectedItem != null)
            {
                OpenDesigners();
            }
        }

        private void lstDesigners_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            OpenDesigners();
        }
    }
}
