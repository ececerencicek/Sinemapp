using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sinemapp.Data;
using Sinemapp.Model;
using AutoMapper;
using Sinemapp.Service;
using Sinemapp.Web.Models;

namespace Sinemapp.Web.Controllers
{
    public class FilmsController : Controller
    {
     //   private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IFilmService filmService;
        public FilmsController(IFilmService filmService)
        {
            this.filmService = filmService;
        }
        // GET: Films
        public ActionResult Index()
        {
            var films = Mapper.Map<IEnumerable<FilmViewModel>>(filmService.GetAll());
            return View(films);
        }
        /*
        
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Cinemas.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }       
        public ActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Rating,RunTime,ReleaseDate,Genre,Director,Writer,Country,Description,Photo,NumOfViewer,Revenue,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Film film)
        {
            if (ModelState.IsValid)
            {
                film.Id = Guid.NewGuid();
                db.Cinemas.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(film);
        }

        // GET: Films/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Cinemas.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Rating,RunTime,ReleaseDate,Genre,Director,Writer,Country,Description,Photo,NumOfViewer,Revenue,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(film);
        }

        // GET: Films/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Cinemas.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Film film = db.Cinemas.Find(id);
            db.Cinemas.Remove(film);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        */
    }
}
