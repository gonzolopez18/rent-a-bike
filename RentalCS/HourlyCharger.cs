using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentalCS
{
    class HourlyCharger : ICharger
    {
        private IRates _rates;

        public HourlyCharger(IRates rates)
        {
            _rates = rates;
        }

        public double Charge(int quantity)
        {
            return quantity * _rates.GetHourlyCost();
        }
    }
}
