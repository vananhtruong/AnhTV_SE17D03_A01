using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomInformationDAO
    {

        private static RoomInformationDAO instance;
        private readonly FuminiHotelManagementContext dbcontext;

        public RoomInformationDAO()
        {
            if (instance == null)
            {
                dbcontext = new FuminiHotelManagementContext();
            }
        }
        public static RoomInformationDAO Instance()
        {
            if (instance == null)
            {
                instance = new RoomInformationDAO();
            }
            return instance;
        }

        public List<RoomInformation> GetRoomInformations()
        {
            return dbcontext.RoomInformations.Include(r=> r.RoomType).ToList();
        }
        public void SaveRoom(RoomInformation p)
        {
            try
            {
                p.RoomStatus = 1;
                dbcontext.RoomInformations.Add(p);
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateRoom(RoomInformation room)
        {
            try
            {
                var r = dbcontext.RoomInformations.FirstOrDefault(r => r.RoomId == room.RoomId);
                r.RoomNumber = room.RoomNumber;
                r.RoomStatus = room.RoomStatus;
                r.RoomMaxCapacity = room.RoomMaxCapacity;
                r.RoomTypeId = room.RoomTypeId;
                dbcontext.Update(r);
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteRoom(RoomInformation room)
        {
            try
            {
                bool isRoomIdExists = dbcontext.BookingDetails.Any(b => b.RoomId == room.RoomId);

                if (isRoomIdExists)
                {
                    var r = dbcontext.RoomInformations.FirstOrDefault(r => r.RoomId == room.RoomId);
                    r.RoomStatus = 0;
                    dbcontext.Update(r);
                    dbcontext.SaveChanges();
                }
                else
                {
                    var r = dbcontext.RoomInformations.FirstOrDefault(r => r.RoomId == room.RoomId);
                    dbcontext.Remove(r);
                    dbcontext.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RoomInformation GetRoomById(int id)
        {
            RoomInformation r = null;
            try
            {
                r = dbcontext.RoomInformations.FirstOrDefault(r => r.RoomId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
        public List<RoomInformation> SearchRoom(string query)
        {
            try
            {
                int queryInt;
                var products = dbcontext.RoomInformations.AsQueryable(); // Start with IQueryable

                // Apply filters based on different conditions
                if (int.TryParse(query, out queryInt))
                {
                    products = products.Where(p => p.RoomId == queryInt || p.RoomPricePerDay == queryInt
                                                || p.RoomMaxCapacity == queryInt);
                }
                else
                {
                    products = products.Where(p => p.RoomType.RoomTypeName.Contains(query) ||
                                               p.RoomNumber.Contains(query)||
                                               p.RoomDetailDescription.Contains(query));
                }
                return products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching for products: " + ex.Message);
            }
        }
    }
}
