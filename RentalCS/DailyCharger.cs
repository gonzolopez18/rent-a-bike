using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentalCS
{
    class DailyCharger : ICharger

    {
        private IRates _rates;

        public DailyCharger (IRates rates)
        {
            _rates = rates;
        }

        public double Charge(int quantity)
        {
            return quantity * _rates.GetDailyCost();
        }

    }
}
