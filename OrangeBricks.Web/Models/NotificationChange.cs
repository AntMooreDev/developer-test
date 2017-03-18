using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Models
{
    public class NotificationChange
    {
        public Guid Id { get; set; }
        public NotificationObject NotificationObject { get; set; }
        public string Verb { get; set; }
        public string ActorUserId { get; set; }
    }
}