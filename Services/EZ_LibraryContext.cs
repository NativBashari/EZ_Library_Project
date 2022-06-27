using Services.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Services
{
    public partial class EZ_LibraryContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public EZ_LibraryContext()
            : base("name=EZ_Library")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
