using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotelApp.Models;


namespace MyHotelApp.ViewModels
{
    public class ReservationDetailsViewModel
    {
        public Reservation Reservation { get; set; }
        public GuestAccount GuestAccount { get; set; }

        public RoomType RoomType { get; set; }
        public Room Room { get; set; }
        public RoomStatus RoomStatus { get; set; }

        public string Email { get; set; }
  
    }
}