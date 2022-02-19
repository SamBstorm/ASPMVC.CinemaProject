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
    public class CinemaController : Controller
    {
        private readonly ICinemaPlaceRepository<CinemaPlace> _repository;

        public CinemaController(ICinemaPlaceRepository<CinemaPlace> repository)
        {
            _repository = repository;
        }

        public CinemaController()
        {
        }

        public IActionResult Index()
        {
            IEnumerable<CinemaSelection> model = _repository.Get().Select(c => c.ToSelection());
            return View(model);
        }

        public IActionResult Diffusions(int id) {
            CinemaDetails model = new CinemaDetails();
            TempData["Id_CinemaPlace"] = model.Id_CinemaPlace;
            return View(model);
        }
    }
}
