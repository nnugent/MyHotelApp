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
            return View();
        }

        public ActionResult CheckInGuest(int? id)
        {

            var reservationInDb = _context.Reservations.FirstOrDefault(r => r.Id == id);
            reservationInDb.CheckedIn = true;
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