using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotelApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MyHotelApp.ViewModels
{
    public class AdministratorFormViewModel
    {
        public Room Room { get; set; }

        public IEnumerable<Room> RoomList { get; set; }

        [Display(Name = "Room Type")]
        public RoomType RoomType { get; set; }
    }
}