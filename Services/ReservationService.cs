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

        public bool AddReservations(Reservation reservation) => _reservationRepository.AddReservations(reservation);

        public List<Reservation> GetReservations() => _reservationRepository.GetReservations();

        public List<Reservation> GetReservationsByCustomerId(int customerId) => _reservationRepository.GetReservationsByCustomerId(customerId);

        public List<Reservation> Search(DateTime startDate, DateTime endDate) => _reservationRepository.Search(startDate, endDate);
    }
}
