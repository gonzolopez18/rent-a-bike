using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentalCS
{
    class DailyCharger : ICharger

    {
        public double Charge(int quantity)
        {
           return quantity * 20;
        }
    }
}
