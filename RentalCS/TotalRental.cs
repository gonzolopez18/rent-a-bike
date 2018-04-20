using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCS
{
    class TotalRental
    {
        public int CustomerId { get; set; }
        public DateTime RentalDate { get; set; }
        public int id { get; set; }
        public List<UnitRental>  RentalItems { get; set; }
        public bool IsFamilyRental { get; set; }

        public double TotalCost {
            get
            {
                return CalculateTotalCost();
            }
        }



        private  double CalculateTotalCost()
        {
            double TotalCost = 0;

            if (RentalItems == null || RentalItems.Count == 0)
                return TotalCost;

            TotalCost = RentalItems.Sum(z => z.Charge());

            if ( IsFamilyRental && (RentalItems.Count >=3 && RentalItems.Count <= 5))
            {
                return TotalCost * 0.7 ;
            }
            
            return TotalCost;
        }

    }
}
