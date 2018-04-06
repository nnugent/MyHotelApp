using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotelApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MyHotelApp.ViewModels
{
    public class NameHotelViewModel
    {
        public List<State> States { get; set; }
        public HotelInfo HotelInfo { get; set; }
    }
}