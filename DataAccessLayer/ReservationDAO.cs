using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReservationDAO
    {
        public static List<Reservation> _listReservations = new List<Reservation>();
        public static List<Reservation> GetReservations() => _listReservations;
        public static List<Reservation> GetReservationByCustomerId(int customerId)
        {
            return _listReservations.Where(r => r.CustomerId == customerId).ToList();
        }
        public static List<Reservation> SearchReservations(DateTime startDate, DateTime endDate)
        {
            return _listReservations
            .Where(r => r.StartDate >= startDate && r.EndDate <= endDate)
            .ToList();
        }

        public static bool AddReservation(Reservation reservation)
        {
            if(reservation != null)
            {
                _listReservations.Add(reservation); return true;
            }
            return false;
        }
    }
}
