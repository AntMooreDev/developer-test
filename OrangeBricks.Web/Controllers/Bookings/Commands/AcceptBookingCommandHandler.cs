using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Bookings.Commands
{
    public class AcceptBookingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public AcceptBookingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(AcceptBookingCommand command)
        {
            var offer = _context.Booking.Find(command.BookingId);

            offer.UpdatedAt = DateTime.Now;
            offer.Status = BookingStatus.Accepted;

            _context.SaveChanges();
        }

    }
}