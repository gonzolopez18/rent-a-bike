using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentalCS
{
    class ChargerFactory
    {
        private IRates _rates;
        public ChargerFactory(IRates rates)
        {
            _rates = rates;
        }
        public virtual ICharger GetCharger(RentalType renttype)
        {
            ICharger Charger = null;
            switch (renttype)
            {
                case RentalType.DAILY:
                    Charger = new DailyCharger(_rates);
                    break;
                case RentalType.HOURLY:
                    Charger = new HourlyCharger(_rates);
                    break;
                case RentalType.WEEKLY:
                    Charger = new WeeklyCharger(_rates);
                    break;
            }
            return Charger;
        }
    }
}
