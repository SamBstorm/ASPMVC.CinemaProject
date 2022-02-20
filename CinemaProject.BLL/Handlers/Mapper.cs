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
        #region CinemaPlace
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
        #endregion
        #region Diffusion
        public static DiffusionCinema ToBLL(this IEnumerable<DAL.Entities.Diffusion> entities)
        {
            if (entities is null || !entities.Any()) return null;
            DiffusionCinema result = new DiffusionCinema() {
                Id_CinemaPlace = entities.First().CinemaRoom.Id_CinemaPlace,
                DiffusionDate = entities.First().DiffusionDate,
                Diffusions = entities.ToDiffusionMovie()
            };
            
            return result;
        }

        public static IEnumerable<DiffusionMovie> ToDiffusionMovie(this IEnumerable<DAL.Entities.Diffusion> entities)
        {
            if (entities is null || ! entities.Any()) return null;
            IEnumerable<DiffusionMovie> result =  entities.Select(m=>m.Movie).Distinct().ToArray().GroupJoin(entities,
                m => m.Id_Movie,
                d=> d.Id_Movie,
                (m, ds) =>new DiffusionMovie
                            {
                                DiffusionTimes = ds.Select(d=>d.ToDiffusionHour()),
                                Movie = m.ToBLL()
                            });
            result = result.Select(d=>
            {
                d.DiffusionTimes = d.DiffusionTimes.Select(dh =>
                {
                    dh.Diffusion = d;
                    return dh;
                });
                return d;
            });
            return result;
        }

        public static DiffusionMovie ToDiffusionMovie(this DAL.Entities.Diffusion entity)
        {
            if (entity is null) return null;
            return new DiffusionMovie
            {
                Movie = entity.Movie.ToBLL(),
                DiffusionTimes= new[] { entity.ToDiffusionHour() }
            };
        }

        public static DAL.Entities.Diffusion ToDAL(this DiffusionCinema entity)
        {
            if (entity is null) return null;
            if (entity.Diffusions.Count() > 1) throw new Exception("Too many values");
            if (!entity.Diffusions.Any()) throw new Exception("No values");
            return new DAL.Entities.Diffusion()
            {
                Id_Diffusion = entity.Diffusions.SingleOrDefault().DiffusionTimes.SingleOrDefault().Id_Diffusion,
                DiffusionDate = entity.DiffusionDate,
                DiffusionTime = entity.Diffusions.SingleOrDefault().DiffusionTimes.SingleOrDefault().DiffusionTime,
                AudLang = entity.Diffusions.SingleOrDefault().DiffusionTimes.SingleOrDefault().AudLang,
                SubTitleLang = entity.Diffusions.SingleOrDefault().DiffusionTimes.SingleOrDefault().SubTitleLang,
                Id_CinemaRoom = entity.Diffusions.SingleOrDefault().DiffusionTimes.SingleOrDefault().CinemaRoom.Id_CinemaRoom,
                Id_Movie = entity.Diffusions.SingleOrDefault().Movie.Id_Movie
            };
        }



        public static DiffusionCinema ToBLL(this DAL.Entities.Diffusion entity)
        {
            if (entity is null) return null;
            return new DiffusionCinema()
            {
                Id_CinemaPlace = entity.CinemaRoom.Id_CinemaPlace,
                DiffusionDate = entity.DiffusionDate,
                Diffusions = new[] { entity.ToDiffusionMovie() }
            };
        }

        public static DiffusionHour ToDiffusionHour(this DAL.Entities.Diffusion entity)
        {
            if (entity is null) return null;
            return new DiffusionHour()
            {
                SubTitleLang = entity.SubTitleLang,
                AudLang = entity.AudLang,
                DiffusionTime = entity.DiffusionTime,
                CinemaRoom = entity.CinemaRoom.ToBLL(),
                Diffusion = null
            };
        }

        #endregion
        #region CinemaRoom

        public static CinemaRoom ToBLL(this DAL.Entities.CinemaRoom entity)
        {
            if (entity is null) return null;
            return new CinemaRoom()
            {
                Id_CinemaRoom = entity.Id_CinemaRoom,
                Number = entity.Number,
                ScreenHeight = entity.ScreenHeight,
                ScreenWidth = entity.ScreenWidth,
                SitsCount = entity.SitsCount,
                Can3D = entity.Can3D,
                Can4DX = entity.Can4DX,
                CinemaPlace = null
            };
        }

        #endregion
        #region Movie
        public static Movie ToBLL(this DAL.Entities.Movie entity)
        {
            if (entity is null) return null;
            return new Movie()
            {
                Id_Movie = entity.Id_Movie,
                Title = entity.Title,
                SubTitle = entity.SubTitle,
                Duration = entity.Duration,
                PosterUrl = entity.PosterUrl,
                ReleaseYear = entity.ReleaseYear,
                Synopsis = entity.Synopsis
            };
        }
        public static DAL.Entities.Movie ToDAL(this Movie entity)
        {
            if (entity is null) return null;
            return new DAL.Entities.Movie()
            {
                Id_Movie = entity.Id_Movie,
                Title = entity.Title,
                SubTitle = entity.SubTitle,
                Duration = entity.Duration,
                PosterUrl = entity.PosterUrl,
                ReleaseYear = entity.ReleaseYear,
                Synopsis = entity.Synopsis
            };
        }
        #endregion
    }
}
