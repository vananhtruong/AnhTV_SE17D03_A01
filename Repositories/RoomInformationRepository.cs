using BussinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        public void SaveRoom(RoomInformation p) => RoomInformationDAO.SaveRoom(p);
        public void UpdateRoom(RoomInformation p) => RoomInformationDAO.UpdateRoom(p);
        public void DeleteRoom(RoomInformation p) => RoomInformationDAO.DeleteRoom(p);
        public List<RoomInformation> SearchRoom(string query) => RoomInformationDAO.SearchRoom(query);
        public List<RoomInformation> GetRoomInformations() => RoomInformationDAO.GetRoomInformations();
        public RoomInformation GetRoomById(int id) => RoomInformationDAO.GetRoomById(id);
    }
}
