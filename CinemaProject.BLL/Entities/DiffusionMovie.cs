using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.BLL.Entities
{
    public class DiffusionMovie
    {
        public Movie Movie { get; set; }
        public IEnumerable<DiffusionHour> DiffusionTimes { get; set;}
    }
}
