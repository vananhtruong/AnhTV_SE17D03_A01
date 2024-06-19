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
        public bool AddReservations(Reservation reservation) => ReservationDAO.AddReservation(reservation);

        public List<Reservation> GetReservations() => ReservationDAO.GetReservations();

        public List<Reservation> GetReservationsByCustomerId(int customerId) => ReservationDAO.GetReservationByCustomerId(customerId);

        public List<Reservation> Search(DateTime startDate, DateTime endDate) => ReservationDAO.SearchReservations(startDate, endDate);
    }
}
