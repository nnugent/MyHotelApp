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


    }
}