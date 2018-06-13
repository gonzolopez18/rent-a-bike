using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRental.DAL;
using WebRental.Models;
using System.Data;

namespace WebRental.DAL
{
    public class BikeRepo
    {
        private MysqlHelper _context = new MysqlHelper();

       public Bike Bike_getbyID(Guid id)
        {
            Bike result = new Bike() ;
            string query = "bike_byID";

            DataTable tabla = _context.DataTable_return(query);

            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    result = new Bike
                    {
                        ID = (Guid)fila["ID"],
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