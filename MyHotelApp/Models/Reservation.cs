using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHotelApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int? GuestAccountId { get; set; }

        [ForeignKey("GuestAccountId")]
        public GuestAccount GuestAccount { get; set; }

        public int? RoomId { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public bool CheckedIn { get; set; }

        public Double Balance { get; set; }

        public int RoomTypeId { get; set; }

        [ForeignKey("RoomTypeId")]
        public RoomType RoomType { get; set; }
    }
}