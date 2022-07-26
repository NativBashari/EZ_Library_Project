using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Services.DataModels;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Services.DataModels.Enums;
namespace ProjectUnitTest
{
    [TestClass]
    public class DataServiceUnitTest
    {
        IDataService service = new DataService(new DebuggerNotifier());
        Repository repository = new Repository();
        Image image;
        [TestMethod]
        public void AddToStockTest()
        {
            service.AddToStock(Category.Book, "AddToStockTest", "Author", "Publishing", 0, 0, Genre.Romantic, Topic.Politic, DateTime.Now, DateTime.Now);
            var pro = repository.Products.Single(p => p.Title == "AddToStockTest");
            Assert.IsNotNull(pro);
            Assert.IsInstanceOfType(pro, typeof(Book));
            repository.RemoveProduct(pro);
        }
        [TestMethod]
        public void AddCustomerTest()
        {
            service.AddCustomer("AddCustomerTest", "AddCustomerTest", "1234567891" , image);
            Thread.Sleep(3000);
            var cus = repository.Customers.SingleOrDefault(c=> c.FirstName == "AddCustomerTest");
            Assert.IsNotNull(cus);
            Assert.IsTrue(cus.LastName == "AddCustomerTest");
            Assert.IsTrue(cus.PhoneNumber == "1234567891");
            repository.RemoveCustomer(cus);
        }
        [TestMethod]
        public void OpenRentTest()
        {
            repository.AddCustomer(new Customer() { FirstName = "OpenRentTest", LastName = "OpenRentTest", PhoneNumber = "1234567891", Image = service.ImageToBytes(image) });
            repository.AddProduct(new Book() { Category = Category.Book, Title = "OpenRentTest", Author = "Author", Publishing = "Publishing", Price = 0, RentPrice = 0, Genre = Genre.Romantic, PublishDate = DateTime.Now, Availability = Availability.Available });
            var cus = repository.Customers.SingleOrDefault(c => c.FirstName == "OpenRentTest");
            var pro = repository.Products.Single(p => p.Title == "OpenRentTest");
            service.OpenRent(cus,pro);
            var rent = repository.Rentals.Single(r => r.Customer == cus);
            Assert.IsNotNull(rent);
            Assert.AreEqual(rent.Customer, cus);
            Assert.AreEqual(rent.Product, pro);
            repository.RemoveRental(rent);
            repository.RemoveCustomer(cus);
            repository.RemoveProduct(pro);
        }
        [TestMethod]
        public void CloseRentTest()
        {
            repository.AddCustomer(new Customer() { FirstName = "CloseRentTest", LastName = "CloseRentTest", PhoneNumber = "1234567891", Image = service.ImageToBytes(image) });
            repository.AddProduct(new Book() { Category = Category.Book, Title = "CloseRentTest", Author = "Author", Publishing = "Publishing", Price = 0, RentPrice = 0, Genre = Genre.Romantic, PublishDate = DateTime.Now, Availability = Availability.Available });
            var cus = repository.Customers.Single(c => c.FirstName == "CloseRentTest");
            var pro = repository.Products.Single(p => p.Title == "CloseRentTest");
            service.OpenRent(cus, pro);
            var rent = repository.Rentals.Single(r => r.Customer.Id == cus.Id);
            Assert.IsNull(rent.ReturnDate);
            Assert.IsTrue(service.CloseRent(rent));
            Thread.Sleep(3000);
            //Assert.IsNotNull(rent.ReturnDate);
            repository.RemoveRental(rent);
            repository.RemoveCustomer(cus);
            repository.RemoveProduct(pro);
        }       


    }
}
class DebuggerNotifier : INotifier
{
    public void OnError(string error)
    {
        //throw new NotImplementedException();
    }

    public void OnInfo(string info)
    {
       // throw new NotImplementedException();
    }

    public bool OnOption(string option, string optionTitle)
    {
        //throw new NotImplementedException();
        return true;
    }

    public void OnSucces(string succes)
    {
        //throw new NotImplementedException();
    }

    public void OnWarning(string warning)
    {
       // throw new NotImplementedException();
    }
}
