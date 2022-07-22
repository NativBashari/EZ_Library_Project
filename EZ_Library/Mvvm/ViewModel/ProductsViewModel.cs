using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Services;
using Services.DataModels;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using static Services.DataModels.Enums;

namespace EZ_Library.Mvvm.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }
        public Product SelectedProduct { get; set; }
        public Customer SelectedCustomer { get; set; }
        public RelayCommand OpenRentCommand { get; set; }
        public RelayCommand UpdateProductCommand { get; set; }
        public Category SelectedCategory { get; set; }
        public Genre SelectedGenre { get; set; }
        public Topic SelectedTopic { get; set; }
        public Availability SelectedAvailability { get; set; }
        public RelayCommand FilterCommand { get; set; }
        public ProductsViewModel(IDataService service)
        {
            dataService = service;
            Products = new ObservableCollection<Product>();
            Customers = new ObservableCollection<Customer>();
            GetAllProducts();
            GetAllCustomers();
            OpenRentCommand = new RelayCommand(OpenRent);
            FilterCommand = new RelayCommand(FilterProducts);
            UpdateProductCommand = new RelayCommand(UpdateProduct);
        }

        private void UpdateProduct()
        {
            throw new NotImplementedException();
        }

        private async void FilterProducts()
        {
            Products.Clear();
            var filtered = await dataService.FilterProducts(SelectedCategory, SelectedGenre, SelectedTopic, SelectedAvailability);
            foreach (var product in filtered)
            {
                Products.Add(product);
            }
        }

        private void OpenRent()
        {
            if (SelectedCustomer != null && SelectedProduct != null)
                dataService.OpenRent(SelectedCustomer, SelectedProduct);
            else MessageBox.Show("Please select item and customer");
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
