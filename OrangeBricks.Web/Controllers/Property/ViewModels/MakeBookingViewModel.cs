using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class MakeBookingViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyType { get; set; }
        public string StreetName { get; set; }
        public DateTime BookingDate { get; set; }
    }
}