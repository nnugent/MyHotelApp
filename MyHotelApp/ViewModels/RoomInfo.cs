using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotelApp.Models;


namespace MyHotelApp.ViewModels
{
    public class RoomInfo
    {
        public Room Room { get; set; }
        public string RoomStatus { get; set; }
        public string RoomType { get; set; }
    }
}