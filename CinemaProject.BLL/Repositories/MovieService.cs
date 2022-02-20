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
    public class MovieService : IMovieRepository<Movie>
    {
        private readonly IMovieRepository<DAL.Entities.Movie> _repository;

        public MovieService(IMovieRepository<DAL.Entities.Movie> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Movie Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<Movie> Get()
        {
            return _repository.Get().Select(m => m.ToBLL());
        }

        public int Insert(Movie entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(int id, Movie entity)
        {
            _repository.Update(id, entity.ToDAL());
        }
    }
}
