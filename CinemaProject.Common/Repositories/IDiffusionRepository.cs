using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Common.Repositories
{
    public interface IDiffusionRepository<TDiffusion> : IRepositories<TDiffusion, int>
    {
        public IEnumerable<TDiffusion> GetByCinema(int id);
        public IEnumerable<TDiffusion> GetByMovie(int id);
        public IEnumerable<TDiffusion> GetByCinemaAtDate(int id, DateTime date);
    }
}
