using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotelApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MyHotelApp.ViewModels
{
    public class GuestAccountViewModel
    {
        [Display(Name ="State")]
        public List<State> States { get; set; }

        public GuestAccount GuestAccount { get; set; }
    }
}