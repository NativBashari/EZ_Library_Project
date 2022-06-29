using Services.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DataService : IDataService
    {
        private static SqlProviderServices instance;
        
        public DataService()
        {
            instance = SqlProviderServices.Instance;
        }
        public bool AddToStock(Enums.Category category, string title, string author, string publishing, double price, double rentPrice, Enums.Genre genre, Enums.Topic topic, DateTime printDate, DateTime publishDate )
        {
            try
            {
                if (category.Equals(Enums.Category.Book))
                {
                    using(var Context = new EZ_LibraryContext())
                    {
                        Book book = new Book { Category = category, Title = title, Author = author, Publishing = publishing, Price = price, RentPrice = rentPrice, Genre = genre, PublishDate = publishDate, Availability = Enums.Availability.Available };
                        Context.Products.Add(book);
                        Context.SaveChanges();
                        return true;
                    }
                  
                }
                else if (category.Equals(Enums.Category.Journal))
                {
                    using (var Context = new EZ_LibraryContext())
                    {
                        Journal journal = new Journal { Category = category, Author = author, Availability = Enums.Availability.Available, Price = price, PrintDate = printDate, Publishing = publishing, RentPrice = rentPrice, Title = title, Topic = topic };
                        Context.Products.Add(journal);
                        Context.SaveChanges();
                        return true; 
                    }
                 }
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                
            }
            return false;
        }
        public void AddCustomer(string firstName, string lastName, string phoneNumber)
        {
            using (var Context = new EZ_LibraryContext())
            {
                Customer customer = new Customer { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Rentals = new List<Rental>() };
                Task.Run(() => Context.Customers.Add(customer));
                Context.SaveChanges(); 
            }
        }

        public bool CloseRent()
        {
            throw new NotImplementedException();
        }

        public bool OpenRent(Customer customer, Product product)
        {
            try
            {
                using (var Context = new EZ_LibraryContext())
                {
                    Context.Rentals.Add(new Rental
                    {
                        Customer = customer,
                        Product = product,
                        CustomerId = customer.Id,
                        EndDate = DateTime.Now.AddDays(7),
                        StartDate = DateTime.Now
                    });
                    Context.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {

            }
            return false;
            
        }

        public bool RemoveFromStock()
        {
            throw new NotImplementedException();
        }
        public async Task<IList<Product>> GetAllProducts()
        {
            using (var Context = new EZ_LibraryContext())
            {
                var products = Task.Run(() => Context.Products.ToList());
                return await products; 
            }
         
        }
        public async Task<IList<Customer>> GetAllCustomers()
        {
            using (var Context = new EZ_LibraryContext())
            {
                var customers = Task.Run(() => Context.Customers.ToList());
                return await customers; 
            }
        }

        public async Task<IList<Rental>> GetAllRentals()
        {
            using (var Context = new EZ_LibraryContext())
            {
                var rentals = Task.Run(() => Context.Rentals.ToList());
                return await rentals;
            }

        }
    }
}
