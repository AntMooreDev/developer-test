using OrangeBricks.Web.Controllers.Notifications.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Notifications.Builders
{
    public class AllMyOffersNotificationViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public AllMyOffersNotificationViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public AllMyOffersNotificationViewModel Build(string Id)
        {
            var notifications = _context.Notifications
                .Include(x => x.NotificationObjects)
                .Where(n => n.UserId == Id
                    && n.Status == NotificationStatus.Unread
                    && n.NotificationObjects.Any(no => no.Object == "Offer"))
                .ToList();

            return new AllMyOffersNotificationViewModel
            {
                NotificationCount = notifications.Count()
            };
        }
    }
}