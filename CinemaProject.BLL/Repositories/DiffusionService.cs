using CinemaProject.BLL.Entities;
using CinemaProject.BLL.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.BLL.Repositories
{
    public class DiffusionService : IDiffusionRepository
    { 
        private readonly Common.Repositories.IDiffusionRepository<DAL.Entities.Diffusion> _repository;

        public DiffusionService(Common.Repositories.IDiffusionRepository<DAL.Entities.Diffusion> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public DiffusionCinema Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(DiffusionCinema entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(int id, DiffusionCinema entity)
        {
            _repository.Update(id, entity.ToDAL());
        }

        public DiffusionCinema Get()
        {
            return _repository.Get().ToBLL();
        }

        public DiffusionCinema GetByCinema(int id)
        {
            return _repository.GetByCinema(id).ToBLL();
        }

        public DiffusionCinema GetByCinemaAtDate(int id, DateTime date)
        {
            return _repository.GetByCinemaAtDate(id, date).ToBLL();
        }

        public DiffusionCinema GetByMovie(int id)
        {
            return _repository.GetByMovie(id).ToBLL();
        }
    }
}
