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
    public class OwnerController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Owner
        public ActionResult Index()
        {
            return View(db.Owner.ToList());
        }

        // GET: Owner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerModels ownerModels = db.Owner.Find(id);
            if (ownerModels == null)
            {
                return HttpNotFound();
            }
            return View(ownerModels);
        }

        // GET: Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Phone,Email")] OwnerModels ownerModels)
        {
            if (ModelState.IsValid)
            {
                //ownerModels.Email = User.Identity.Name;
                db.Owner.Add(ownerModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ownerModels);
        }

        // GET: Owner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerModels ownerModels = db.Owner.Find(id);
            if (ownerModels == null)
            {
                return HttpNotFound();
            }
            return View(ownerModels);
        }

        // POST: Owner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Phone,Email")] OwnerModels ownerModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ownerModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ownerModels);
        }

        // GET: Owner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerModels ownerModels = db.Owner.Find(id);
            if (ownerModels == null)
            {
                return HttpNotFound();
            }
            return View(ownerModels);
        }

        // POST: Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OwnerModels ownerModels = db.Owner.Find(id);
            db.Owner.Remove(ownerModels);
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
