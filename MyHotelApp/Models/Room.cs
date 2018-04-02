using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHotelApp.Models
{
    public class Room
    {
        public int RoomTypeId { get; set; }

        public int Id { get; set; }

        public bool IsClean { get; set; }

        public string RoomStatus { get; set; }

        [ForeignKey("RoomTypeId")]
        public RoomType RoomType { get; set; }

    }
}