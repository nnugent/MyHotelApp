using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHotelApp.Models
{
    public class GuestAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsMember { get; set; }
       
    }
}