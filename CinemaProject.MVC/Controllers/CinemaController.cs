using CinemaProject.BLL.Entities;
using CinemaProject.BLL.Repositories;
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
        private readonly ICinemaPlaceRepository<CinemaPlace> _cinemaRepository;
        private readonly IDiffusionRepository _diffusionRepository;

        public CinemaController(ICinemaPlaceRepository<CinemaPlace> cinemaRepository, IDiffusionRepository diffusionRepository)
        {
            _cinemaRepository = cinemaRepository;
            _diffusionRepository = diffusionRepository;
        }

        public IActionResult Index()
        {
            if (TempData.ContainsKey("Id_CinemaPlace")) TempData.Remove("Id_CinemaPlace");
            IEnumerable<CinemaSelection> model = _cinemaRepository.Get().Select(c => c.ToSelection());
            return View(model);
        }

        public IActionResult Diffusions(int id) {
            CinemaDetails model = _cinemaRepository.Get(id).ToDetails();
            model.Diffusion = _diffusionRepository.GetByCinemaAtDate(id,new DateTime(2022,2,16)).ToDetails();
            TempData["Id_CinemaPlace"] = model.Id_CinemaPlace;
            return View(model);
        }
    }
}
