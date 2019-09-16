using AutoMapper;
using Sinemapp.Data;
using Sinemapp.Service;
using Sinemapp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sinemapp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmService filmService;
        public HomeController(IFilmService filmService)
        {
            this.filmService = filmService;
        }

        public ActionResult Index()
        {
            var films = Mapper.Map<IEnumerable<FilmViewModel>>(filmService.GetAll());
            return View(films);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}