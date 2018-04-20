using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentalCS
{
    class DailyCharger : ICharger

    {
        private Rates _rates;

        public DailyCharger (Rates rates)
        {
            _rates = rates;
        }

        public double Charge(int quantity)
        {
            return quantity * _rates.GetDailyCost();
        }

    }
}
