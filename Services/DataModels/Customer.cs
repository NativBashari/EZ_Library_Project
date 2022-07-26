using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


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
        public byte[] Image { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
      


    }
}
