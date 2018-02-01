using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using classicGarage.DAL;
using classicGarage.Models;

namespace classicGarage.Controllers
{
    public class AdController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Ad
        public ActionResult Index()
        {
            var ad = db.Advertisement.Include(a => a.Car);
            return View(ad.ToList());
        }
        public ActionResult CarView()
        {
            var ad = db.Advertisement.Include(a => a.Car);
            return View(ad.ToList());
        }

        // GET: Ad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdModels adModels = db.Advertisement.Find(id);
            if (adModels == null)
            {
                return HttpNotFound();
            }
            return View(adModels);
        }

        // GET: Ad/Create
        public ActionResult Create()
        {
            var x = db.Owner.Where(u => u.Email == User.Identity.Name);
            int z = 0;
            foreach (OwnerModels s in x)
            {
                z = s.ID;
            }
            ViewBag.CarID = new SelectList(db.Car.Where(u => u.OwnerID == z), "ID", "Brand");
            return View();
        }

        // POST: Ad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CarID,Active")] AdModels adModels)
        {
            if (ModelState.IsValid)
            {
                adModels.Mail = User.Identity.Name;
                db.Advertisement.Add(adModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Car, "ID", "Brand", adModels.CarID);
            return View(adModels);
        }

        // GET: Ad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdModels adModels = db.Advertisement.Find(id);
            if (adModels == null)
            {
                return HttpNotFound();
            }
            var x = db.Owner.Where(u => u.Email == User.Identity.Name);
            int z = 0;
            foreach (OwnerModels s in x)
            {
                z = s.ID;
            }
            ViewBag.CarID = new SelectList(db.Car.Where(u => u.OwnerID == z), "ID", "Brand");
            return View(adModels);
        }

        // POST: Ad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CarID,Active")] AdModels adModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adModels).State = EntityState.Modified;
                adModels.Mail = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Car, "ID", "Brand", adModels.CarID);
            return View(adModels);
        }

        // GET: Ad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdModels adModels = db.Advertisement.Find(id);
            if (adModels == null)
            {
                return HttpNotFound();
            }
            return View(adModels);
        }

        // POST: Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdModels adModels = db.Advertisement.Find(id);
            db.Advertisement.Remove(adModels);
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
    }
}
