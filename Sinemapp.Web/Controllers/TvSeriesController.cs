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

namespace Sinemapp.Web.Controllers
{
    public class TvSeriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TvSeries
        public ActionResult Index()
        {
            return View(db.TvSeries.ToList());
        }

    }
}
