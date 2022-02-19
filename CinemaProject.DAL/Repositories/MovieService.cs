using CinemaProject.Common.Repositories;
using CinemaProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.DAL.Repositories
{
    public class MovieService : IMovieRepository<Movie>
    {
        private readonly CinemaContext _context;

        public MovieService(CinemaContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.Movies.Remove(Get(id));
            _context.SaveChanges();
        }

        public Movie Get(int id)
        {
            Movie entity = _context.Movies.Find(id);
            if (entity is null) throw new ArgumentOutOfRangeException();
            return entity;
        }

        public IEnumerable<Movie> Get()
        {
            return _context.Movies;
        }

        public int Insert(Movie entity)
        {
            _context.Movies.Add(entity);
            _context.SaveChanges();
            return entity.Id_Movie;
        }

        public void Update(int id, Movie entity)
        {
            Movie old = Get(id);
            old.Title = entity.Title;
            old.SubTitle = entity.SubTitle;
            old.Duration = entity.Duration;
            old.ReleaseYear = entity.ReleaseYear;
            old.Synopsis = entity.Synopsis;
            old.PosterUrl = entity.PosterUrl;
            _context.SaveChanges();
        }
    }
}
