using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentalCS
{
    class WeeklyCharger : ICharger
    {
        private IRates _rates;
      
        public WeeklyCharger(IRates rates)
        {
            _rates = rates;
        }

        public double Charge(int quantity)
        {
            return quantity * _rates.GetWeeklyCost();
        }
    }
}
