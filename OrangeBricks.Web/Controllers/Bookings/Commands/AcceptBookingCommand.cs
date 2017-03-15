using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Bookings.Commands
{
    public class AcceptBookingCommand
    {
        public int PropertyId { get; set; }
        public Guid BookingId { get; set; }
    }
}