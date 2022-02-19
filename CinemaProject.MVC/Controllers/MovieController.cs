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
        public IActionResult Details(int id)
        {
            if (TempData.ContainsKey("Id_CinemaPlace")) TempData.Keep();
            MovieDetails model = new MovieDetails();
            return View(model);
        }
    }
}
