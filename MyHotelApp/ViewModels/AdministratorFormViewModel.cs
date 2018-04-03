using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotelApp.Models;

namespace MyHotelApp.ViewModels
{
    public class AdministratorFormViewModel
    {
        public Room Room { get; set; }

        public IEnumerable<Room> RoomList { get; set; }
        public RoomType RoomType { get; set; }
    }
}