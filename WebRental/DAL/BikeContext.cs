using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebRental.Models;
namespace WebRental.DAL
{
    public class BikeContext : DbContext
    {
        public BikeContext() : base()
        {
        }
        public DbSet<TotalRental> TotalRentals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        

         protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}