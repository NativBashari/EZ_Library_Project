using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Services;
using Services.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZ_Library.Mvvm.ViewModel
{
    public class ProductsViewModel: ViewModelBase
    {
        readonly IDataService dataService;
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }
        public Product SelectedProduct { get; set; }
        public Customer SelectedCustomer { get; set; }
        public RelayCommand OpenRentCommand { get; set; }
        public ProductsViewModel(IDataService service)
        {
            dataService = service;
            Products = new ObservableCollection<Product>();
            Customers = new ObservableCollection<Customer>();
            GetAllProducts();
            GetAllCustomers();
            OpenRentCommand = new RelayCommand(OpenRent);
        }

        private void OpenRent()
        {
            if (SelectedCustomer != null && SelectedProduct != null)
                dataService.OpenRent(SelectedCustomer, SelectedProduct);
        }

        private async void GetAllCustomers()
        {
            Customers.Clear();
            var customers = await dataService.GetAllCustomers();
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }

        private async void GetAllProducts()
        {
            Products.Clear();
            var products = await dataService.GetAllProducts();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
    }
}
