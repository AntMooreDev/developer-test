using System;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
    public class MyOfferViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool isPending { get; set; }
        public string Status { get; set; }
        public MyOfferProperty Property { get; set; }
    }

    public class MyOfferProperty
    {
        public int PropertyId { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string PropertyType { get; set; }
        public string StreetName { get; set; }
    }
}