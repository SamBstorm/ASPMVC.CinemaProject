using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.MVC.Models
{
    public class MovieDetails
    {
        public int Id_Movie { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Synopsis { get; set; }
        public string PosterUrl { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
    }
}
