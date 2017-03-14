using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class MyOffersViewModelBuilder  
    {
        private readonly IOrangeBricksContext _context;

        public MyOffersViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyOffersViewModel Build(string buyerId)
        {
            return new MyOffersViewModel
            {
                Offers = _context.Offers
                    .Where(o => o.BuyerUserId == buyerId)
                    .Include(x => x.Property)
                    .Select(o => new MyOfferViewModel
                    {
                        Id = o.Id,
                        Amount = o.Amount,
                        Status = o.Status.ToString(),
                        isPending = o.Status == OfferStatus.Pending,
                        CreatedAt = o.CreatedAt,
                        Property = new MyOfferProperty
                        {
                            NumberOfBedrooms = o.Property.NumberOfBedrooms,
                            PropertyId = o.Property.Id,
                            PropertyType = o.Property.PropertyType,
                            StreetName = o.Property.StreetName
                        }
                    })
                    .ToList()
            };
        }
    }
}