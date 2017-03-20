using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Notifications.Commands
{
    public class CreateOfferNotificationCommand
    {
        [Required]
        public string verb { get; set; }

        [Required]
        public string Object { get; set; }

        [Required]
        public string NotificationObjectId { get; set; }

        [Required]
        public string ActorUserId { get; set; }
     
        [Required]
        public string UserId { get; set; }
    }
}