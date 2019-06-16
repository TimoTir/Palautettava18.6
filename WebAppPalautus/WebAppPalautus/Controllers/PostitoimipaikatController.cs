using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPalautus.Models;

namespace WebAppPalautus.Controllers
{
    public class PostitoimipaikatController : Controller
    {
        // GET: Postitoimipaikat
        public ActionResult Index()
        {
            return View();
        }
    }
}