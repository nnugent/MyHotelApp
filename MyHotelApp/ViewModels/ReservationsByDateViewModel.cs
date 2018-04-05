using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyHotelApp.Models; 

namespace MyHotelApp.ViewModels
{
    public class ReservationsByDateViewModel
    {
        public List <Reservation> Reservations { get; set; }
        public List <GuestAccount> GuestAccounts { get; set; }

        public SearchReservationsViewModel SearchReservationsViewModel { get; set; }

        public ReservationsByDateViewModel()
        {
            SearchReservationsViewModel = new SearchReservationsViewModel();
            SearchReservationsViewModel.CheckInDate = DateTime.Today;
        }
    }
}