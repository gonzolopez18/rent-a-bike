using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRental.Models
{
    public class TotalRental
    {
        public int ID { get; set; }
        private IRates _rates;
        public Customer customer { get; set; }
        public DateTime RentalDate { get; set; }
        public virtual ICollection<UnitRental>  RentalItems { get; set; }
        public bool IsFamilyRental { get; set; }

        public double TotalCost {
            get
            {
                return CalculateTotalCost();
            }
        }

        public TotalRental(IRates rates, List<UnitRental> Items)
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
