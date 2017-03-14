using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        public string BuyerUserId { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Property Property { get; set; }

    }
}