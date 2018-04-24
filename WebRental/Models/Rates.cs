using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRental.Models
{
   public class Rates : IRates
    {
        public double GetRentCost( RentalType type)
        {
            double Cost = 0;
            switch (type)
            {
                case (RentalType.HOURLY):
                    Cost = 5;
                    break;
                case (RentalType.DAILY):
                    Cost = 20;
                    break;
                case (RentalType.WEEKLY):
                    Cost = 60;
                    break;
             }
            return Cost;
        }
         public double GetHourlyCost()
        {
            return 5;
        }
       public double GetDailyCost()
        {
            return 20;
        }
        public double GetWeeklyCost()
        {
            return 60;
        }
        public double GetFamilyDiscount()
        {
            return  (30.0 / 100.0);
        }
        public int GetFamilyMin()
        {
            return 3;
        }
        public int GetFamilyMax()
        {
            return 5;
        }
            
    }
}
