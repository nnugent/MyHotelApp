using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelApp.Models
{
    public class GuestReservationJunction
    {
        public int GuestAccountID { get; set; }
        public int ReservationId { get; set; }
    }
}