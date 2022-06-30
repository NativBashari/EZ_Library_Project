using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataModels
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Required]
        public  Customer Customer { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
}
