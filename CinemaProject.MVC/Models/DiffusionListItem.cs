using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.MVC.Models
{
    public class DiffusionListItem
    {
        public int Id_Diffusion { get; set; }
        public int Id_Movie { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string PosterUrl { get; set; }
        public int Duration { get; set; }
        public IEnumerable<SubDiffusionListItem> DiffusionTimes { get; set; }
    }
}
