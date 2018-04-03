using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotelApp.Models;

namespace MyHotelApp.ViewModels
{
    public class NameHotelViewModel
    {
        public List<State> States { get; set; }
        public HotelInfo HotelInfo { get; set; }
    }
}