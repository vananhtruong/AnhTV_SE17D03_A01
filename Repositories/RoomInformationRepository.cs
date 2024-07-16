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
        public void SaveRoom(RoomInformation p) => RoomInformationDAO.Instance().SaveRoom(p);
        public void UpdateRoom(RoomInformation p) => RoomInformationDAO.Instance().UpdateRoom(p);
        public void DeleteRoom(RoomInformation p) => RoomInformationDAO.Instance().DeleteRoom(p);
        public List<RoomInformation> SearchRoom(string query) => RoomInformationDAO.Instance().SearchRoom(query);
        public List<RoomInformation> GetRoomInformations() => RoomInformationDAO.Instance().GetRoomInformations();
        public RoomInformation GetRoomById(int id) => RoomInformationDAO.Instance().GetRoomById(id);
    }
}
