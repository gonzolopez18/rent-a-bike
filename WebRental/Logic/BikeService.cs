using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using WebRental.DAL;
using WebRental.Models;


namespace WebRental.Logic
{
    public class BikeService
    {

        public static TotalRental AddTotalRental(String customerName, DateTime RentalDate, bool Family, List<UnitRental> items)
        {
            try { 


                    var TR = new TotalRental(new Rates(), null)
                    {
                        customer = new Customer() { Name = customerName },
                        IsFamilyRental = Family,
                        RentalDate = RentalDate,
                        RentalItems = items
                    };

                    using (TransactionScope scope = new TransactionScope())
                    {

                        Customers.Add(TR.customer);

                        TotalRentals.Add(TR);

                        foreach (UnitRental ur in TR.RentalItems)
                        {
                            ur.totalRentalID = TR.ID;
                            UnitRentals.Add(ur);
                        }

                        scope.Complete();

                        return TR;

                    }

            }
            catch (TransactionAbortedException tex)
            {
                throw tex;
             }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public static List<TotalRental> GetAllRentals()
        {
            return TotalRentals.TotalRentalsGetAll();
        }

    }
}