using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class BookingReservation
    {
        public int BookingReservationId { get; set; }
        public DateOnly? BookingDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public string? BookingStatus { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

        public virtual Customer? Customer { get; set; }
    }
}
