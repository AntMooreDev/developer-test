using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Bookings.Builders;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OrangeBricks.Web.Tests.Controllers.Booking.Builders
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
    public class BookingsViewModelBuilderTest
    {
        private IOrangeBricksContext _context;

        [SetUp]
        public void Setup()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuildShouldReturnAllBookingsOnSinglePropertyWhenPropertyIdIsProvided()
        {
            // Arrange
            var builder = new BookingsOnPropertyViewModelBuilder(_context);

            var properties = new List<Models.Property>()
            {
                new Models.Property {
                    Id = 1,
                    Bookings = new List<Models.Booking>() {
                        new Models.Booking
                        {
                            BookingDate = new DateTime(2017, 01, 01),
                            Status = BookingStatus.Pending
                        },
                        new Models.Booking
                        {
                            BookingDate = new DateTime(2017, 01, 01),
                            Status = BookingStatus.Pending
                        }
                    }
                },
                new Models.Property
                {
                    Id = 2,
                    Bookings = new List<Models.Booking>()
                    {
                        new Models.Booking
                        {
                            BookingDate = new DateTime(2017, 01, 01),
                            Status = BookingStatus.Pending
                        }
                    }
                }
            };

            var mockSet = Substitute.For<IDbSet<Models.Property>>()
                .Initialize(properties.AsQueryable());

            _context.Properties.Returns(mockSet);

            int propertyId = 1;

            // Act
            var viewModel = builder.Build(propertyId);

            // Assert
            Assert.That(viewModel.Bookings.Count, Is.EqualTo(2));
        }
    }
}
