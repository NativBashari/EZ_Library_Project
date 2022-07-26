using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EZ_Library.Mvvm.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        Notifier notifier;
        public CustomersView()
        {
            InitializeComponent();
           notifier = new Notifier();
        }

        private void EditCustomer_btn_Click(object sender, RoutedEventArgs e)
        {
            if(lvCustomers.SelectedItem != null)
            {
                EditCustomer editCustomer = new EditCustomer();
                editCustomer.Show();
                
            }
            else notifier.OnError("Please select a customer from the list.");
        }
    }
}
