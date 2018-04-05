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
using MyHotelApp.Controllers;




namespace MyHotelApp.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context; 
        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult SeeReservations (SearchReservationsViewModel checkInDate)
        {
            var date = new DateTime(2018, checkInDate.CheckInMonth, checkInDate.CheckInDay, 16, 0, 0);

            var reservations = _context.Reservations.Where(r => r.CheckIn == date).ToList();
            var guests = _context.GuestAccounts.ToList();
            var viewModel = new ReservationsByDateViewModel()
            {
                Reservations = reservations,
                GuestAccounts = guests,
            };
            return View("ReservationsTable", viewModel);
        }


        public ActionResult SeeAllReservationsTable()
        {

            var reservations = _context.Reservations.ToList();
            var guests = _context.GuestAccounts.ToList();
            var viewModel = new ReservationsByDateViewModel()
            {
                Reservations = reservations,
                GuestAccounts = guests,
            };
            return View("SeeAllReservationsTable", viewModel);
        }
        public ActionResult SearchReservationsByDate()
        {
            var viewModel = new SearchReservationsViewModel();
            return PartialView("SearchReservationsByDate", viewModel);
        }

        public ActionResult MarkRoomAsClean(int? id)
        {
            var roomInDb = _context.Rooms.FirstOrDefault(r => r.Id == id);
            roomInDb.IsClean = true;
            roomInDb.RoomStatusId = 1;
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            string message = "Your room is ready to check in.";
            string number = "12624905749";
            var controller = new SmsController();
            controller.SendSms(message, number);
            return RedirectToAction("SeeAllRooms");
        }

        public ActionResult MarkAsOccupied(int? id)
        {
            var roomInDb = _context.Rooms.FirstOrDefault(r => r.Id == id);
           roomInDb.RoomStatusId = 3;
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("SeeAllRooms");
        }

        public ActionResult MarkAsEmpty(int? id)
        {
            var roomInDb = _context.Rooms.FirstOrDefault(r => r.Id == id);
            roomInDb.RoomStatusId = 2;
            roomInDb.IsClean = false;
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("SeeAllRooms");
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


            var roomStatusList = _context.RoomStatuses.ToList();
            var viewModel = new RoomViewModel()
            {
                RoomInfoList = list,
              

            };
            return View("SeeAllRooms", viewModel);

            
        }

        public ActionResult MarkRoomAsDirty(int? id)
        {
            var roomInDb = _context.Rooms.FirstOrDefault(r => r.Id == id);
            roomInDb.IsClean = false;
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
           
            return RedirectToAction("SeeAllRooms");

        }


        public ActionResult CheckInGuest(int? id)
        {

            var reservationInDb = _context.Reservations.FirstOrDefault(r => r.Id == id);
            reservationInDb.CheckedIn = true;
            var roomInDb = _context.Rooms.FirstOrDefault(r => r.Id == reservationInDb.RoomId);
            roomInDb.RoomStatusId = 3;
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

           

            //twilio logic!
            var reservations = _context.Reservations.ToList();
            var guests = _context.GuestAccounts.ToList();
            var viewModel = new ReservationsByDateViewModel()
            {
                Reservations = reservations,
                GuestAccounts = guests,
            };


            return View("SeeAllReservationsTable", viewModel);
        }

        public ActionResult EditReservation(int? id)
        {
            var roomTypes = _context.RoomTypes.ToList();
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);
            var checkInMonth = Convert.ToString(reservation.CheckIn.Month);
            var checkInDay = Convert.ToString(reservation.CheckIn.Day);
            var checkOutMonth = Convert.ToString(reservation.CheckOut.Month);
            var checkOutDay = Convert.ToString(reservation.CheckOut.Day);
            var guestAccount = _context.GuestAccounts.FirstOrDefault(g => g.Id == reservation.GuestAccountId);
            var viewModel = new ReservationFormViewModel()
            {
                RoomTypes = roomTypes,
                Reservation = reservation,
                CheckInMonth = checkInMonth,
                CheckInDay = checkInDay,
                CheckOutMonth = checkOutMonth,
                CheckOutDay = checkOutDay,
                GuestAccount = guestAccount

            };
            return View("EditReservation", viewModel);
        }
        public ActionResult SeeReservationDetails(int? id)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);
            var guestAccount = _context.GuestAccounts.FirstOrDefault(g => g.Id == reservation.GuestAccountId);
            var room = _context.Rooms.FirstOrDefault(r => r.Id == reservation.RoomId);
            var roomType = _context.RoomTypes.FirstOrDefault(t => t.Id == room.RoomTypeId);
            var roomStatus = _context.RoomStatuses.FirstOrDefault(s => s.Id == room.RoomStatusId);
            var email = _context.Users.FirstOrDefault(u => u.Id == guestAccount.UserId).UserName;
            var viewModel = new ReservationDetailsViewModel()
            {
                Reservation = reservation,
                GuestAccount = guestAccount,
                Room = room,
                RoomType = roomType,
                RoomStatus = roomStatus,
                Email = email
            };
            return View("SeeReservationDetails", viewModel);
        }

        public ActionResult CheckOutGuest (int id)
        {
            var reservationInDb = _context.Reservations.FirstOrDefault(r => r.Id == id);
            reservationInDb.CheckedIn = false;
            var roomInDb = _context.Rooms.FirstOrDefault(r => r.Id == reservationInDb.RoomId);
            roomInDb.RoomStatusId = 2;
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }


            //twilio logic!
            var reservations = _context.Reservations.ToList();
            var guests = _context.GuestAccounts.ToList();
            var viewModel = new ReservationsByDateViewModel()
            {
                Reservations = reservations,
                GuestAccounts = guests,
            };


            return View("SeeAllReservationsTable", viewModel);
        }

    }
}