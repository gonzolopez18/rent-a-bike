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

    public class CustomerRepo
    {
        private MysqlHelper _context = new MysqlHelper();

        public Customer Customer_getbyID(Guid id)
        {
            Customer result = new Customer();
            string query = "customer_byId";

            MySqlParameter[] paramArray = new MySqlParameter[] { new MySqlParameter("p_ID", id.ToString("N")) };
            

            DataTable tabla = _context.SP_DataTable_return(query,paramArray );

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


    }
}