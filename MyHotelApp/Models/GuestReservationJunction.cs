using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyHotelApp.Models
{
    public class GuestReservationJunction
    {
        public int Id { get; set; }

        public int GuestAccountId { get; set; }
        [ForeignKey("GuestAccountId")]
        public GuestAccount GuestAccount { get; set; }

        [ForeignKey("ReservationId")]
        public Reservation Reservation { get; set; }
        public int ReservationId { get; set; }
    }
}