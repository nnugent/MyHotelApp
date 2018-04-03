using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Data.Entity;
using MyHotelApp.ViewModels;

namespace MyHotelApp.Controllers
{
    public class GuestController : Controller

    {
        
        
        // GET: Guest
        public ActionResult Index()
        {
            return View();
        }

        public GuestController()
        {

        }
    }
}