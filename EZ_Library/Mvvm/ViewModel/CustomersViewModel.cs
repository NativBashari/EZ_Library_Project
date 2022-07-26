using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Services;
using Services.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace EZ_Library.Mvvm.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Rental> Rentals { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public RelayCommand AddCustomerCommand { get; set; }
        public RelayCommand UploadImageCommand { get; set; }
        public RelayCommand UpdateCustomerDetailsCommand { get; set; }
        private Image _customerImageToShow;
        public Image CustomerImageToShow
        {
            get { return _customerImageToShow; }
            set
            {
                Set(ref _customerImageToShow, value);
            }
        }
        System.Drawing.Image CustomerImageToSave;

        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                GetCustomerRentalsHistory();
            }
        }
        public CustomersViewModel(IDataService service)
        {
            dataService = service;
            Customers = new ObservableCollection<Customer>();
            Rentals = new ObservableCollection<Rental>();
            AddCustomerCommand = new RelayCommand(AddCustomer);
            UploadImageCommand = new RelayCommand(UploadImage);
            UpdateCustomerDetailsCommand = new RelayCommand(UpdateCustomer);
            CustomerImageToShow = new Image();
            GetAllCustomers();
        }

        private void UpdateCustomer()
        {
            dataService.UpdateCustomer(SelectedCustomer);
        }

        private void UploadImage()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Select a picture";
            openFile.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                      "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                      "Portable Network Graphic (*.png)|*.png";
            if (openFile.ShowDialog() == true)
            {
                CustomerImageToShow.Source = new BitmapImage(new Uri(openFile.FileName));
                CustomerImageToSave = System.Drawing.Image.FromFile(openFile.FileName);
            }

        }

        private void GetCustomerRentalsHistory()
        {
            Rentals.Clear();
            foreach (var r in SelectedCustomer.Rentals)
            {
                Rentals.Add(r);
            }
        }
        private async void GetAllCustomers()
        {
            Customers.Clear();
            var custumers = await dataService.GetAllCustomers();
            foreach (var c in custumers)
            {
                Customers.Add(c);
            }
        }

        private void AddCustomer()
        {
            dataService.AddCustomer(FirstName, LastName, PhoneNumber, CustomerImageToSave);
        }
    }
}
