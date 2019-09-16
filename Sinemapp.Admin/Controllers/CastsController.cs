using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Sinemapp.Admin.Models;
using Sinemapp.Data;
using Sinemapp.Model;
using Sinemapp.Service;

namespace Sinemapp.Admin.Controllers
{
    public class CastsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly ICastService castService;
        private readonly IFilmService filmService;
        private readonly ITvSerieService tvSerieService;
        public CastsController(ICastService castService , IFilmService filmService , ITvSerieService tvSerieService)
        {
            this.castService = castService;
            this.filmService = filmService;
            this.tvSerieService = tvSerieService;
        }
        // GET: Casts
        public ActionResult Index()
        {
            var casts = Mapper.Map<IEnumerable<CastViewModel>>(castService.GetAll());
            return View(casts);
        }

        // GET: Casts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastViewModel cast = Mapper.Map<CastViewModel>(castService.Get(id.Value));
            if (cast == null)
            {
                return HttpNotFound();
            }
            return View(cast);
        }

        // GET: Casts/Create
        public ActionResult Create()
        {
            ViewBag.FilmId = new SelectList(filmService.GetAll(), "Id", "Name");
            ViewBag.TvSerieId = new SelectList(tvSerieService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Casts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cast cast)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Cast>(cast);
                castService.Insert(entity);
                return RedirectToAction("Index");
            }
            ViewBag.FilmId = new SelectList(filmService.GetAll(), "Id", "Name", cast.FilmId);
            ViewBag.TvSerieId = new SelectList(tvSerieService.GetAll(), "Id", "Name", cast.TvSerieId);
            return View(cast);
        }

        // GET: Casts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastViewModel cast = Mapper.Map<CastViewModel>(castService.Get(id.Value));
            if (cast == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmId = new SelectList(filmService.GetAll(), "Id", "Name", cast.FilmId);
            ViewBag.TvSerieId = new SelectList(tvSerieService.GetAll(), "Id", "Name", cast.TvSerieId);
            return View(cast);
        }

        // POST: Casts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cast cast)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Cast>(cast);
                castService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.FilmId = new SelectList(filmService.GetAll(), "Id", "Name", cast.FilmId);
            ViewBag.TvSerieId = new SelectList(tvSerieService.GetAll(), "Id", "Name", cast.TvSerieId);
            return View(cast);
        }

        // GET: Casts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastViewModel cast = Mapper.Map<CastViewModel>(castService.Get(id.Value));
            if (cast == null)
            {
                return HttpNotFound();
            }
            return View(cast);
        }

        // POST: Casts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            castService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
