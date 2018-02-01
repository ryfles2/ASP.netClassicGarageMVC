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
    public class RepairController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Repair
        public ActionResult Index()
        {
            var repair = db.Repair.Include(r => r.Car);
            return View(repair.ToList());
        }

        // GET: Repair/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairModels repairModels = db.Repair.Find(id);
            if (repairModels == null)
            {
                return HttpNotFound();
            }
            return View(repairModels);
        }

        // GET: Repair/Create
        public ActionResult Create()
        {
            ViewBag.CarID = new SelectList(db.Car, "ID", "Brand");
            return View();
        }

        // POST: Repair/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CarID,Name,Desciption,RepairCost")] RepairModels repairModels)
        {
            if (ModelState.IsValid)
            {
                repairModels.Mail = User.Identity.Name; 
                db.Repair.Add(repairModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Car, "ID", "Brand", repairModels.CarID);
            return View(repairModels);
        }

        // GET: Repair/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairModels repairModels = db.Repair.Find(id);
            if (repairModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.Car, "ID", "Brand", repairModels.CarID);
            return View(repairModels);
        }

        // POST: Repair/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CarID,Name,Desciption,RepairCost")] RepairModels repairModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.Car, "ID", "Brand", repairModels.CarID);
            return View(repairModels);
        }

        // GET: Repair/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairModels repairModels = db.Repair.Find(id);
            if (repairModels == null)
            {
                return HttpNotFound();
            }
            return View(repairModels);
        }

        // POST: Repair/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairModels repairModels = db.Repair.Find(id);
            db.Repair.Remove(repairModels);
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
