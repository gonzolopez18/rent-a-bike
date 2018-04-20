using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentalCS
{
    class HourlyCharger : ICharger
    {
        private Rates _rates;

        public HourlyCharger(Rates rates)
        {
            _rates = rates;
        }

        public double Charge(int quantity)
        {
            return quantity * _rates.GetHourlyCost();
        }
    }
}
