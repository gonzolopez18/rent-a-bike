using System.Data.Entity;
using WebRental.Models;

namespace WebRental.DAL
{
    public interface IBikeContext
    {
        IDbSet<Bike> Bikes { get; set; }
        IDbSet<Customer> Customers { get; set; }
        IDbSet<TotalRental> TotalRentals { get; set; }
        int SaveChanges();
    }
}