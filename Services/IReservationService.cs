using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IReservationService
    {
        List<BookingReservation> GetReservations();
        List<BookingReservation> GetReservationsByCustomerId(int customerId);
        bool AddReservations(BookingReservation reservation, List<BookingDetail> bookingDetails);
        void UpdateBooking(BookingReservation reservation);
    }
}
