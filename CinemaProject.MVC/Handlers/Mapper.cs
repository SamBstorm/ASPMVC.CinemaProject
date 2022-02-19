using CinemaProject.BLL.Entities;
using CinemaProject.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.MVC.Handlers
{
    public static class Mapper
    {
        public static CinemaSelection ToSelection(this CinemaPlace entity) {
            if (entity is null) return null;
            return new CinemaSelection()
            {
                Id_CinemaPlace = entity.Id_CinemaPlace,
                Name = entity.Name,
                City = entity.City
            };
        }

        public static CinemaDetails ToDetails(this CinemaPlace entity)
        {
            if (entity is null) return null;
            return new CinemaDetails()
            {
                Id_CinemaPlace = entity.Id_CinemaPlace,
                Name = entity.Name,
                City = entity.City,
                Street = entity.Street,
                Number = entity.Number,
                ZipCode = entity.ZipCode
            };
        }
    }
}
