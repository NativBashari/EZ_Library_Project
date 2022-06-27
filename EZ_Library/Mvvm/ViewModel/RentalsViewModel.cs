using GalaSoft.MvvmLight;
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
        public RentalsViewModel(IDataService service)
        {
            dataService = service;
            Rentals = new ObservableCollection<Rental>();
            GetAllRentals();
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
