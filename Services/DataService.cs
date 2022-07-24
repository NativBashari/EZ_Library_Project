using Services.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
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
        void Provider() => _ = SqlProviderServices.Instance;
        public DataService(INotifier notif)
        {
            notifier = notif;
        }
        public bool AddToStock(Enums.Category category, string title, string author, string publishing, double price, double rentPrice, Enums.Genre genre, Enums.Topic topic, DateTime printDate, DateTime publishDate)
        {
            if (!ValidateProduct(title)) return false;
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
        public async void AddCustomer(string firstName, string lastName, string phoneNumber, Image customerImage)
        {
            if (!ValidateCustomer(firstName, lastName, phoneNumber)) return;         
            try
            {
                Customer customer = new Customer { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Rentals = new List<Rental>(), Image = ImageToBytes(customerImage)};
                await Task.Run(() => repository.AddCustomer(customer));
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
                var rental = repository.Rentals.Single(r => r.Id == rent.Id);               
                if (rental != null)
                {
                    rental.ReturnDate = DateTime.Now;
                    rental.Product.Availability = Availability.Available;
                    repository.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                notifier.OnError(ex.Message);
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
        

        public bool RemoveFromStock()
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Rental>> GetOverdueRentals() => await Task.Run(() => repository.OverdueRentals);
        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.Run(() => repository.Products);

        public async Task<IEnumerable<Customer>> GetAllCustomers() => await Task.Run(() => repository.Customers);
        public async Task<IEnumerable<Rental>> GetAllRentals() => await Task.Run(() => repository.Rentals);

        private bool ValidateCustomer(string firstName, string lastName, string phoneNumber)
        {
            if (Regex.IsMatch(firstName, @"^\d+$") || Regex.IsMatch(lastName, @"^\d+$"))
            {
                notifier.OnError("The first and last name fields cannot contain numbers");
                return false;
            }
            if (!Regex.IsMatch(phoneNumber, @"^[0-9]{10}$"))
            {
                notifier.OnError("The phone number is not valid");
                return false;
            }

            foreach (var c in repository.Customers)
            {
                if (c.FirstName == firstName && c.LastName == lastName && c.PhoneNumber == phoneNumber)
                {
                    notifier.OnError("The customer is already in the database");
                    return false;
                }
            }
            return true;
        }
        private bool ValidateProduct(string title)
        {
            foreach (var p in repository.Products)
            {
                if (p.Title == title)
                {
                    if (!notifier.OnOption("There is a product in stock with the same title, would you like to add anyway?", "Product duplication")) return false;
                }
            }
            return true;
        }
        public async Task<IEnumerable<Product>> FilterProducts(Category category, Genre genre, Topic topic, Availability availability) => await Task.Run(() => repository.FilterProducts(category, genre, topic, availability));

        byte[] ImageToBytes(Image image)
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
            throw new NotImplementedException();
        }
    }
}
 