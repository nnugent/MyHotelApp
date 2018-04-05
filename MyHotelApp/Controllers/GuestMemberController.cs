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

        public ActionResult ReservationForm()
        {
            var roomTypes = _context.RoomTypes.ToList();
            var viewModel = new ReservationFormViewModel()
            {
                RoomTypes = roomTypes
            };
            return View("ReservationForm", viewModel);
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
                CheckInMonth = checkInMonth,
                CheckInDay= checkInDay,
                CheckOutMonth = checkOutMonth,
                CheckOutDay = checkOutDay

            };
            return View("ReservationForm", viewModel);
        }
        public ActionResult SaveReservation(ReservationFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var guestAccountId = _context.GuestAccounts.SingleOrDefault(a => a.UserId == userId).Id;
            viewModel.Reservation.GuestAccountId = guestAccountId;
            viewModel.Reservation.CheckIn = new DateTime(2018, Convert.ToInt32(viewModel.CheckInMonth), Convert.ToInt32(viewModel.CheckInDay), 16, 0, 0);
            viewModel.Reservation.CheckOut = new DateTime(2018, Convert.ToInt32(viewModel.CheckOutMonth), Convert.ToInt32(viewModel.CheckOutDay), 11, 0, 0);
            var roomId = _context.Rooms.FirstOrDefault(r => r.RoomTypeId == viewModel.Reservation.RoomTypeId).Id;
            viewModel.Reservation.RoomId = roomId;
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

            return View("Index");
        }

        public bool CheckAvailability(DateTime dateTime)
        {
            return true;
        }


    }
}