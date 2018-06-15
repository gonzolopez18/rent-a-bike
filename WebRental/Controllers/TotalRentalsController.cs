using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebRental.DAL;
using WebRental.Models;
using WebRental.Logic;

namespace WebRental.Controllers
{
    public class TotalRentalsController : Controller
    {
     
        // GET: TotalRentals
        public ActionResult Index()
        {
            Bike bike = Bikes.Bike_getbyID(Guid.Parse("F685D4A82231495BBEEC626C33E89242"));
            List<UnitRental> items = new List<UnitRental>();
            items.Add(new UnitRental(new Rates()) {  Bike = bike, InitDate = DateTime.Now, Quantity = 3, RentType = RentalType.DAILY });
            items.Add(new UnitRental(new Rates()) { Bike = bike, InitDate = DateTime.Now, Quantity = 1, RentType = RentalType.HOURLY });
            items.Add(new UnitRental(new Rates()) { Bike = bike, InitDate = DateTime.Now, Quantity = 6, RentType = RentalType.WEEKLY});

            BikeService.AddTotalRental("Gonzalo5", DateTime.Now, true, items);

            return View(BikeService.GetAllRentals());

     
        }

    }
}
