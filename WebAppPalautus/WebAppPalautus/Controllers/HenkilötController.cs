﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPalautus.Models;

namespace WebAppPalautus.Controllers
{
    public class HenkilötController : Controller
    {
        // GET: Henkilöt
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                TilausDBEntities db = new TilausDBEntities();
                List<Henkilot> model = db.Henkilot.ToList();
                db.Dispose();
                return View(model);
            }
        }
    }
}