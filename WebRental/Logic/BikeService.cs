using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRental.DAL;
using WebRental.Models;


namespace WebRental.Logic
{
    public class BikeService
    {
        TotalRentalRepo trRep = new TotalRentalRepo();
        public BikeService()
        {

        }

        //public TotalRental AddTotalRental(String customerName, DateTime RentalDate, bool Family, List<UnitRental> items)
        //{

        //    Customer customer = (from c in _context.Customers where c.Name == customerName select c).FirstOrDefault();

        //    if (customer == null)
        //    {
        //        customer = _context.Customers.Add(new Customer() { ID = Guid.NewGuid(), Name = customerName });
        //    }

        //    var TR = _context.TotalRentals.Add(new TotalRental(new Rates(), null)
        //    {
        //        customer = customer,
        //        IsFamilyRental = Family,
        //        RentalDate = RentalDate,
        //        RentalItems = items
        //    });

        //    _context.SaveChanges();

        //    return TR;
        //}

        public List<TotalRental> GetAllRentals()
        {
            return trRep.TotalRentalsGetAll();
        }

    }
}