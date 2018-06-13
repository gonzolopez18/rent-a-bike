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
        public virtual IDbSet<TotalRental> TotalRentals { get; set; }
        public virtual IDbSet<Customer> Customers { get; set; }
        public virtual IDbSet<Bike> Bikes { get; set; }
        

         protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}