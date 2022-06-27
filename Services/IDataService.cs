using Services.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IDataService
    {
        bool AddToStock(Enums.Category category, string title, string author, string publishing, double price, double rentPrice, Enums.Genre genre, Enums.Topic topic, DateTime printDate, DateTime publishDate);
        void AddCustomer(string firstName, string lastName, string phoneNumber);
        bool RemoveFromStock();
        bool CloseRent();
        bool OpenRent(Customer customer , Product product);
        Task<IList<Product>> GetAllProducts();
        Task<IList<Customer>> GetAllCustomers();
        Task<IList<Rental>> GetAllRentals();
      

    }
}
