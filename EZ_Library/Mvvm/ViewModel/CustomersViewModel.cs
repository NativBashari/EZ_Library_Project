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
    public class CustomersViewModel: ViewModelBase
    {
        readonly IDataService dataService;
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Rental> Rentals { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public RelayCommand AddCustomerCommand { get; set; }
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

        private void GetCustomerRentalsHistory()
        {
            Rentals.Clear();
            foreach(var r in SelectedCustomer.Rentals)
            {
                Rentals.Add(r);
            }
        }

        public CustomersViewModel(IDataService service)
        {
            dataService = service;
            Customers = new ObservableCollection<Customer>();
            Rentals = new ObservableCollection<Rental>();
            AddCustomerCommand = new RelayCommand(AddCustomer);
            GetAllCustomers();
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
            dataService.AddCustomer(FirstName, LastName, PhoneNumber);
        }
    }
}
