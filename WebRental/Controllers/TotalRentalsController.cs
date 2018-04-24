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
        private BikeContext db = new BikeContext();

        // GET: TotalRentals
        public ActionResult Index()
        {
            BikeService service = new BikeService(new BikeContext());
            Bike bike = new Bike() { ID = Guid.NewGuid(), Code ="BK_1", Available = true, WheelSize = 20  };
            List<UnitRental> items = new List<UnitRental>();
            items.Add(new UnitRental(new Rates()) { ID = Guid.NewGuid(), Bike = bike, InitDate = DateTime.Now, Quantity = 3, RentType = RentalType.DAILY });

            service.AddTotalRental("Gonzalo", DateTime.Now, true, items);


            //Rates rates = new Rates();
            //Bike bike = new Bike() { ID = Guid.NewGuid(), Code = "B_26_", Available = true, WheelSize = 26 };

            //UnitRental item = new UnitRental(rates) { ID = Guid.NewGuid(), Bike = bike, InitDate = System.DateTime.Now, Quantity = 1, RentType = RentalType.DAILY };
            //List<UnitRental> items = new List<UnitRental>();
            //items.Add(item);

            //TotalRental rent = new TotalRental(rates, null) { ID = 1, RentalDate = DateTime.Now, customer = null, IsFamilyRental = false };
            //rent.RentalItems = items;
            ////rent.RentalItems.Add(new UnitRental(rates) { ID = Guid.NewGuid(), Bike = bike, InitDate = System.DateTime.Now, Quantity =3, RentType = RentalType.HOURLY });

            //db.TotalRentals.Add(rent);
            //db.SaveChanges();


            return View(db.TotalRentals.ToList());
        }

        // GET: TotalRentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalRental totalRental = db.TotalRentals.Find(id);
            if (totalRental == null)
            {
                return HttpNotFound();
            }

            Customer yo = new Customer() { ID = Guid.NewGuid(), Name = "Gonzalo López 2" };
            totalRental.customer = yo;
            db.SaveChanges();

            return View(totalRental);
        }

        // GET: TotalRentals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TotalRentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RentalDate,IsFamilyRental")] TotalRental totalRental)
        {
            if (ModelState.IsValid)
            {
                db.TotalRentals.Add(totalRental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(totalRental);
        }

        // GET: TotalRentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalRental totalRental = db.TotalRentals.Find(id);
            if (totalRental == null)
            {
                return HttpNotFound();
            }
            return View(totalRental);
        }

        // POST: TotalRentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RentalDate,IsFamilyRental")] TotalRental totalRental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(totalRental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(totalRental);
        }

        // GET: TotalRentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalRental totalRental = db.TotalRentals.Find(id);
            if (totalRental == null)
            {
                return HttpNotFound();
            }
            return View(totalRental);
        }

        // POST: TotalRentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TotalRental totalRental = db.TotalRentals.Find(id);
            db.TotalRentals.Remove(totalRental);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
