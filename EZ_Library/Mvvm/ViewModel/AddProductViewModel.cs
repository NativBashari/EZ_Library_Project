using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Services;
using System;
using static Services.DataModels.Enums;

namespace EZ_Library.Mvvm.ViewModel
{
    public class AddProductViewModel: ViewModelBase
    {
        readonly IDataService dataService;
        public RelayCommand AddProductCommand { get; set; }
        public Category Category { get; set; }
        private string _title;

        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }
        public string Author { get; set; }
        public string Publishing { get; set; }
        public double Price { get; set; }
        public double RentPrice { get; set; }
        public Genre Genre { get; set; }
        public Topic Topic { get; set; }
        public DateTime PrintDate { get; set; }
        public DateTime PublishDate { get; set; }

        public AddProductViewModel(IDataService data)
        {
            dataService = data;
            AddProductCommand = new RelayCommand(AddProduct);
        }
        private void AddProduct()
        {
            dataService.AddToStock(Category , Title , Author, Publishing, Price, RentPrice, Genre, Topic, PrintDate, PublishDate);
        }
    }
}
