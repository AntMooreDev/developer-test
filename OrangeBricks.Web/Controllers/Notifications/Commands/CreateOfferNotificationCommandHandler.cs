using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Notifications.Commands
{
    public class CreateOfferNotificationCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public CreateOfferNotificationCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(CreateOfferNotificationCommand command)
        {
            int offerId = 0;

            if (int.TryParse(command.NotificationObjectId, out offerId))
            {
                var offer = _context.Offers
                    .Include(x => x.Property)
                    .FirstOrDefault(o => o.Id == offerId);

                var notificationChange = new NotificationChange
                {
                    Id = Guid.NewGuid(),
                    ActorUserId = offer.Property.SellerUserId,
                    Verb = command.verb
                };

                var notificationObject = new NotificationObject
                {
                    Id = Guid.NewGuid(),
                    Object = command.Object,
                    ObjectId = command.NotificationObjectId,
                    NotificationChanges = new List<NotificationChange>()
                    {
                        notificationChange
                    }
                };

                var notification = new Notification
                {
                    Id = Guid.NewGuid(),
                    Status = NotificationStatus.Unread,
                    UserId = offer.BuyerUserId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    NotificationObjects = new List<NotificationObject>()
                    {
                        notificationObject
                    }
                };

                _context.Notifications.Add(notification);

                _context.SaveChanges();
            }
        }
    }
}