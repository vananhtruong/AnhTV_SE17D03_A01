using BussinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public bool AddReservations(BookingReservation reservation, List<BookingDetail> bookingDetails) => ReservationDAO.Instance().AddReservations(reservation, bookingDetails);

        public List<BookingReservation> GetReservations() => ReservationDAO.Instance().GetReservations();

        public List<BookingReservation> GetReservationsByCustomerId(int customerId) => ReservationDAO.Instance().GetReservationByCustomerId(customerId);
        public void UpdateBooking(BookingReservation bk)=> ReservationDAO.Instance().UpdateBooking(bk);

    }
}
