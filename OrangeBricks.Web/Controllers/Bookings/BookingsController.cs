using OrangeBricks.Web.Controllers.Bookings.Builders;
using OrangeBricks.Web.Models;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Bookings
{
    public class BookingsController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public BookingsController(IOrangeBricksContext context)
        {
            _context = context;
        }

        public ActionResult OnProperty(int id)
        {
            var builder = new BookingsOnPropertyViewModelBuilder(_context);
            var viewModel = builder.Build(id);

            return View(viewModel);
        }
    }
}