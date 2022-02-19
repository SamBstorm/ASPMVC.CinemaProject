using CinemaProject.Common.Repositories;
using CinemaProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.DAL.Repositories
{
    public class CinemaPlaceService : ICinemaPlaceRepository<CinemaPlace>
    {
        protected readonly CinemaContext _context;
        public CinemaPlaceService(CinemaContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.CinemaPlaces.Remove(Get(id));
            _context.SaveChanges();
        }

        public CinemaPlace Get(int id)
        {
            CinemaPlace entity = _context.CinemaPlaces.Find(id);
            if (entity is null) throw new ArgumentOutOfRangeException();
            return entity;
        }

        public IEnumerable<CinemaPlace> Get()
        {
            return _context.CinemaPlaces;
        }

        public int Insert(CinemaPlace entity)
        {
            _context.CinemaPlaces.Add(entity);
            _context.SaveChanges();
            return entity.Id_CinemaPlace;
        }

        public void Update(int id, CinemaPlace entity)
        {
            CinemaPlace old = Get(id);
            entity.Name = old.Name;
            entity.City = old.City;
            entity.Street = old.Street;
            entity.Number = old.Number;
            entity.ZipCode = old.ZipCode;
            _context.SaveChanges();
        }
    }
}
