using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Notifications.Builders;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Tests.Controllers.Notifications.Builders
{
    public static class ExtentionMethods
    {
        public static IDbSet<T> Initialize<T>(this IDbSet<T> dbSet, IQueryable<T> data) where T : class
        {
            dbSet.Provider.Returns(data.Provider);
            dbSet.Expression.Returns(data.Expression);
            dbSet.ElementType.Returns(data.ElementType);
            dbSet.GetEnumerator().Returns(data.GetEnumerator());
            return dbSet;
        }
    }

    [TestFixture]
    public class AllMyOffersNotificationViewModelBuilderTest
    {
        private IOrangeBricksContext _context;

        [SetUp]
        public void Setup()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuildShouldReturnAllOfferNotificationsForUserWhenUserIdIsProvided()
        {
            // Arrange
            var builder = new AllMyOffersNotificationViewModelBuilder(_context);

            string userId = Guid.NewGuid().ToString();

            var notifications = new List<Models.Notification>()
            {
                new Notification
                {
                    Id = Guid.NewGuid(),
                    Status = NotificationStatus.Unread,
                    UserId = userId,
                    NotificationObjects = new List<Models.NotificationObject>()
                    {
                        new NotificationObject
                        {
                            Id = Guid.NewGuid(),
                            Object = "Offer",
                            ObjectId = "1",
                            NotificationChanges = new List<Models.NotificationChange>()
                            {
                                new NotificationChange
                                {
                                    Id = Guid.NewGuid(),
                                    Verb = "Accepted"
                                }
                            }
                        }
                    }
                },
                new Notification
                {
                    Id = Guid.NewGuid(),
                    Status = NotificationStatus.Unread,
                    UserId = userId,
                    NotificationObjects = new List<Models.NotificationObject>()
                    {
                        new NotificationObject
                        {
                            Id = Guid.NewGuid(),
                            Object = "Offer",
                            ObjectId = "2",
                            NotificationChanges = new List<Models.NotificationChange>()
                            {
                                new NotificationChange
                                {
                                    Id = Guid.NewGuid(),
                                    Verb = "Accepted"
                                }
                            }
                        }
                    }
                },
                new Notification
                {
                    Id = Guid.NewGuid(),
                    Status = NotificationStatus.Read,
                    UserId = userId,
                    NotificationObjects = new List<Models.NotificationObject>()
                    {
                        new NotificationObject
                        {
                            Id = Guid.NewGuid(),
                            Object = "Offer",
                            ObjectId = "3",
                            NotificationChanges = new List<Models.NotificationChange>()
                            {
                                new NotificationChange
                                {
                                    Id = Guid.NewGuid(),
                                    Verb = "Accepted"
                                }
                            }
                        }
                    }
                },
                new Notification
                {
                    Id = Guid.NewGuid(),
                    Status = NotificationStatus.Unread,
                    UserId = userId,
                    NotificationObjects = new List<Models.NotificationObject>()
                    {
                        new NotificationObject
                        {
                            Id = Guid.NewGuid(),
                            Object = "Booking",
                            ObjectId = "1",
                            NotificationChanges = new List<Models.NotificationChange>()
                            {
                                new NotificationChange
                                {
                                    Id = Guid.NewGuid(),
                                    Verb = "Accepted"
                                }
                            }
                        }
                    }
                },
                new Notification
                {
                    Id = Guid.NewGuid(),
                    Status = NotificationStatus.Unread,
                    UserId = Guid.NewGuid().ToString(),
                    NotificationObjects = new List<Models.NotificationObject>()
                    {
                        new NotificationObject
                        {
                            Id = Guid.NewGuid(),
                            Object = "Offer",
                            ObjectId = "4",
                            NotificationChanges = new List<Models.NotificationChange>()
                            {
                                new NotificationChange
                                {
                                    Id = Guid.NewGuid(),
                                    Verb = "Accepted"
                                }
                            }
                        }
                    }
                }
            };

            var mockSet = Substitute.For<IDbSet<Models.Notification>>()
                .Initialize(notifications.AsQueryable());

            _context.Notifications.Returns(mockSet);

            // Act
            var viewModel = builder.Build(userId);

            // Assert
            Assert.That(viewModel.NotificationCount, Is.EqualTo(2));
        }
    }
}
