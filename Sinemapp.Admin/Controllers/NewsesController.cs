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
    public class NewsesController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly INewsService newsService;
        public NewsesController(INewsService newsService)
        {
            this.newsService = newsService;
        }
        // GET: Newses
        public ActionResult Index()
        {
            var news = Mapper.Map<IEnumerable<NewsViewModel>>(newsService.GetAll());
            return View(news);
        }

        // GET: Newses/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsViewModel news = Mapper.Map<NewsViewModel>(newsService.Get(id.Value));
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Newses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Newses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<News>(news);
                newsService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: Newses/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsViewModel news = Mapper.Map<NewsViewModel>(newsService.Get(id.Value));
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Newses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<News>(news);
                newsService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: Newses/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsViewModel news = Mapper.Map<NewsViewModel>(newsService.Get(id.Value));
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Newses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            newsService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
