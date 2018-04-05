using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyHotelApp.ViewModels
{
    public class SearchReservationsViewModel
    {
        [Display(Name = "Filter Date:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CheckInDate { get; set; }
    }
}