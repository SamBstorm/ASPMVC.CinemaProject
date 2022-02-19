using CinemaProject.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.MVC.Models
{
    public class SubDiffusionListItem
    {
        public int Id_Diffusion { get; set; }
        public int Id_Movie { get; set; }
        public int Number { get; set; }
        public TimeSpan DiffusionTime { get; set; }
        public DiffusionLanguage DiffusionLanguage { get; set; }
        public DiffusionType DiffusionType { get; set; }
    }
}
