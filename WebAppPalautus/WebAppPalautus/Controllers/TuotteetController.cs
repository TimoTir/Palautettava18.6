using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPalautus.Models;

namespace WebAppPalautus.Controllers
{
    public class TuotteetController : Controller
    {
        TilausDBEntities db = new TilausDBEntities();
        // GET: Tuotteet
        public ActionResult Index()
        {
            return View();
        }

    }
}