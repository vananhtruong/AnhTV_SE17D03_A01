using BussinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomInformationService : IRoomInformationService
    {
        private readonly IRoomInformationRepository iRoomInformationRepository;
        public RoomInformationService()
        {
            iRoomInformationRepository = new RoomInformationRepository();
        }
        public void SaveRoom(RoomInformation p)
        {
            iRoomInformationRepository.SaveRoom(p);
        }
        public void UpdateRoom(RoomInformation p)
        {
            iRoomInformationRepository.UpdateRoom(p);
        }
        public void DeleteRoom(RoomInformation p)
        {
            iRoomInformationRepository.DeleteRoom(p);
        }
        public List<RoomInformation> SearchRoom(string query)
        {
            return iRoomInformationRepository.SearchRoom(query);
        }
        public List<RoomInformation> GetRoomInformations()
        {
            return iRoomInformationRepository.GetRoomInformations();
        }
        public RoomInformation GetRoomById(int id)
        {
            return iRoomInformationRepository.GetRoomById(id);
        }
    }
}
