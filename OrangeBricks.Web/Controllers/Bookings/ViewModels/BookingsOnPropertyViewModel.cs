using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Bookings.ViewModels
{
    public class BookingsOnPropertyViewModel
    {
        public string PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string StreetName { get; set; }
        public bool HasBookings { get; set; }
        public IEnumerable<BookingViewModel> Bookings { get; set; }
        public int PropertyId { get; set; }

    }

    public class BookingViewModel
    {
        public Guid Id { get; set; }
        public DateTime BookingDate { get; set; }
        public bool IsPending { get; set; }
        public string Status { get; set; }
    }
}