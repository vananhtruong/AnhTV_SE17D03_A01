using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IReservationRepository
    {
        List<Reservation> GetReservations();
        List<Reservation> GetReservationsByCustomerId(int customerId);
        List<Reservation> Search(DateTime startDate, DateTime endDate);
        bool AddReservations(Reservation reservation); 
    }
}
