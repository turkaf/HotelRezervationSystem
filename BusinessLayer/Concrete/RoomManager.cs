using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RoomManager : IRoomService
    {
        IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public void TAdd(Room entity)
        {
            _roomDal.Insert(entity);
        }

        public void TDelete(Room entity)
        {
            _roomDal.Delete(entity);
        }

        public Room TGetByID(int id)
        {
            return _roomDal.GetByID(id);
        }

        public List<Room> TGetList()
        {
            return _roomDal.GetList();
        }

        public List<Room> TGetListRoomWithType()
        {
            return _roomDal.GetListRoomWithType();
        }

        public void TUpdate(Room entity)
        {
            _roomDal.Update(entity);
        }
    }
}
