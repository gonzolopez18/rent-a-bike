using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRental.Models;

namespace WebRental.Tests
{
    public class Helper
    {

        public Bike GetNewBike()
        {
            return new Bike() { ID = Guid.NewGuid(), Available = true, Code = "Test Bike", WheelSize = 20 };
        }
        public Customer GetNewCustomer()
        {
            return new Customer() { ID = Guid.NewGuid(), Name = "Tester Customer" };
        }

        public UnitRental GetUnitR( RentalType rtype, int Qty)
        {
            DateTime day = new DateTime(2018, 04, 20);
            Bike bike = GetNewBike();
            UnitRental unit = new UnitRental(new Rates())
            {
                ID = Guid.NewGuid()
                ,
                Bike = bike,
                InitDate = day,
                Quantity = Qty,
                RentType = rtype
            };
            return unit;
           
        }
    }
}
