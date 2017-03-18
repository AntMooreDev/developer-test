using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public NotificationStatus Status { get; set; }
    }
}