using Services.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Services.DataModels.Enums;

namespace Services
{
    public interface IDataService
    {
        bool AddToStock(Enums.Category category, string title, string author, string publishing, double price, double rentPrice, Genre genre, Topic topic, DateTime printDate, DateTime publishDate);
        void AddCustomer(string firstName, string lastName, string phoneNumber);
        bool RemoveFromStock();
        bool CloseRent(Rental rental);
        bool OpenRent(Customer customer , Product product);
        Task<IEnumerable<Product>> FilterProducts(Category category, Genre genre, Topic topic, Availability availability);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<IEnumerable<Rental>> GetAllRentals();
        Task<IEnumerable<Rental>> GetOverdueRentals();
      

    }
}
