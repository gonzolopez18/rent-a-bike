using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebRental.Models
{
    public class HourlyCharger : ICharger
    {
        private IRates _rates;

        public HourlyCharger(IRates rates)
        {
            _rates = rates;
        }

        public double Charge(int quantity)
        {
            return quantity * _rates.GetRentCost( RentalType.HOURLY);
        }
    }
}
