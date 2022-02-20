﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.BLL.Entities
{
    public class CinemaPlace
    {
        public int Id_CinemaPlace { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int ZipCode { get; set; }
        public IEnumerable<CinemaRoom> Rooms {get;set;}
        public IEnumerable<DiffusionMovie> Diffusions {get;set; }
    }
}
