using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyHotelApp.Models;
using System.Data.Entity.Validation;
using System.Data.Entity;
using MyHotelApp.ViewModels;


namespace MyHotelApp.Controllers
{
    [Authorize(Roles = "CanAdministrate")]
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

        public ActionResult SaveHotelName(NameHotelViewModel nameHotelViewModel)
        {
            var hotel = nameHotelViewModel.HotelInfo;
            _context.HotelInfo.Add(hotel);

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return View("HotelEntryForm");
        }

        public ActionResult HotelDetails()
        {
            return View("HotelDetails");
        }
        public ActionResult Save(RoomType roomType)
        {

            roomType.Cost = Convert.ToDouble(roomType.Cost);

            if (roomType.Id == 0)
            {
                _context.RoomTypes.Add(roomType);
                int i = 1;
                while (i <= roomType.Quantity)
                {
                    Room room = new Room();
                    room.IsClean = true;
                    room.RoomStatusId = 2;

                    room.RoomTypeId = roomType.Id;
                    _context.Rooms.Add(room);
                    try
                    {
                        _context.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        Console.WriteLine(e);
                    }
                    i++;


                }
            }
            else
            {

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

        public ActionResult SeeAllRooms()
        {

            var rooms = _context.Rooms.ToList();
            List<RoomInfo> list = new List<RoomInfo>();
            foreach (var el in rooms)
            {

                var roomtype = _context.RoomTypes.SingleOrDefault(t => t.Id == el.RoomTypeId);
                string type = roomtype.Type;
                var roomstatus = _context.RoomStatuses.SingleOrDefault(s => s.Id == el.RoomStatusId);
                string status = roomstatus.StatusName;
                var info = new RoomInfo()
                {
                    Room = el,
                    RoomType = type,
                    RoomStatus = status
                };

                list.Add(info);
            }

            var viewmodel = new RoomViewModel()
            {
                RoomInfoList = list
            };

            return View("SeeAllRooms", viewmodel);
        }


        public ActionResult HotelMap()
        {
            return View("HotelMap");
        }

        public ActionResult NameHotel()
        {
            var states = _context.States.ToList();
            var viewModel = new NameHotelViewModel()
            {
                States = states
            };
            return View("NameHotel", viewModel);
        }

        public ActionResult AdministratorHome()
        {
            return View();
        }

        //public ActionResult GeoCodeAddress()
        //{
        //    string strAddress = "Noida 201301, India";
        //    String url = "http://maps.google.com/maps/api/geocode/xml?address=”+strAddress+”&sensor=false";


        //    return View("HotelEntryForm");

        //}

        //public void GetLatLong(string address)
        //{

        //        string url = "http://maps.googleapis.com/maps/api/geocode/json?sensor=true&address=";

        //        dynamic googleResults = new Uri(url + address).GetDynamicJsonObject();
        //        foreach (var result in googleResults.results)
        //        {
        //            Console.WriteLine("[" + result.geometry.location.lat + "," + result.geometry.location.lng + "] " + result.formatted_address);
        //        }

        //}
    }
}
