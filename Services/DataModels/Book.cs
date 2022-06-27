using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.DataModels.Enums;

namespace Services.DataModels
{
    public class Book : Product
    {
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public Genre Genre { get; set; }
    }
}
