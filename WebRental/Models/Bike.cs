using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRental.Models
{
    public class Bike
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public int WheelSize { get; set; }
        public bool Available { get; set; }
    }
}