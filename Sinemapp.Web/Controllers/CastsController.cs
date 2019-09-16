using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sinemapp.Model;
using Sinemapp.Web.Models;

namespace Sinemapp.Web.Controllers
{
    public class CastsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Casts
        public ActionResult Index()
        {
            var casts = db.Casts.Include(c => c.Film).Include(c => c.TvSerie);
            return View(casts.ToList());
        }

       
    }
}
