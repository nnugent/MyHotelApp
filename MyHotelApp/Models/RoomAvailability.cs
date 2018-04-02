using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelApp.Models
{
    public class RoomAvailability
    {
        public int Id { get; set; }
        public string CurrentAvailability { get; set; }
        public DateTime Date { get; set; }
    }
}