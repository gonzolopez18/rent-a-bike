using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRental.DAL;
using WebRental.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebRental.DAL
{
    public class UnitRentals
    {
 
       public static List<UnitRental> UnitlRentalsGetbyTotalRentalid(int Rentalid)
        {
            List<UnitRental> results = new List<UnitRental>();
            string query = "call unitrental_bytotalrental(@p_totalrentalID);";

            MySqlParameter[] paramArray = new MySqlParameter[]
                 {
                    new MySqlParameter("p_totalrentalID", Rentalid)
                 };

            DataSet ds = MySqlHelper.ExecuteDataset(dalHelper.ConnectionString, query, paramArray);
            DataTable tabla = ds.Tables[0];

            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    results.Add(FillUnitRental(fila));
                }

            }

            return results;
        }

       private static Models.UnitRental FillUnitRental(DataRow fila)
        {
            UnitRental ur = new UnitRental(new Rates())
                     { ID = (Guid)fila["ID"]
                        , Quantity = (int)fila["Quantity"]
                        , InitDate = (DateTime)fila["InitDate"]
                        , RentType = (RentalType)fila["RentType"]
                        , totalRentalID = (int)fila["totalRentalID"]
                        , Bike = Bikes.Bike_getbyID((Guid)fila["ID"])
            };
            return ur;
        }

        public static void Add(UnitRental ur)
        {
            if (ur.ID == Guid.Empty) { ur.ID = Guid.NewGuid();}
            using (MySqlConnection connection = new MySqlConnection(dalHelper.ConnectionString))
            {
                connection.Open();
                string query = "call unitrental_insert(@p_ID, @p_totalRentalID, @p_Quantity, @p_RentType,@p_InitDate, @p_Bike_ID );";

                List<MySqlParameter> paramArray = new List<MySqlParameter>();
                paramArray.Add(new MySqlParameter("p_ID", ur.ID.ToString("N")));
                paramArray.Add(new MySqlParameter("p_totalRentalID", ur.totalRentalID));
                paramArray.Add(new MySqlParameter("p_Quantity", ur.Quantity));
                paramArray.Add(new MySqlParameter("p_RentType", ur.RentType));
                paramArray.Add(new MySqlParameter("p_InitDate", ur.InitDate));
                paramArray.Add(new MySqlParameter("p_Bike_ID", ur.Bike.ID.ToString("N")));

                int result = MySqlHelper.ExecuteNonQuery(connection, query, paramArray.ToArray());

            }
        }

    }
}