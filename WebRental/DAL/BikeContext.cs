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
        public BikeContext()
        {
        }
        public DbSet<TotalRental> TotalRentals;
        public DbSet<Customer> Customers;
        public DbSet<Bike> Bikes;
        

         protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}