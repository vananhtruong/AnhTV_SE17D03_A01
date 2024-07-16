using BussinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingDetailService : IBookingDetailService
    {
        private readonly IBookingDetailRepository iCustomerRepository;
        public BookingDetailService()
        {
            iCustomerRepository = new BookingDetailRepository();
        }
        public List<BookingDetail> GetBookingById(int id)
        {
            return iCustomerRepository.GetBookingById(id);
        }


    }
}
