using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Bookings.Commands
{
    public class RejectBookingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public RejectBookingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(RejectBookingCommand command)
        {
            var offer = _context.Booking.Find(command.BookingId);

            offer.UpdatedAt = DateTime.Now;
            offer.Status = BookingStatus.Rejected;

            _context.SaveChanges();
        }

    }
}