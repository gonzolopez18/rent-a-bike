using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WebRental.DAL
{
    public class dalHelper
    {
        public static String  ConnectionString = ConfigurationManager.ConnectionStrings["BikeMySql"].ToString();

    }
}