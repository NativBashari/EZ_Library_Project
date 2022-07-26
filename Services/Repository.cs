using Services.DataModels;
using System;
using System.Collections.Generic;
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
        public  IEnumerable<Rental> GetOverdueRentals()
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
        public void RemoveProduct(Product product)
        {
            data.Products.Remove(product);
            SaveChanges();
        }
        public void RemoveCustomer(Customer customer)
        {
            data.Customers.Remove(customer);
            SaveChanges();
        }
        public void RemoveRental(Rental rental)
        {
            data.Rentals.Remove(rental);
            SaveChanges();
        }
        public void ClostRent(Rental rental)
        {
            var rent = Rentals.Single(r => r.Id == rental.Id);
            rent.ReturnDate = DateTime.Now;
            rent.Product.Availability = Availability.Available;
            SaveChanges();

        }
        public void SaveChanges()
        {
            data.SaveChanges();
        }

        public void AddRental(Rental rental)
        {
            data.Rentals.Add(rental);
            SaveChanges();
        }
        public IEnumerable<Product> FilterProducts(Category category, Genre genre, Topic topic, Availability availability)
        {
            IEnumerable<Product> filtered = new List<Product>();

            if (category == Category.Book)
            {
                filtered = Products.OfType<Book>().Where(b => b.Genre == genre).Where(b => b.Availability == availability);
            }
            if (category == Category.Journal)
            {
                filtered = Products.OfType<Journal>().Where(j => j.Topic == topic).Where(j => j.Availability == availability);
            }

            return filtered;
        }

        public void UpdateCustomer(Customer customer)
        {
           var cus = Customers.Single(c => c.Id == customer.Id);
            cus.FirstName = customer.FirstName;
            cus.LastName = customer.LastName;
            cus.PhoneNumber = customer.PhoneNumber;
            cus.Image = customer.Image;
            SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            if (product.Category == Category.Book)
            {
                var pro = Products.OfType<Book>().Single(b=> b.Id == product.Id);
                var p = (Book)product;
                pro.RentPrice = p.RentPrice;
                pro.Price = p.Price;
                pro.Category = p.Category;
                pro.Author = p.Author;
                pro.Publishing = p.Publishing;
                pro.Title = p.Title;
                pro.Genre = p.Genre;
                pro.PublishDate = p.PublishDate;
            }
            else
            {
                var pro = Products.OfType<Journal>().Single(j => j.Id == product.Id);
                var p = (Journal)product;
                pro.RentPrice = p.RentPrice;
                pro.Price = p.Price;
                pro.Category = p.Category;
                pro.Author = p.Author;
                pro.Publishing = p.Publishing;
                pro.Title = p.Title;
                pro.Topic = p.Topic;
                pro.PrintDate = p.PrintDate;
            }              
            SaveChanges();
        }

    }
}
