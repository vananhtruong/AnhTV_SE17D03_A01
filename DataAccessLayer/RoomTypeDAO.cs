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
        public static List<RoomType> GetRoomTypes()
        {
            RoomType opera = new() { RoomTypeID = 1, RoomTypeName = "Opera", TypeDescription = "Opera is so good", TypeNote = "Normal" };
            RoomType excute = new() { RoomTypeID = 2, RoomTypeName = "Excusitive Suit", TypeDescription = "Excusitive Suit is so good", TypeNote = "Luxury" };
            RoomType duxule = new() { RoomTypeID = 3, RoomTypeName = "Duxule", TypeDescription = "Duxule is so good", TypeNote = "Special" };

            var listCategories = new List<RoomType>();

            try
            {
                listCategories.Add(opera);
                listCategories.Add(excute);
                listCategories.Add(duxule);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return listCategories;
        }
    }
}
