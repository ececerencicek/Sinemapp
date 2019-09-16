using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    public class FilmsController : Controller
    {
        // private ApplicationDbContext db = new ApplicationDbContext();
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

        // GET: Films/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmViewModel film = Mapper.Map<FilmViewModel>(filmService.Get(id.Value));
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Film>(film);
                filmService.Insert(entity);
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
            FilmViewModel film = Mapper.Map<FilmViewModel>(filmService.Get(id.Value));
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
        public ActionResult Edit(Film film)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Film>(film);
                filmService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(film);
        }
        [HttpPost]
        public string UploadFile(HttpPostedFileBase upload)
        {
            // yüklenmek istenen dosya var mı?
            if (upload != null && upload.ContentLength > 0)
            {
                // dosyanın uzantısını kontrol et
                var extension = Path.GetExtension(upload.FileName).ToLower();
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".png" )
                {
                    // uzantı doğruysa dosyanın yükleneceği Uploads dizini var mı kontrol et
                    if (Directory.Exists(Server.MapPath("~/Uploads")))
                    {
                        // dosya adındaki geçersiz karakterleri düzelt
                        string fileName = upload.FileName.ToLower();
                        fileName = fileName.Replace("İ", "i");
                        fileName = fileName.Replace("Ş", "s");
                        fileName = fileName.Replace("Ğ", "g");
                        fileName = fileName.Replace("ğ", "g");
                        fileName = fileName.Replace("ı", "i");
                        fileName = fileName.Replace("(", "");
                        fileName = fileName.Replace(")", "");
                        fileName = fileName.Replace(" ", "-");
                        fileName = fileName.Replace(",", "");
                        fileName = fileName.Replace("ö", "o");
                        fileName = fileName.Replace("ü", "u");
                        fileName = fileName.Replace("`", "");
                        // aynı isimde dosya olabilir diye dosya adının önüne zaman pulu ekliyoruz
                        fileName = DateTime.Now.Ticks.ToString() + fileName;

                        // dosyayı Uploads dizinine yükle
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Uploads"), fileName));

                        // yüklenen dosyanın adını geri döndür
                        return fileName;
                    }
                    else
                    {
                        throw new Exception("Uploads dizini mevcut değil.");
                    }
                }
                else
                {
                    throw new Exception("Dosya uzantısı geçerli değil.");
                }
            }
            return null;
        }

        // GET: Films/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmViewModel film = Mapper.Map<FilmViewModel>(filmService.Get(id.Value));
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
            filmService.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
