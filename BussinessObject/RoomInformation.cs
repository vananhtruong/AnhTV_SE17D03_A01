
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class RoomInformation
    {
        public int RoomID { get; set; }
        public string? RoomNumber { get; set; }
        public string? RoomDescription { get; set; }
        public int? RoomMaxCapacity { get; set; }
        public string? RoomStatus { get; set; }
        public decimal? RoomPricePerDate { get; set; }
        public int RoomTypeID { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
        public RoomInformation() { }
        public RoomInformation(int roomID, string? roomNumber, string? roomDescription, int? roomMaxCapacity, string? roomStatus, decimal? roomPricePerDate, int roomTypeID)
        {
            RoomID = roomID;
            RoomNumber = roomNumber;
            RoomDescription = roomDescription;
            RoomMaxCapacity = roomMaxCapacity;
            RoomStatus = roomStatus;
            RoomPricePerDate = roomPricePerDate;
            RoomTypeID = roomTypeID;
        }

        public virtual RoomType? RoomType { get; set; }

       
    }
}
