using BussinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService()
        {
            _reservationRepository = new ReservationRepository();
        }

        public bool AddReservations(BookingReservation reservation, List<BookingDetail> bookingDetails) => _reservationRepository.AddReservations(reservation, bookingDetails);

        public List<BookingReservation> GetReservations() => _reservationRepository.GetReservations();

        public List<BookingReservation> GetReservationsByCustomerId(int customerId) => _reservationRepository.GetReservationsByCustomerId(customerId);
        public void UpdateBooking(BookingReservation bk) => _reservationRepository.UpdateBooking(bk);
    }
}
