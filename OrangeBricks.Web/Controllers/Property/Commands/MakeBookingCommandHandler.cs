using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeBookingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public MakeBookingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(MakeBookingCommand command)
        {
            var property = _context.Properties.Find(command.PropertyId);

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                BookingDate = command.BookingDate,
                Status = BookingStatus.Pending,
                Property = property,
                BuyerUserId = command.BuyerUserId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Booking.Add(booking);

            _context.SaveChanges();
        }
    }
}