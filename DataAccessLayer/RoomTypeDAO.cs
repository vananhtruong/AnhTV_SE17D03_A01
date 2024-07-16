using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomTypeDAO
    {
        private static RoomTypeDAO instance;
        private readonly FuminiHotelManagementContext dbcontext;

        public RoomTypeDAO()
        {
            if (instance == null)
            {
                dbcontext = new FuminiHotelManagementContext();
            }
        }
        public static RoomTypeDAO Instance()
        {
            if (instance == null)
            {
                instance = new RoomTypeDAO();
            }
            return instance;
        }
        public List<RoomType> GetRoomTypes()
        {
            return dbcontext.RoomTypes.ToList();
        }
    }
}
