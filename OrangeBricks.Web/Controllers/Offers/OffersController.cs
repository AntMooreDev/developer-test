using System.Web.Mvc;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Controllers.Offers.Commands;
using OrangeBricks.Web.Models;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Controllers.Notifications.Commands;

namespace OrangeBricks.Web.Controllers.Offers
{
    public class OffersController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public OffersController(IOrangeBricksContext context)
        {
            _context = context;
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult OnProperty(int id)
        {
            var builder = new OffersOnPropertyViewModelBuilder(_context);
            var viewModel = builder.Build(id);

            return View(viewModel);
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        [HttpPost]        
        public ActionResult Accept(AcceptOfferCommand command)
        {
            var handler = new AcceptOfferCommandHandler(_context);

            handler.Handle(command);

            CreateOfferNotification(command.OfferId.ToString(), "Accepted");

            return RedirectToAction("OnProperty", new { id = command.PropertyId });
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        [HttpPost]
        public ActionResult Reject(RejectOfferCommand command)
        {
            var handler = new RejectOfferCommandHandler(_context);

            handler.Handle(command);

            CreateOfferNotification(command.OfferId.ToString(), "Rejected");

            return RedirectToAction("OnProperty", new { id = command.PropertyId });
        }

        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult MyOffers()
        {
            var builder = new MyOffersViewModelBuilder(_context);
            var viewModel = builder.Build(User.Identity.GetUserId());

            return View(viewModel);
        }

        /// <summary>
        /// Saves a notification record to the database
        /// </summary>
        /// <param name="notificationObjectId">The Id of the object that has been changed as a string</param>
        /// <param name="verb">The action that has been performed as a string</param>
        [NonAction]
        public void CreateOfferNotification(string notificationObjectId, string verb)
        {
            CreateOfferNotificationCommand command = new CreateOfferNotificationCommand()
            {
                NotificationObjectId = notificationObjectId,
                Object = "Offer",
                verb = verb
            };

            var handler = new CreateOfferNotificationCommandHandler(_context);

            handler.Handle(command);
        }
    }
}