using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRental.DAL;
using WebRental.Models;
using System.Data;

namespace WebRental.DAL
{
    public class UnitRentalRepo
    {
        private MysqlHelper _context = new MysqlHelper();

       public List<UnitRental> UnitlRentalsGetbyTotalRentalid(int Rentalid)
        {
            List<UnitRental> results = new List<UnitRental>();
            string query = "unitrental_bytotalrental";

            DataTable tabla = _context.DataTable_return(query);

            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    results.Add(CreateUnitRental(fila));
                }

            }

            return results;
        }

        private Models.UnitRental CreateUnitRental(DataRow fila)
        {
            BikeRepo br = new BikeRepo();
            UnitRental ur = new UnitRental(new Rates())
                     { ID = (Guid)fila["ID"]
                        , Quantity = (int)fila["Quantity"]
                        , InitDate = (DateTime)fila["InitDate"]
                        , RentType = (RentalType)fila["RentType"]
                        , totalRentalID = (int)fila["totalRentalID"]
                        , Bike = br.Bike_getbyID((Guid)fila["ID"])
            };
            return ur;
        }

    }
}