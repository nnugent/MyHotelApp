using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyHotelApp.Models;
using System.Data.Entity.Validation;
using System.Data.Entity;
using MyHotelApp.ViewModels;
using System.Web.UI;


namespace MyHotelApp.Controllers
{
    public class GuestMemberController : Controller
    {
        // GET: GuestMember

        private ApplicationDbContext _context;
        public GuestMemberController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccountDetailsForm()
        {
            var states = _context.States.ToList();
            var viewModel = new GuestAccountViewModel()
            {
                States = states
            };
            return View("AccountDetailsForm", viewModel);
        }

        public ActionResult SaveDetails(GuestAccount guestAccount)
        {
            var userid = User.Identity.GetUserId();
            if (guestAccount.Id < 1) {
                guestAccount.UserId = userid;
                guestAccount.IsMember = true;
                _context.GuestAccounts.Add(guestAccount);
                }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return View("Index");
        }

        public ActionResult CheckAvailability()
        {
           
            return View("ReservationForm");
        }

        [AllowAnonymous]
        public ActionResult ReservationForm()
        {
            var roomTypes = _context.RoomTypes.ToList();
            var states = _context.States.ToList();
            var viewModel = new ReservationFormViewModel()
            {
                RoomTypes = roomTypes,
                CheckInDateTime = DateTime.Today,
                CheckOutDateTime = DateTime.Today.Add(TimeSpan.FromHours(24)),
                States = states
            };
            return View("ReservationForm", viewModel);
        }

        public ActionResult Reservations()
        {
            var userid = User.Identity.GetUserId();
            var currentUser = _context.GuestAccounts.FirstOrDefault(g => g.UserId == userid);
            var reservations = _context.Reservations.Where(r => r.GuestAccountId == currentUser.Id).ToList();
            var viewModel = new GuestReservationViewModel
            {
                GuestAccount = currentUser,
                Reservations = reservations
            };
            return View("Reservations", viewModel);
        }



        public ActionResult Edit(int id)
        {
            var roomTypes = _context.RoomTypes.ToList();
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);
            var checkInMonth = Convert.ToString(reservation.CheckIn.Month);
            var checkInDay = Convert.ToString(reservation.CheckIn.Day);
            var checkOutMonth = Convert.ToString(reservation.CheckOut.Month);
            var checkOutDay = Convert.ToString(reservation.CheckOut.Day);
            var viewModel = new ReservationFormViewModel()
            {
                RoomTypes = roomTypes,
                Reservation = reservation,
              

            };
            return View("ReservationForm", viewModel);
        }
        public ActionResult SaveReservation(ReservationFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var guestAccountId = _context.GuestAccounts.SingleOrDefault(a => a.UserId == userId).Id;
            
            viewModel.Reservation.GuestAccountId = guestAccountId;
            var checkin = viewModel.CheckInDateTime;
            var checkout = viewModel.CheckOutDateTime;
            viewModel.Reservation.CheckIn = new DateTime(checkin.Year, checkin.Month, checkin.Day, 16, 0, 0);
            viewModel.Reservation.CheckOut = new DateTime(checkout.Year, checkout.Month, checkout.Day, 11, 0, 0);


            
            var possibleRooms = _context.Rooms.Where(r => r.RoomTypeId == viewModel.Reservation.RoomTypeId).ToList();

            var reservations = _context.Reservations.ToList();

            List<int?> reservationRoomIds = new List<int?>();
            foreach (var reservation in reservations)
            {
                reservationRoomIds.Add(reservation.RoomId);
            }

            for(int i =0; i <possibleRooms.Count; i++)
            {
                if (reservationRoomIds.Contains(possibleRooms[i].Id))
                {
                    possibleRooms.Remove(possibleRooms[i]);
                }
            }
            var room = possibleRooms.FirstOrDefault(r => r.RoomTypeId == viewModel.Reservation.RoomTypeId);


            var roomId = room.Id;
            var cost = _context.RoomTypes.FirstOrDefault(t => t.Id == room.RoomTypeId).Cost;
            
            viewModel.Reservation.RoomId = roomId;
            viewModel.Reservation.Balance = cost;

            _context.Reservations.Add(viewModel.Reservation);
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            string message = "Your reservation was successful.";
            var controller = new SmsController();
            controller.SendEmail(message, "stephanie.glyzewski@gmail.com");

            return RedirectToAction("Reservations");
        }

        //public string reservationMessageBuilder()
        //{
        //    StringBuilder message = new StringBuilder();
        //    return reservationMessageBuilder;
        //}

        public bool CheckAvailability(DateTime dateTime)
        {
            return true;
        }


    }
}