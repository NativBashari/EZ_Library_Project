using Services.DataModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Services
{

    public partial class EZ_LibraryContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public EZ_LibraryContext()
            : base("name=EZ_Library")
        {
        }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new NotImplementedException();            
        //}
    }
}
