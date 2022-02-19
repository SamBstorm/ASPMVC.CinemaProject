using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.BLL.Entities
{
    public class Diffusion
    {
        public int Id_Diffusion { get; set; }
        public Movie Movie { get; set; }
        public IEnumerable<DiffusionHour> DiffusionTimes { get; set;}
    }
}
