using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataModels
{
    public class Customer
    {
        public Customer()
        {
            this.Rentals = new HashSet<Rental>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
