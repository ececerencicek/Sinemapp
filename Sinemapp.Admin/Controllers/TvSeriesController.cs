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
    public class TvSeriesController : Controller
    {
        // private ApplicationDbContext db = new ApplicationDbContext();
        private readonly ITvSerieService tvSerieService;
        public TvSeriesController(ITvSerieService tvSerieService)
        {
            this.tvSerieService = tvSerieService;
        }
        // GET: TvSeries
        public ActionResult Index()
        {
            var tvSeries = Mapper.Map<IEnumerable<TvSerieViewModel>>(tvSerieService.GetAll());
            return View(tvSeries);
        }

        // GET: TvSeries/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TvSerieViewModel tvSerie = Mapper.Map<TvSerieViewModel>(tvSerieService.Get(id.Value));
            if (tvSerie == null)
            {
                return HttpNotFound();
            }
            return View(tvSerie);
        }

        // GET: TvSeries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TvSeries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TvSerie tvSerie)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<TvSerie>(tvSerie);
                tvSerieService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(tvSerie);
        }

        // GET: TvSeries/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TvSerieViewModel tvSerie = Mapper.Map<TvSerieViewModel>(tvSerieService.Get(id.Value));
            if (tvSerie == null)
            {
                return HttpNotFound();
            }
            return View(tvSerie);
        }

        // POST: TvSeries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TvSerie tvSerie)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<TvSerie>(tvSerie);
                tvSerieService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(tvSerie);
        }

        // GET: TvSeries/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TvSerieViewModel tvSerie = Mapper.Map<TvSerieViewModel>(tvSerieService.Get(id.Value));
            if (tvSerie == null)
            {
                return HttpNotFound();
            }
            return View(tvSerie);
        }

        // POST: TvSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tvSerieService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
