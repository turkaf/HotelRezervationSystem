using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RoomTypeManager : IRoomTypeService
    {
        IRoomTypeDal _roomTypeDal;

        public RoomTypeManager(IRoomTypeDal roomTypeDal)
        {
            _roomTypeDal = roomTypeDal;
        }

        public void TAdd(RoomType entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(RoomType entity)
        {
            throw new NotImplementedException();
        }

        public RoomType TGetByID(int id)
        {
            return _roomTypeDal.GetByID(id);
        }

        public List<RoomType> TGetList()
        {
            return _roomTypeDal.GetList();
        }

        public void TUpdate(RoomType entity)
        {
            throw new NotImplementedException();
        }
    }
}
