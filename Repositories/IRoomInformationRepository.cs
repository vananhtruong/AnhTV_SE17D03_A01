using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomInformationRepository
    {
        void SaveRoom(RoomInformation p);
        void UpdateRoom(RoomInformation p);
        void DeleteRoom(RoomInformation p);
        List<RoomInformation> SearchRoom(string query);
        List<RoomInformation> GetRoomInformations();
        RoomInformation GetRoomById(int id);
    }
}
