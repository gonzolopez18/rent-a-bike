using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRental.Tests;

namespace WebRental.Models.Tests
{
    [TestClass()]
    public class TotalRentalTests
    {

        Helper helper = new Helper();

        [TestMethod()]
        public void CalculateTotalCost_0Units_NoFamily_Test()
        {
            Customer customer = helper.GetNewCustomer();
            Boolean ApplyFamily = false;
            DateTime day = new DateTime(2018, 04, 20);
            
            TotalRental totalRent = new TotalRental( new Rates(), null)
            {
                ID = 1,
                IsFamilyRental = ApplyFamily,
                RentalDate = day 
            } ;

            double actual = totalRent.CalculateTotalCost();
            double expected = 0;


            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTotalCost_1H_NoFamily_Test()
        {
            Customer customer = helper.GetNewCustomer();
            Boolean ApplyFamily = false;
            DateTime day = new DateTime(2018, 04, 20);

            List<UnitRental> items = new List<UnitRental>();
            items.Add(helper.GetUnitR(RentalType.HOURLY, 1));

            TotalRental totalRent = new TotalRental(new Rates(), items)
            {
                ID = 1,
                IsFamilyRental = ApplyFamily,
                RentalDate = day
            };
            
            double actual = totalRent.CalculateTotalCost();
            double expected = 5;


            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTotalCost_1H_Family_Test()
        {
            Customer customer = helper.GetNewCustomer();
            Boolean ApplyFamily = true;
            DateTime day = new DateTime(2018, 04, 20);

            List<UnitRental> items = new List<UnitRental>();
            items.Add(helper.GetUnitR(RentalType.HOURLY, 1));

            TotalRental totalRent = new TotalRental(new Rates(), items)
            {
                ID = 1,
                IsFamilyRental = ApplyFamily,
                RentalDate = day
            };

 
            double actual = totalRent.CalculateTotalCost();
            double expected = 5;


            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTotalCost_1H1D1W_NoFamily_Test()
        {
            Customer customer = helper.GetNewCustomer();
            Boolean ApplyFamily = false;
            DateTime day = new DateTime(2018, 04, 20);

            List<UnitRental> items = new List<UnitRental>();
            items.Add(helper.GetUnitR(RentalType.HOURLY, 1));
            items.Add(helper.GetUnitR(RentalType.DAILY, 1));
            items.Add(helper.GetUnitR(RentalType.WEEKLY, 1));

            TotalRental totalRent = new TotalRental(new Rates(), items)
            {
                ID = 1,
                IsFamilyRental = ApplyFamily,
                RentalDate = day
            };

            double actual = totalRent.CalculateTotalCost();
            double expected = 85;


            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTotalCost_1H1D1W_Family_Test()
        {
            Customer customer = helper.GetNewCustomer();
            Boolean ApplyFamily = true;
            DateTime day = new DateTime(2018, 04, 20);

            List<UnitRental> items = new List<UnitRental>();
            items.Add(helper.GetUnitR(RentalType.HOURLY, 1));
            items.Add(helper.GetUnitR(RentalType.DAILY, 1));
            items.Add(helper.GetUnitR(RentalType.WEEKLY, 1));

            TotalRental totalRent = new TotalRental(new Rates(), items)
            {
                ID = 1,
                IsFamilyRental = ApplyFamily,
                RentalDate = day
            };
 
            double actual = Math.Round( totalRent.CalculateTotalCost(), 1);
            double expected = 59.5;


            Assert.AreEqual(expected, actual);
        }

   
    }
}