using Services.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static Services.DataModels.Enums;

namespace Services
{
    public class Repository
    {
        readonly EZ_LibraryContext data = new EZ_LibraryContext();
        public IEnumerable<Customer> Customers => data.Customers;
        public IEnumerable<Product> Products => data.Products;
        public IEnumerable<Rental> Rentals => data.Rentals;
        public IEnumerable<Rental> OverdueRentals => GetOverdueRentals();
       

        public void AddCustomer(Customer customer)
        {
            data.Customers.Add(customer);
            SaveChanges();
        }

        public void AddProduct(Product product)
        {
            data.Products.Add(product);
            SaveChanges();
        }
        public IEnumerable<Rental> GetOverdueRentals()
        {
            var overdue = new List<Rental>();
            foreach (var rental in Rentals)
            {
                if(rental.ReturnDate == null && DateTime.Now > rental.EndDate)
                {
                    overdue.Add(rental);
                }
            }
            return overdue;
        }

        internal void SaveChanges()
        {
            data.SaveChanges();
        }

        internal void AddRental(Rental rental)
        {
            data.Rentals.Add(rental);
            SaveChanges();
        }
        internal IEnumerable<Product> FilterProducts(Category category, Genre genre, Topic topic, Availability availability)
        {
            IEnumerable<Product> filtered = new List<Product>();
            
            if(category == Category.Book)
            {
                filtered = Products.OfType<Book>().Where(b => b.Genre == genre).Where(b => b.Availability == availability);
            }
            if(category == Category.Journal)
            {
               filtered = Products.OfType<Journal>().Where(j => j.Topic == topic).Where(j => j.Availability == availability);
            }
           
            return filtered;         
        }

        internal void UpdateCustomer(Customer customer)
        {
           var cus = Customers.Single(c => c.Id == customer.Id);
            cus.FirstName = customer.FirstName;
            cus.LastName = customer.LastName;
            cus.PhoneNumber = customer.PhoneNumber;
            cus.Image = customer.Image;
            SaveChanges();

        }

    }
}
