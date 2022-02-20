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
    public class DiffusionService : IDiffusionRepository<Diffusion>
    {
        private readonly CinemaContext _context;

        public DiffusionService(CinemaContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.Diffusions.Remove(Get(id));
            _context.SaveChanges();
        }

        public Diffusion Get(int id)
        {
            Diffusion entity = _context.Diffusions.Find(id);
            if (entity is null) throw new ArgumentOutOfRangeException();
            return entity;
        }

        public IEnumerable<Diffusion> Get()
        {
            return _context.Diffusions
                .Include(d => d.CinemaRoom)
                .Include(d=> d.Movie);
        }

        public IEnumerable<Diffusion> GetByCinema(int id)
        {
            return Get().Where(d => d.CinemaRoom.Id_CinemaPlace == id);
        }

        public IEnumerable<Diffusion> GetByCinemaAtDate(int id, DateTime date)
        {
            return GetByCinema(id).Where(d => d.DiffusionDate == date);
        }

        public IEnumerable<Diffusion> GetByMovie(int id)
        {
            return Get().Where(d => d.Id_Movie == id);
        }

        public int Insert(Diffusion entity)
        {
            _context.Diffusions.Add(entity);
            _context.SaveChanges();
            return entity.Id_Diffusion;
        }

        public void Update(int id, Diffusion entity)
        {
            Diffusion old = Get(id);
            old.DiffusionDate = entity.DiffusionDate;
            old.DiffusionTime = entity.DiffusionTime;
            old.AudLang = entity.AudLang;
            old.SubTitleLang = entity.SubTitleLang;
            old.Id_Movie = entity.Id_Movie;
            old.Id_CinemaRoom = entity.Id_CinemaRoom;
            _context.SaveChanges();
        }
    }
}
