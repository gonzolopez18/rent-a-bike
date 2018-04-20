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
        ICharger Charger = null;

        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public RentalType RentType { get; set; }
        public DateTime InitDate { get; set; }


        public double Charge()
        {
            ChargerFactory factory = new ChargerFactory();
            Charger = factory.GetCharger(this.RentType);

            return Charger.Charge(this.Quantity);

        }

    }
}
