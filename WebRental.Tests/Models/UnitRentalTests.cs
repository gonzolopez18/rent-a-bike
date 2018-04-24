using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebRental.Models;
using WebRental.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRental.Models.Tests
{
    [TestClass()]
    public class Non_DB_Tests
    {
        Helper helper = new Helper();
        
        [TestMethod()]
        public void ChargeTest_Hourly_ZeroHour_Correct()
        {
            double expected = 0 ;
            IRates rates = new Rates();

            int Qty = 0;
            DateTime day =  new DateTime(2018, 04, 20);
            Bike bike = helper.GetNewBike();
            RentalType rtype = RentalType.HOURLY;

            UnitRental unit = new UnitRental(rates) { ID = Guid.NewGuid()
                , Bike = bike, InitDate = day, Quantity = Qty, RentType = rtype } ;

            double actual = unit.Charge();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ChargeTest_Hourly_OneHour_Correct()
        {
            double expected = 5;
            IRates rates = new Rates();

            int Qty = 1;
            DateTime day = new DateTime(2018, 04, 20);
            Bike bike = helper.GetNewBike();
            RentalType rtype = RentalType.HOURLY;

            UnitRental unit = new UnitRental(rates)
            {
                ID = Guid.NewGuid()
                ,
                Bike = bike,
                InitDate = day,
                Quantity = Qty,
                RentType = rtype
            };

            double actual = unit.Charge();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ChargeTest_Daily_ZeroHour_Correct()
        {
            double expected = 0;
            IRates rates = new Rates();

            int Qty = 0;
            DateTime day = new DateTime(2018, 04, 20);
            Bike bike = helper.GetNewBike();
            RentalType rtype = RentalType.DAILY;

            UnitRental unit = new UnitRental(rates)
            {
                ID = Guid.NewGuid(),
                Bike = bike,
                InitDate = day,
                Quantity = Qty,
                RentType = rtype
            };

            double actual = unit.Charge();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ChargeTest_Daily_TwoDays_Correct()
        {
            double expected = 40;
            IRates rates = new Rates();

            int Qty = 2;
            DateTime day = new DateTime(2018, 04, 20);
            Bike bike = helper.GetNewBike();
            RentalType rtype = RentalType.DAILY;

            UnitRental unit = new UnitRental(rates)
            {
                ID = Guid.NewGuid()
                ,
                Bike = bike,
                InitDate = day,
                Quantity = Qty,
                RentType = rtype
            };

            double actual = unit.Charge();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ChargeTest_Weekly_ZeroWeeks_Correct()
        {
            double expected = 0;
            IRates rates = new Rates();

            int Qty = 0;
            DateTime day = new DateTime(2018, 04, 20);
            Bike bike = helper.GetNewBike();
            RentalType rtype = RentalType.WEEKLY;

            UnitRental unit = new UnitRental(rates)
            {
                ID = Guid.NewGuid()
                ,
                Bike = bike,
                InitDate = day,
                Quantity = Qty,
                RentType = rtype
            };

            double actual = unit.Charge();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ChargeTest_Weekly_TwoWeeks_Correct()
        {
            double expected = 120;
            IRates rates = new Rates();

            int Qty = 2;
            DateTime day = new DateTime(2018, 04, 20);
            Bike bike = helper.GetNewBike();
            RentalType rtype = RentalType.WEEKLY;

            UnitRental unit = new UnitRental(rates)
            {
                ID = Guid.NewGuid()
                ,
                Bike = bike,
                InitDate = day,
                Quantity = Qty,
                RentType = rtype
            };

            double actual = unit.Charge();

            Assert.AreEqual(expected, actual);

        }


    }
}