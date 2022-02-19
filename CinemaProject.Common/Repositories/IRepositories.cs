using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Common.Repositories
{
    public interface IRepositories<TEntity, TId>
    {
        public TEntity Get(TId id);
        public IEnumerable<TEntity> Get();
        public void Delete(TId id);
        public void Update(TId id, TEntity entity);
        public TId Insert(TEntity entity);
    }
}
