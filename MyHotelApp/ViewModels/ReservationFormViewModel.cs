using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MyHotelApp.Models;

namespace MyHotelApp.ViewModels
{
    public class ReservationFormViewModel
    {
        public int? GuestAcountId { get; set; }
        public Reservation Reservation { get; set; }
        public GuestReservationJunction GuestReservationJunction {get; set;}
        public List<RoomType> RoomTypes { get; set; }
        public GuestAccount GuestAccount { get; set; }
   
        [Display(Name = "Check In")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CheckInDateTime { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CheckOutDateTime { get; set; }

    }
}