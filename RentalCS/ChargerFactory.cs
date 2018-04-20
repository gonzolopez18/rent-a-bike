using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RentalCS
{
    class ChargerFactory
    {
        public virtual ICharger GetCharger(RentalType renttype)
        {
            ICharger Charger = null;
            switch (renttype)
            {
                case RentalType.DAILY:
                    Charger = new DailyCharger();
                    break;
                case RentalType.HOURLY:
                    Charger = new HourlyCharger();
                    break;
                case RentalType.WEEKLY:
                    Charger = new WeeklyCharger();
                    break;
            }
            return Charger;
        }
    }
}
