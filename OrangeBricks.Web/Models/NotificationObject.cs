using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Models
{
    public class NotificationObject
    {
        public Guid Id { get; set; }
        public Notification Notification { get; set; }
        public string Object { get; set; }
        public string ObjectId { get; set; }
    }
}