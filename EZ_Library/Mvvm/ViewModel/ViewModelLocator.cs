

using CommonServiceLocator;
using EZ_Library.Mvvm.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using ProjectUnitTest;
using Services;

namespace EZ_Library.ViewModel
{

    public class ViewModelLocator 
    {
  
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<INotifier,Notifier>();
            SimpleIoc.Default.Register<IDataService, DataService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<RentalsViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<ProductsViewModel>();
            SimpleIoc.Default.Register<AddProductViewModel>();
            SimpleIoc.Default.Register<CustomersViewModel>();
            


        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public RentalsViewModel Rentals => ServiceLocator.Current.GetInstance<RentalsViewModel>();
        public ProductsViewModel Products => ServiceLocator.Current.GetInstance<ProductsViewModel>();
        public AddProductViewModel AddProduct => ServiceLocator.Current.GetInstance<AddProductViewModel>();
        public CustomersViewModel Customers => ServiceLocator.Current.GetInstance<CustomersViewModel>();

        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}