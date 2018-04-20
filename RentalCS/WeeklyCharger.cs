using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentalCS
{
    class WeeklyCharger : ICharger
    {
        private Rates _rates;
        private string Marito = "capo";

        public WeeklyCharger(Rates rates)
        {
            _rates = rates;
        }




        public double Charge(int quantity)
        {
            return quantity * _rates.GetWeeklyCost();
        }
    }
}
