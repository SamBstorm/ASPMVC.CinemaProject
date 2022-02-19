using CinemaProject.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.BLL.Handlers
{
    public static class Mapper
    {
        public static CinemaPlace ToBLL(this DAL.Entities.CinemaPlace entity)
        {
            if (entity is null) return null;
            return new CinemaPlace()
            {
                Id_CinemaPlace = entity.Id_CinemaPlace,
                Name = entity.Name,
                City = entity.City,
                Street = entity.Street,
                Number = entity.Number,
                ZipCode = entity.ZipCode
            };
        }
        public static DAL.Entities.CinemaPlace ToDAL(this CinemaPlace entity)
        {
            if (entity is null) return null;
            return new DAL.Entities.CinemaPlace()
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
