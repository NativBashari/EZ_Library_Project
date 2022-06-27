using EZ_Library.Mvvm.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using Services;
using CommonServiceLocator;

namespace EZ_Library.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand OpenRentViewCommand { get; set; }
        public RelayCommand ProductsViewCommand { get; set; }
        public RelayCommand AddProductViewCommand { get; set; }
        public RelayCommand CustomersViewCommand { get; set; }
        public HomeViewModel HomeVm { get; set; }
        public RentalsViewModel RentalsVm { get; set; }
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                Set(ref _currentView, value);

            }
        }

        public MainViewModel(IDataService Service)
        {
            dataService = Service;
            CurrentView = ServiceLocator.Current.GetInstance<HomeViewModel>();
            HomeViewCommand = new RelayCommand(HomeView);
            OpenRentViewCommand = new RelayCommand(OpenRentView);
            ProductsViewCommand = new RelayCommand(ProductView);
            AddProductViewCommand = new RelayCommand(AddProductView);
            CustomersViewCommand = new RelayCommand(CustomersView);

        }

        private void CustomersView()
        {
            CurrentView = ServiceLocator.Current.GetInstance<CustomersViewModel>();
        }

        private void AddProductView()
        {
            CurrentView = ServiceLocator.Current.GetInstance<AddProductViewModel>();
        }

        private void ProductView()
        {
            CurrentView = ServiceLocator.Current.GetInstance<ProductsViewModel>();
        }

        private void OpenRentView()
        {
            CurrentView = ServiceLocator.Current.GetInstance<RentalsViewModel>();
        }

        private void HomeView()
        {
            CurrentView = ServiceLocator.Current.GetInstance<HomeViewModel>();
        }
    }
}