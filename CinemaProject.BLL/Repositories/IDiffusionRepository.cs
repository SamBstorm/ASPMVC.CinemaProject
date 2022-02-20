using CinemaProject.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.BLL.Repositories
{
    public interface IDiffusionRepository
    {
        public DiffusionCinema Get(int id);
        public DiffusionCinema Get();
        public DiffusionCinema GetByCinema(int id);
        public DiffusionCinema GetByMovie(int id);
        public DiffusionCinema GetByCinemaAtDate(int id, DateTime date);
        public int Insert(DiffusionCinema entity);
        public void Update(int id, DiffusionCinema entity);
        public void Delete(int id);
    }
}
