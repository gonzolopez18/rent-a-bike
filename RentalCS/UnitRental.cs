using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCS
{
    public enum RentalType
    {
        HOURLY,
        DAILY,
        WEEKLY
    }

    public class UnitRental
    {
        private ICharger Charger = null;
        private IRates _rates;

        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public RentalType RentType { get; set; }
        public DateTime InitDate { get; set; }

        public UnitRental(IRates rate)
        {
            _rates = rate;
        }
        
        public double Charge()
        {
            ChargerFactory factory = new ChargerFactory(_rates);
            Charger = factory.GetCharger(this.RentType);

            return Charger.Charge(this.Quantity);

        }

    }
}
