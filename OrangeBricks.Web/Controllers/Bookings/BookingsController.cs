using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Bookings.Builders;
using OrangeBricks.Web.Controllers.Bookings.Commands;
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

        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult OnProperty(int id)
        {
            var builder = new BookingsOnPropertyViewModelBuilder(_context);
            var viewModel = builder.Build(id);

            return View(viewModel);
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        [HttpPost]
        public ActionResult Accept(AcceptBookingCommand command)
        {
            var handler = new AcceptBookingCommandHandler(_context);

            handler.Handle(command);

            return RedirectToAction("OnProperty", new { id = command.PropertyId });
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        [HttpPost]
        public ActionResult Reject(RejectBookingCommand command)
        {
            var handler = new RejectBookingCommandHandler(_context);

            handler.Handle(command);

            return RedirectToAction("OnProperty", new { id = command.PropertyId });
        }
    }
}