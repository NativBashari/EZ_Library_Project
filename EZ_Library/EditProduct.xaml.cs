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
using System.Windows.Shapes;
using static Services.DataModels.Enums;

namespace EZ_Library
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        public EditProduct()
        {
            InitializeComponent();
            categoryCb.ItemsSource = Enum.GetValues(typeof(Category));
            genreCb.ItemsSource = Enum.GetValues(typeof(Genre));
            topicCb.ItemsSource = Enum.GetValues(typeof(Topic));
        }

        private void CategoryCb_DropDownClosed(object sender, EventArgs e)
        {
            if (categoryCb.SelectedItem != null && categoryCb.SelectedItem.Equals(Category.Book))
            {
                topicgenretxt.Text = "Genre";
                printpublishtxt.Text = "Publish-Date";
                genreCb.Visibility = Visibility.Visible;
                topicCb.Visibility = Visibility.Hidden;
                printDp.Visibility = Visibility.Hidden;
                publishDp.Visibility = Visibility.Visible;
            }
            if (categoryCb.SelectedItem != null && categoryCb.SelectedItem.Equals(Category.Journal))
            {
                topicgenretxt.Text = "Topic";
                printpublishtxt.Text = "Print-Date";
                genreCb.Visibility = Visibility.Hidden;
                topicCb.Visibility = Visibility.Visible;
                printDp.Visibility = Visibility.Visible;
                publishDp.Visibility = Visibility.Hidden;
            }
        }
    }
}
