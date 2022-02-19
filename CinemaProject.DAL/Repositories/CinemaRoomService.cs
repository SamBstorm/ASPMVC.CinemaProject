using CinemaProject.Common.Repositories;
using CinemaProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.DAL.Repositories
{
    public class CinemaRoomService : ICinemaRoomRepository<CinemaRoom>
    {

        protected readonly CinemaContext _context;
        public CinemaRoomService(CinemaContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.CinemaRooms.Remove(Get(id));
            _context.SaveChanges();
        }

        public CinemaRoom Get(int id)
        {
            CinemaRoom entity = _context.CinemaRooms.Find(id);
            if (entity is null) throw new ArgumentOutOfRangeException();
            return entity;
        }

        public IEnumerable<CinemaRoom> Get()
        {
            return _context.CinemaRooms.Include(cr => cr.CinemaPlace);
        }

        public IEnumerable<CinemaRoom> GetByCinema(int id)
        {
            return Get().Where(cr => cr.Id_CinemaPlace == id);
        }

        public int Insert(CinemaRoom entity)
        {
            _context.CinemaRooms.Add(entity);
            _context.SaveChanges();
            return entity.Id_CinemaRoom;
        }

        public void Update(int id, CinemaRoom entity)
        {
            CinemaRoom old = Get(id);
            old.SitsCount = entity.SitsCount;
            old.Number = entity.Number;
            old.ScreenHeight = entity.ScreenHeight;
            old.ScreenWidth = entity.ScreenWidth;
            old.Id_CinemaPlace = entity.Id_CinemaPlace;
            old.Can3D = entity.Can3D;
            old.Can4DX = entity.Can4DX;
            _context.SaveChanges();
        }
    }
}
