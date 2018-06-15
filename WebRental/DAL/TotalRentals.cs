using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRental.DAL;
using WebRental.Models;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Transactions;


namespace WebRental.DAL
{
    public class TotalRentals
    {

        public static List<TotalRental> TotalRentalsGetAll()
        {
            List<TotalRental> results = new List<TotalRental>();

            string query = "call totalrental_All();";

            DataSet ds = MySqlHelper.ExecuteDataset(dalHelper.ConnectionString, query);
            DataTable tabla = ds.Tables[0];

            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows) {
                  results.Add(  fillRental(fila));
                }
            }

            return results;
        }

        private static TotalRental fillRental(DataRow row)
        {

            TotalRental tr = new TotalRental( new Rates() , null )
            {
                ID = (int)row["ID"],
                IsFamilyRental = (bool)row["IsFamilyRental"],
                RentalDate= (DateTime)row["RentalDate"],
                customer = Customers.GetbyID(Guid.Parse((string)row["customer_ID"]))
            };
            return tr;
        }


        public static void Add(TotalRental tr)
        {
            using (MySqlConnection connection = new MySqlConnection(dalHelper.ConnectionString))
            {
                connection.Open();

                string query = "call totalrental_insert(@p_rentaldate, @p_isfamilyrental, @p_idcustomer);";

                List<MySqlParameter> paramArray = new List<MySqlParameter>();
                paramArray.Add(new MySqlParameter("p_rentaldate", tr.RentalDate));
                paramArray.Add(new MySqlParameter("p_isfamilyrental", tr.IsFamilyRental));
                paramArray.Add(new MySqlParameter("p_idcustomer", tr.customer.ID.ToString("N")));

                int result = MySqlHelper.ExecuteNonQuery(connection, query, paramArray.ToArray());

                object ores = MySqlHelper.ExecuteScalar(connection, "SELECT LAST_INSERT_ID();");

                tr.ID = (int)(ulong)ores;

            }
        }
    }
}