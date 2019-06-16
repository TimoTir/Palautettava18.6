using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppPalautus.Models;

namespace WebAppPalautus.Controllers
{
    public class AsiakkaatController : Controller
    {
        TilausDBEntities db = new TilausDBEntities();
        // GET: Asiakkaat
        public ActionResult Index()
        {

            //List<Asiakkaat> model = db.Asiakkaat.ToList();
            //db.Dispose();
            //return View(model);
            var asiakkaat = db.Asiakkaat.Include(s => s.Postinumero);
            return View(asiakkaat.ToList());


        }
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Asiakkaat asiakkaat = db.Asiakkaat.Find(id);
            if (asiakkaat == null) return HttpNotFound();
            ViewBag.Postitoimipaikka = new SelectList(db.Postinumero, "Postinumero", "RegionDescription");
            List<Asiakkaat> model = db.Asiakkaat.ToList();
            return View(asiakkaat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //Katso https://go.microsoft.com/fwlink/?LinkId=317598

        public ActionResult Edit([Bind(Include = "AsiakasID,Nimi,Osoite,Postinumero")] Asiakkaat asiakkaat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiakkaat).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Postitoimipaikka = new SelectList(db.Postinumero, "Postinumero", "RegionDescription");
                return RedirectToAction("Index");
            }
            return View(asiakkaat);
        }

        public ActionResult Create()
        {
            ViewBag.Postitoimipaikka = new SelectList(db.Postinumero, "Postinumero", "RegionDescription");
            return View();


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsiakasID,Nimi,Osoite,Postinumero")] Asiakkaat asiakkaat)
        {
            if (ModelState.IsValid)
            {
                db.Asiakkaat.Add(asiakkaat);
                db.SaveChanges();
                ViewBag.Postinumero = new SelectList(db.Postinumero, "Postinumero", "RegionDescription");
                return RedirectToAction("Index");
            }
            return View(asiakkaat);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Asiakkaat asiakkaat = db.Asiakkaat.Find(id);
            if (asiakkaat == null) return HttpNotFound();
            return View(asiakkaat);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asiakkaat asiakkaat = db.Asiakkaat.Find(id);
            db.Asiakkaat.Remove(asiakkaat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
