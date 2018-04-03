using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotelApp.Models;

namespace MyHotelApp.ViewModels
{
    public class ReservationFormViewModel
    {
        public int GuestAcountId { get; set; }
        public Reservation Reservation { get; set; }
        public GuestReservationJunction GuestReservationJunction {get; set;}
        public List<RoomType> RoomTypes { get; set; }

        public string CheckInDay { get; set; }
        public string CheckInMonth { get; set; }
        public string CheckOutDay { get; set; }
        public string CheckOutMonth { get; set; }
    }
}