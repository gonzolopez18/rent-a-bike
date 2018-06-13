using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRental.DAL;
using WebRental.Models;
using System.Data;


namespace WebRental.DAL
{
    public class TotalRentalRepo
    {
        private MysqlHelper _context;
        private UnitRentalRepo URRep = new UnitRentalRepo() ;
        private CustomerRepo CRep = new CustomerRepo();

        public TotalRentalRepo()
        {
            _context = new MysqlHelper();

        }
        public List<TotalRental> TotalRentalsGetAll()
        {
            List<TotalRental> results = new List<TotalRental>();
            string query = "totalrental_All";

            DataTable tabla = _context.SP_DataTable_return(query);

            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows) {
                  results.Add(  getRental(fila));
                }
            }

            return results;
        }

        private TotalRental getRental(DataRow row)
        {

            TotalRental tr = new TotalRental( new Rates() , null )
            {
                ID = (int)row["ID"],
                IsFamilyRental = (bool)row["IsFamilyRental"],
                RentalDate= (DateTime)row["RentalDate"],
                customer = CRep.Customer_getbyID(Guid.Parse((string)row["customer_ID"]))
            };
            return tr;
        }

    }
}