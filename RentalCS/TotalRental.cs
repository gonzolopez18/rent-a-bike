using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCS
{
    class TotalRental
    {
        private Rates _rates;
        public Guid CustomerId { get; set; }
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

        public TotalRental(Rates rates, List<UnitRental> Items)
        {
            _rates = rates;
            RentalItems = Items;
        }

        private  double CalculateTotalCost()
        {
            double TotalCost = 0;

            if (RentalItems == null || RentalItems.Count == 0)
                return TotalCost;

            TotalCost = RentalItems.Sum(z => z.Charge());

            if ( IsFamilyRental && (RentalItems.Count >= _rates.GetFamilyMin() && RentalItems.Count <= _rates.GetFamilyMax()))
            {
                return TotalCost * _rates.GetFamilyDiscount() ;
            }
            
            return TotalCost;
        }

    }
}
