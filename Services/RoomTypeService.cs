using BussinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository iRoomTypeRepository;
        public RoomTypeService()
        {
            iRoomTypeRepository = new RoomTypeRepository();
        }
        public List<RoomType> GetRoomTypes()
        {
            return iRoomTypeRepository.GetRoomTypes();
        }

    }
}
