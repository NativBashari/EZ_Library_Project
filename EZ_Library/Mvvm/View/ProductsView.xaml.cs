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
using static Services.DataModels.Enums;

namespace EZ_Library.Mvvm.View
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        readonly Notifier notifier;
        public ProductsView()
        {
            InitializeComponent();
            categoryCb.ItemsSource = Enum.GetValues(typeof(Category));
            genreCb.ItemsSource= Enum.GetValues(typeof(Genre));
            topicCb.ItemsSource =Enum.GetValues(typeof(Topic));
            availabilityCb.ItemsSource =Enum.GetValues(typeof(Availability));
            notifier = new Notifier();
        }

        private void EditProduct_btn_Click(object sender, RoutedEventArgs e)
        {
            if (lvProducts.SelectedItem != null)
            {
                EditProduct editProduct = new EditProduct();
                editProduct.Show();
            }
            else notifier.OnError("Please select product from the list.");
        }
    }
}
