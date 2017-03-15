using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeBookingCommand
    {
        public int PropertyId { get; set; }
        public DateTime BookingDate { get; set; }
        public string BuyerUserId { get; set; }
    }
}