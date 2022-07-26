using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Services.DataModels;
using System;
using System.Linq;
using static Services.DataModels.Enums;

namespace ProjectUnitTest
{
    [TestClass]
    public class RepositoryUnitTests
    {
        private readonly Repository repository = new Repository();
        Book book = new Book() { Category = Category.Book, Genre = Genre.Children, Author = "Author", Title = "Title", Price = 0, RentPrice = 0, PublishDate = DateTime.Now, Publishing = "Publishing", Availability = Availability.Available };
        Customer customer = new Customer() { FirstName = "FirstName", LastName = "LastName", PhoneNumber = "0566123526", Image = new byte[150] };


        [TestMethod]
        public void AddProductTest()
        {
            repository.AddProduct(book);
            var pro = repository.Products.Single(p => p.Id == book.Id);
            Assert.IsTrue(pro != null);
            Assert.AreEqual(book.Id, pro.Id);
            repository.RemoveProduct(book);
        }
        [TestMethod]
        public void AddCustomerTest()
        {
            repository.AddCustomer(customer);
            var cus = repository.Customers.Single(c => c.Id == customer.Id);
            Assert.IsNotNull(cus);
            Assert.AreEqual(cus.Id, customer.Id);
            repository.RemoveCustomer(customer);
        }
        [TestMethod]
        public void AddRentalTest()
        {
            Rental rental = new Rental() { Customer = customer, EndDate = DateTime.Now.AddDays(7), Product = book, StartDate = DateTime.Now };

            repository.AddRental(rental);
            var ren = repository.Rentals.Single(r => r.Id == rental.Id);
            Assert.IsNotNull(ren);
            Assert.AreEqual(rental.Id, ren.Id);
            repository.RemoveRental(rental);
            repository.RemoveProduct(book);
            repository.RemoveCustomer(customer);
        }
        [TestMethod]
        public void UpdateProductTest()
        {
            repository.AddProduct(book);
            book.Author = "Another Author";
            repository.UpdateProduct(book);
            var pro = repository.Products.Single(p => p.Id == book.Id);
            Assert.IsNotNull(pro);
            Assert.AreEqual(book.Author, pro.Author);
            repository.RemoveProduct(book);
           
        }
        [TestMethod]
        public void UpdateCustomerTest()
        {
            repository.AddCustomer(customer);
            customer.FirstName = "Another";
            repository.UpdateCustomer(customer);
            var cus = repository.Customers.Single(c => c.Id == customer.Id);
            Assert.IsNotNull(cus);
            Assert.AreEqual(cus.FirstName, cus.FirstName);
            repository.RemoveCustomer(customer);
        }
        [TestMethod]
        public void InitializedDbSets()
        {
            Assert.IsNotNull(repository.Rentals);
            Assert.IsNotNull(repository.Products);
            Assert.IsNotNull(repository.Customers);
        }
    }
}
