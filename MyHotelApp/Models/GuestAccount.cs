using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyHotelApp.Models
{
    public class GuestAccount
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name="Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name="Address Line 2")]
        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public int StateId { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }

        [Display(Name ="Zip Code")]
        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsMember { get; set; }

       
        [Required]
        public string UserId { get; set; }

       


    }
}