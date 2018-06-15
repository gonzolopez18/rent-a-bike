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
    public class Bikes
    {
       public static Bike Bike_getbyID(Guid id)
        {
            Bike result = new Bike() ;
            string query = "call bike_byID(@p_ID);";

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
                    result = new Bike
                    {
                        ID = (Guid.Parse((string)fila["ID"])),
                        Available = (Boolean)fila["Available"],
                        Code = (string)fila["Code"],
                        WheelSize = (int)fila["WheelSize"]
                    }; 

                }

            }

            return result;
        }

     
    }
}