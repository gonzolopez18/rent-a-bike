using System.Data.Entity;
using WebRental.Models;

namespace WebRental.DAL
{
    public interface IBikeContext
    {
        DbSet<Bike> Bikes { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<TotalRental> TotalRentals { get; set; }
    }
}