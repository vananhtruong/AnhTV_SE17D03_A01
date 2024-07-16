using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class BookingDetailDAO
    {
        private static BookingDetailDAO instance;
        private readonly FuminiHotelManagementContext dbcontext;

        private BookingDetailDAO()
        {
            if (instance == null)
            {
                dbcontext = new FuminiHotelManagementContext();
            }
        }

        //instance singleton
        public static BookingDetailDAO getInstance()
        {
            if (instance == null)
            {
                instance = new BookingDetailDAO();
            }
            return instance;
        }
        public  List<BookingDetail> GetBookingById(int id)
        {
            return dbcontext.BookingDetails.Where(b => b.BookingReservationId == id).Include(r=> r.Room).ToList();
        }

    }
}
