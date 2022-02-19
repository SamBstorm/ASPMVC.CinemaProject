using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.MVC.Models
{
    public class DiffusionDetails
    {
        public int Id_CinemaPlace { get; set; }
        public DateTime DiffusionDate { get; set; }
        public IEnumerable<DiffusionListItem> Diffusions { get; set; }
    }
}
