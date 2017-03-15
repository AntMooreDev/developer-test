using OrangeBricks.Web.Controllers.Bookings.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace OrangeBricks.Web.Controllers.Bookings.Builders
{
    public class BookingsOnPropertyViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public BookingsOnPropertyViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public BookingsOnPropertyViewModel Build(int id)
        {
            var property = _context.Properties
                .Where(p => p.Id == id)
                .Include(x => x.Bookings)
                .SingleOrDefault();

            var bookings = property.Bookings ?? new List<Booking>();

            return new BookingsOnPropertyViewModel
            {
                HasBookings = bookings.Any(),
                Bookings = bookings.Select(x => new BookingViewModel
                {
                    Id = x.Id,
                    BookingDate = x.BookingDate,
                    IsPending = x.Status == BookingStatus.Pending,
                    Status = x.Status.ToString()
                }),
                NumberOfBedrooms = property.NumberOfBedrooms,
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName
            };
        }
    }
}