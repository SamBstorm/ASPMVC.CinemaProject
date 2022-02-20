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
        #region CinemaPlace
        public static CinemaSelection ToSelection(this CinemaPlace entity)
        {
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
        #endregion
        #region Diffusion
        public static DiffusionDetails ToDetails(this DiffusionCinema entity)
        {
            if (entity is null) return null;
            return new DiffusionDetails()
            {
                Id_CinemaPlace = entity.Id_CinemaPlace,
                DiffusionDate = entity.DiffusionDate,
                Diffusions = entity.Diffusions.Select(d=>d.ToListItem())
            };
        }

        public static DiffusionListItem ToListItem(this DiffusionMovie entity)
        {
            if (entity is null) return null;
            return new DiffusionListItem()
            {
                Id_Movie = entity.Movie.Id_Movie,
                Title = entity.Movie.Title,
                SubTitle = entity.Movie.SubTitle,
                PosterUrl = entity.Movie.PosterUrl,
                Duration = entity.Movie.Duration,
                DiffusionTimes = entity.DiffusionTimes.Select(d=>d.ToSubListItem())
            };
        }

        public static SubDiffusionListItem ToSubListItem(this DiffusionHour entity)
        {
            if (entity is null) return null;
            return new SubDiffusionListItem()
            {
                Id_Movie = entity.Diffusion.Movie.Id_Movie,
                Number = entity.CinemaRoom.Number,
                DiffusionTime = entity.DiffusionTime,
                Id_Diffusion = entity.Id_Diffusion,
                DiffusionLanguage = entity.DiffLanguage,
                DiffusionType = entity.DiffType
            };
        }
        #endregion
        #region Movie
        public static MovieDetails ToDetails(this Movie entity) {
            if (entity is null) return null;
            return new MovieDetails()
            {
                Id_Movie = entity.Id_Movie,
                PosterUrl = entity.PosterUrl,
                Title = entity.Title,
                SubTitle = entity.SubTitle,
                ReleaseYear = entity.ReleaseYear,
                Synopsis = entity.Synopsis,
                Duration = entity.Duration
            };
        }
        #endregion
    }
}
