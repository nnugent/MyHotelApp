using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyHotelApp.Models
{
    public class RoomType
    {
        public int Id { get; set; }

        public byte Quantity { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public double Cost { get; set; }

    }
}