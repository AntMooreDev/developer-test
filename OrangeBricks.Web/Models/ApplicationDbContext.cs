using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OrangeBricks.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IOrangeBricksContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Property> Properties { get; set; }
        public IDbSet<Offer> Offers { get; set; }
        public IDbSet<Booking> Booking { get; set; }
        public IDbSet<Notification> Notifications { get; set; }
        public IDbSet<NotificationObject> NotificationObjects { get; set; }
        public IDbSet<NotificationChange> NotificationChanges { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }

    public interface IOrangeBricksContext
    {
        IDbSet<Property> Properties { get; set; }
        IDbSet<Offer> Offers { get; set; }
        IDbSet<Booking> Booking { get; set; }
        IDbSet<Notification> Notifications { get; set; }
        IDbSet<NotificationObject> NotificationObjects { get; set; }
        IDbSet<NotificationChange> NotificationChanges { get; set; }

        void SaveChanges();
    }
}