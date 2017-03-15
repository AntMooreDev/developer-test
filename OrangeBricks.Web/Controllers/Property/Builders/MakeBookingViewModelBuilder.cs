using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using OrangeBricks.Web.Utils;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class MakeBookingViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MakeBookingViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MakeBookingViewModel Build(int id)
        {
            var property = _context.Properties.Find(id);

            return new MakeBookingViewModel
            {
                BookingDate = DateTimeUtils.RoundUp(
                    DateTime.Now.AddDays(1),
                    TimeSpan.FromMinutes(15)
                ),
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName
            };
        }
    }
}