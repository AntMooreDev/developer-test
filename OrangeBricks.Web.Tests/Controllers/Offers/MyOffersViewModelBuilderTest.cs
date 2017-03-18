using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OrangeBricks.Web.Tests.Controllers.Offers
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
    public class MyOffersViewModelBuilderTest
    {
        private IOrangeBricksContext _context;

        [SetUp]
        public void Setup()
        {
            _context = Substitute.For<IOrangeBricksContext>();
        }

        [Test]
        public void BuilderShouldReturnAllOffersForBuyerWhenBuyerIdIsProvided()
        {
            // Arrange
            var builder = new MyOffersViewModelBuilder(_context);

            var BuyerUserIdOne = Guid.NewGuid().ToString();
            var BuyerUserIdTwo = Guid.NewGuid().ToString();

            var offers = new List<Offer>()
            {
                new Offer
                {
                    BuyerUserId = BuyerUserIdOne,
                    Status = OfferStatus.Pending,
                    Property = new Models.Property
                    {
                        Id = 1
                    }
                },
                new Offer
                {
                    BuyerUserId = BuyerUserIdOne,
                    Status = OfferStatus.Pending,
                    Property = new Models.Property
                    {
                        Id = 2
                    }
                },
                new Offer
                {
                    BuyerUserId = BuyerUserIdTwo,
                    Status = OfferStatus.Pending,
                    Property = new Models.Property
                    {
                        Id = 1
                    }
                }
            };

            var mockSet = Substitute.For<IDbSet<Offer>>()
                .Initialize(offers.AsQueryable());

            _context.Offers.Returns(mockSet);

            // Act
            var viewModel = builder.Build(BuyerUserIdOne);

            // Assert
            Assert.That(viewModel.Offers.Count, Is.EqualTo(2));
        }
    }
}
