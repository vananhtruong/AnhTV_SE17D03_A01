using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomInformationDAO
    {
        //public static List<RoomInformation> GetRoomInformations()
        //{
        //    RoomInformation r201 = new() { RoomID = 1, RoomTypeID = 1, RoomNumber = "Phòng 201", RoomDescription = "Có 2 phòng ngủ", RoomMaxCapacity = 4, RoomPricePerDate = 200, RoomStatus = "Active" };
        //    RoomInformation r205 = new() { RoomID = 2, RoomTypeID = 2, RoomNumber = "Phòng 205", RoomDescription = "Có 4 phòng ngủ", RoomMaxCapacity = 2, RoomPricePerDate = 500, RoomStatus = "Active" };
        //    RoomInformation r208 = new() { RoomID = 3, RoomTypeID = 3, RoomNumber = "Phòng 208", RoomDescription = "Có 2 phòng ngủ", RoomMaxCapacity = 4, RoomPricePerDate = 200, RoomStatus = "Active" };
        //    var listRoom = new List<RoomInformation>();
        //    try
        //    {
        //        listRoom.Add(r201);
        //        listRoom.Add(r205);
        //        listRoom.Add(r208);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    return listRoom;
        //}
        public static List<RoomInformation> listRoom = new List<RoomInformation>
        {
        new RoomInformation(1,"201","Co 2 phong ngu",4,"Active",200,1),
        new RoomInformation(2,"202","Co 2 phong ngu",4,"Active",400,2),
        new RoomInformation(3,"203","Co 2 phong ngu",4,"Active",300,3)
        };
        public RoomInformationDAO()
        {

        }

        public static List<RoomInformation> GetRoomInformations()
        {
            return listRoom;
        }
        public static void SaveRoom(RoomInformation p)
        {
            listRoom.Add(p);
        }
        public static void UpdateRoom(RoomInformation room)
        {
            foreach (RoomInformation p in listRoom.ToList())
            {
                if (p.RoomID == room.RoomID)
                {
                    p.RoomID = room.RoomID;
                    p.RoomNumber = room.RoomNumber;
                    p.RoomDescription = room.RoomDescription;
                    p.RoomMaxCapacity = room.RoomMaxCapacity;
                    p.RoomStatus = room.RoomStatus;
                    p.RoomPricePerDate = room.RoomPricePerDate;
                    p.RoomTypeID = room.RoomTypeID;
                }
            }
        }
        public static void DeleteRoom(RoomInformation room)
        {
            foreach (RoomInformation p in listRoom.ToList())
            {
                if (p.RoomID == room.RoomID)
                {
                    listRoom.Remove(p);
                }
            }
        }

        public static RoomInformation GetRoomById(int id)
        {
            foreach (RoomInformation p in listRoom.ToList())
            {
                if (p.RoomID == id)
                {
                    return p;
                }
            }
            return null;
        }
        public static List<RoomInformation> SearchRoom(string query)
        {
            return listRoom.Where(r => r.RoomNumber.Contains(query) ||
                                       r.RoomDescription.Contains(query) ||
                                       r.RoomStatus.Contains(query)).ToList();
        }
        public static int Generateint()
        {
            int id = 1;
            bool check = true;
            while (check)
            {
                check = false;
                foreach (var item in listRoom)
                {
                    if (item.RoomID == id) { id += 1; check = true; }
                }
            }
            return id;
        }
    }
}
