using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebRental.Models
{
    public  interface ICharger
    {
         double Charge(int quantity);
    }
}
