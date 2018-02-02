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
    public class PartController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Part
        public ActionResult Index()
        {
            var part = db.Part.Include(p => p.Car);
            return View(part.ToList());
        }

        // GET: Part/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartModels partModels = db.Part.Find(id);
            if (partModels == null)
            {
                return HttpNotFound();
            }
            return View(partModels);
        }

        // GET: Part/Create
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

        // POST: Part/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CarID,Name,CatNumber,PurchasePrice,SellingPrice,DatePurchase,DateSale")] PartModels partModels)
        {
            if (ModelState.IsValid)
            {
                partModels.Mail = User.Identity.Name;
                db.Part.Add(partModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Car, "ID", "Brand", partModels.CarID);
            return View(partModels);
        }

        // GET: Part/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartModels partModels = db.Part.Find(id);
            if (partModels == null)
            {
                return HttpNotFound();
            }
            /////////////////////////////////////////
            var x = db.Owner.Where(u => u.Email == User.Identity.Name);
            int z = 0;
            foreach (OwnerModels s in x)
            {
                z = s.ID;
            }
            ViewBag.CarID = new SelectList(db.Car.Where(u => u.OwnerID == z), "ID", "Brand");
            return View(partModels);
        }

        // POST: Part/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CarID,Name,CatNumber,PurchasePrice,SellingPrice,DatePurchase,DateSale")] PartModels partModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partModels).State = EntityState.Modified;
                partModels.Mail = User.Identity.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Car, "ID", "Brand", partModels.CarID);
            return View(partModels);
        }

        // GET: Part/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartModels partModels = db.Part.Find(id);
            if (partModels == null)
            {
                return HttpNotFound();
            }
            return View(partModels);
        }

        // POST: Part/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartModels partModels = db.Part.Find(id);
            db.Part.Remove(partModels);
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
