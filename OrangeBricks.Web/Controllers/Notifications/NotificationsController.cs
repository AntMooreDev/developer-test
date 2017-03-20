using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Notifications.Builders;
using OrangeBricks.Web.Models;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Notifications
{
    public class NotificationsController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public NotificationsController(IOrangeBricksContext context)
        {
            _context = context;
        }

        [OrangeBricksAuthorize(Roles = "Buyer")]
        [HttpPost]
        public ActionResult GetAllOffersNotificationsCountForCurrentUser()
        {
            var builder = new AllMyOffersNotificationViewModelBuilder(_context);
            var viewModel = builder.Build(User.Identity.GetUserId());

            return Json(viewModel);
        }
        
        public ActionResult GetAllOffersNotificationCountForCurrentUserView()
        {
            var builder = new AllMyOffersNotificationViewModelBuilder(_context);
            var viewModel = builder.Build(User.Identity.GetUserId());

            return PartialView("~/Views/Shared/MyOffers.cshtml", viewModel.NotificationCount);
        }
    }
}