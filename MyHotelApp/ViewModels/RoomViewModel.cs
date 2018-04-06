using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotelApp.Models;
using MyHotelApp.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MyHotelApp.ViewModels
{
    public class RoomViewModel
    {
       public List<RoomInfo> RoomInfoList { get; set; }
       //public RoomType RoomType { get; set; }
       //public RoomStatus RoomStatus { get; set; }

        public DateTime CheckInDate { get; set; }

    }
}