using CinemaProject.BLL.Entities;
using CinemaProject.BLL.Handlers;
using CinemaProject.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.BLL.Repositories
{
    public class CinemaPlaceService : ICinemaPlaceRepository<CinemaPlace>
    {
        private readonly ICinemaPlaceRepository<DAL.Entities.CinemaPlace> _repository;

        public CinemaPlaceService(ICinemaPlaceRepository<DAL.Entities.CinemaPlace> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public CinemaPlace Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<CinemaPlace> Get()
        {
            return _repository.Get().Select(c => c.ToBLL());
        }

        public int Insert(CinemaPlace entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(int id, CinemaPlace entity)
        {
            _repository.Update(id, entity.ToDAL());
        }
    }
}
