using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotelApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MyHotelApp.ViewModels
{
    public class GuestReservationViewModel
    {
        public List<Reservation> Reservations { get; set; }
        public GuestAccount GuestAccount { get; set; }
        public RoomType RoomType { get; set; }
    }
}