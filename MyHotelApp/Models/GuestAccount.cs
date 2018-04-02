using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHotelApp.Models
{
    public class GuestAccount
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public int StateId { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsMember { get; set; }
       

    }
}