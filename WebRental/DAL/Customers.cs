using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using WebRental.DAL;
using WebRental.Models;
using System.Data;


namespace WebRental.DAL
{

    public class Customers
    {
 
        public static Customer GetbyID(Guid id)
        {
 
            Customer result = new Customer();
            string query = "call customer_byId (@p_ID);";

            MySqlParameter[] paramArray = new MySqlParameter[] 
                {
                    new MySqlParameter("p_ID", id.ToString("N"))
                };

            DataSet ds = MySqlHelper.ExecuteDataset(dalHelper.ConnectionString, query, paramArray);
            DataTable tabla = ds.Tables[0];

            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    result = new Customer
                    {
                        ID = Guid.Parse( (string)fila["ID"]),
                        Name = (string)fila["Name"]
                    };
               }
            }
            return result;
        }

        public static Customer GetbyName(string Name)
        {
            Customer result = new Customer();
            string query = "call customer_byName (@p_Name);";

            MySqlParameter[] paramArray = new MySqlParameter[] { new MySqlParameter("p_Name", Name) };


            DataSet ds = MySqlHelper.ExecuteDataset(dalHelper.ConnectionString, query, paramArray);
            DataTable tabla = ds.Tables[0];

            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    result = new Customer
                    {
                        ID = Guid.Parse((string)fila["ID"]),
                        Name = (string)fila["Name"]
                    };
                }
            }
            return result;
        }


        public static Customer Add(Customer customer)
        {

            if (customer.ID == Guid.Empty) { customer.ID = Guid.NewGuid(); };

            string query = "call customer_insert (@p_ID, @p_Name );";

            MySqlParameter[] paramArray = new MySqlParameter[] 
            {
                new MySqlParameter("p_Name", customer.Name),
                new MySqlParameter("p_ID", customer.ID.ToString("N"))
               };


            int result = MySqlHelper.ExecuteNonQuery(dalHelper.ConnectionString, query, paramArray.ToArray() );

            return customer;


        }

    }
}