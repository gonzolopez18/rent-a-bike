using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCS
{
   public class Rates : IRates
    {
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
        public int GetFamilyDiscount()
        {
            return 30;
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
