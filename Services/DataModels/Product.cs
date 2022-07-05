using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Services.DataModels.Enums;

namespace Services.DataModels
{
    public abstract class Product
    {
        public int Id { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        [MaxLength(20)]
        public string Author { get; set; }
        [Required]
        [MaxLength(25)]
        public string Publishing { get; set; }
        public double Price { get; set; }
        public double RentPrice { get; set; }
        [Required]
        public Availability Availability { get; set; }

    }

}
