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
    public class RentalsViewModel: ViewModelBase
    {
        IDataService dataService;
        public ObservableCollection<Rental> Rentals { get; set; }
        public RelayCommand  CloseRentCommand { get; set; }
        public RelayCommand GetOverdueRentalsCommand { get; set; }
        public Rental SelectedRental { get; set; }
        public RentalsViewModel(IDataService service)
        {
            dataService = service;
            Rentals = new ObservableCollection<Rental>();
            CloseRentCommand = new RelayCommand(CloseRent);
            GetOverdueRentalsCommand = new RelayCommand(GetOverdueRentals);
            GetAllRentals();
        }

        private async void GetOverdueRentals()
        {
            Rentals.Clear();
            var overdue = await dataService.GetOverdueRentals();
            foreach (var item in overdue)
            {
                Rentals.Add(item);
            }
        }
        private void CloseRent()
        {
            dataService.CloseRent(SelectedRental);
        }

        private async void GetAllRentals()
        {
            Rentals.Clear();
            var rentals = await dataService.GetAllRentals();
            foreach (var rental in rentals)
            {
                Rentals.Add(rental);
            }
        }
    }
}
