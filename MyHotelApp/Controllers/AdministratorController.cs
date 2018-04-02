using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyHotelApp.Models;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace MyHotelApp.Controllers
{
    public class AdministratorController : Controller
    {
        private ApplicationDbContext _context;

        public AdministratorController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HotelEntryForm()
        {
            return View("HotelEntryForm");
        }

        public ActionResult CreateRoomType()
        {
            return View("CreateRoomType");
        }

        public ActionResult GoToRoomCreator()
        {
            return View("CreateRoomType");
        }

        public ActionResult Save(RoomType roomType)
        {
            if (roomType.Id == 0) {
                _context.RoomTypes.Add(roomType);
            }
            else {

                var roomTypeInDb = _context.RoomTypes.Single(r => r.Id == roomType.Id);
                roomTypeInDb.Quantity = roomType.Quantity;
                roomTypeInDb.Description = roomType.Description;
                roomTypeInDb.Type = roomType.Type;

                    }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return View("CreateRoomType");
        }
    }
}