using Services.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Services.DataModels.Enums;

namespace Services
{
    public class DataService : IDataService
    {
        private readonly INotifier notifier;
        readonly Repository repository = new Repository();
        private readonly ValidationService validation;
        void Provider() => _ = SqlProviderServices.Instance;
        public DataService(INotifier notif)
        {
            notifier = notif; 
            validation = new ValidationService(notifier,repository);
        }
        public async Task<IEnumerable<Rental>> GetOverdueRentals() => await Task.Run(() => repository.OverdueRentals);
        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.Run(() => repository.Products);
        public async Task<IEnumerable<Customer>> GetAllCustomers() => await Task.Run(() => repository.Customers);
        public async Task<IEnumerable<Rental>> GetAllRentals() => await Task.Run(() => repository.Rentals);
        public async Task<IEnumerable<Product>> FilterProducts(Category category, Genre genre, Topic topic, Availability availability) => await Task.Run(() => repository.FilterProducts(category, genre, topic, availability));

        public bool AddToStock(Enums.Category category, string title, string author, string publishing, double price, double rentPrice, Enums.Genre genre, Enums.Topic topic, DateTime printDate, DateTime publishDate)
        {
            if (!validation.ValidateProduct(title)) return false;
            try
            {
                if (category.Equals(Enums.Category.Book))
                {
                    Book book = new Book { Category = category, Title = title, Author = author, Publishing = publishing, Price = price, RentPrice = rentPrice, Genre = genre, PublishDate = publishDate, Availability = Enums.Availability.Available };
                    repository.AddProduct(book);
                    notifier.OnSucces("Product added successfully");
                    return true;
                }
                else if (category.Equals(Enums.Category.Journal))
                {
                    Journal journal = new Journal { Category = category, Author = author, Availability = Enums.Availability.Available, Price = price, PrintDate = printDate, Publishing = publishing, RentPrice = rentPrice, Title = title, Topic = topic };
                    repository.AddProduct(journal);
                    notifier.OnSucces("Product added successfully");
                    return true;
                }
            }
            catch (Exception ex)
            {
                notifier.OnError(ex.Message);
            }

            return false;
        }
        public  void AddCustomer(string firstName, string lastName, string phoneNumber, Image customerImage)
        {
            if (!validation.ValidateCustomer(firstName, lastName, phoneNumber)) return;         
            try
            {
                Customer customer = new Customer { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Rentals = new List<Rental>(), Image = ImageToBytes(customerImage)};
                Task.Run(() =>  repository.AddCustomer(customer));
            }
            catch (Exception ex)
            {
                notifier.OnError(ex.Message);
            }
        }

        public bool CloseRent(Rental rent)
        {
            try
            {               
                if (rent != null)
                {
                    repository.ClostRent(rent);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                notifier.OnError(ex.Message);
                Debug.WriteLine("Catch Exception");
            }
            return false;
        }

        public bool OpenRent(Customer cus, Product pro)
        {
            try
            {
                var customer = repository.Customers.Single(c => c.Id == cus.Id);
                var product = repository.Products.Single(p => p.Id == pro.Id);
                if (product.Availability == Availability.Rented)
                {
                    notifier.OnError("This product is unavailable");
                    return false;
                }
                repository.AddRental(new Rental
                {
                    Customer = customer,
                    Product = product,
                    EndDate = DateTime.Now.AddDays(7),
                    StartDate = DateTime.Now
                });
                product.Availability = Availability.Rented;
                notifier.OnSucces("Rental opened succesfully");
            }
            catch (Exception ex)
            {
                notifier.OnError(ex.Message);
            }
            return true;
        }        
        public void RemoveFromStock(Product product)
        {
            repository.RemoveProduct(product);
        }

        public byte[] ImageToBytes(Image image)
        {
            ImageConverter imageConverter = new ImageConverter();
            return (byte[])imageConverter.ConvertTo(image, typeof(byte[]));
        }

        public void UpdateCustomer(Customer customer)
        {
            Task.Run(() => repository.UpdateCustomer(customer));
            notifier.OnSucces("Customer updated succesfully");
        }

        public void UpdateProduct(Product product)
        {
            Task.Run(() => repository.UpdateProduct(product));
            notifier.OnSucces("Product updated succesfully");
        }
    }
}
 