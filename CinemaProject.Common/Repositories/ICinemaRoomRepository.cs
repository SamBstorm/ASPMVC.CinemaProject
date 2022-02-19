using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Common.Repositories
{
    public interface ICinemaRoomRepository<TCinemaRoom> : IRepositories<TCinemaRoom, int>
    {
        public IEnumerable<TCinemaRoom> GetByCinema(int id);
    }
}
