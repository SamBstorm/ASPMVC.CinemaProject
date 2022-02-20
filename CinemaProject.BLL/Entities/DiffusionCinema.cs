using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.BLL.Entities
{
    public class DiffusionCinema
    {
        public int Id_CinemaPlace { get; set; }
        public DateTime DiffusionDate { get; set; }
        public IEnumerable<DiffusionMovie> Diffusions {get;set;}
    }
}
