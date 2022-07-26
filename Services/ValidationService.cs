using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    internal class ValidationService
    {
        private readonly INotifier notifier;
        private readonly Repository repository;
        public ValidationService(INotifier notifier, Repository repository)
        {
            this.notifier = notifier;
            this.repository = repository;

        }
        internal bool ValidateCustomer(string firstName, string lastName, string phoneNumber)
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
        internal bool ValidateProduct(string title)
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

    }
}
