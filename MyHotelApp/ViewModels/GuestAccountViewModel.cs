using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotelApp.Models;

namespace MyHotelApp.ViewModels
{
    public class GuestAccountViewModel
    {
        public List<State> States { get; set; }
        public GuestAccount GuestAccount { get; set; }
    }
}