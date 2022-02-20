using CinemaProject.BLL.Entities;
using CinemaProject.Common.Repositories;
using CinemaProject.MVC.Handlers;
using CinemaProject.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository<Movie> _movieRepository;

        public MovieController(IMovieRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult Details(int id)
        {
            if (TempData.ContainsKey("Id_CinemaPlace")) TempData.Keep();
            MovieDetails model = _movieRepository.Get(id).ToDetails();
            return View(model);
        }
    }
}
