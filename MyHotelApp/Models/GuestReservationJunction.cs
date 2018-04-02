using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHotelApp.Models
{
    public class GuestReservationJunction
    {
        public int GuestAccountID { get; set; }

        [ForeignKey("GuestAccountID")]
        public GuestAccount GuestAccount {get; set;}
        public int ReservationId { get; set; }
    }
}