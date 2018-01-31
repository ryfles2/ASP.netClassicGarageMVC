﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using classicGarage.DAL;
using classicGarage.Models;
using Microsoft.AspNet.Identity;

namespace classicGarage.Controllers
{
    public class CarController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Car
        public ActionResult Index()
        {
            var car = db.Car.Include(c => c.owner);
            return View(car.ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            return View(carModels);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            ViewBag.OwnerID = new SelectList(db.Owner, "ID", "FirstName");
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Brand,Model,Year,VIN,Name,PhotoAdress,DatePurchase,DateSale,PurchasePrice,SellingPrice,OwnerID")] CarModels carModels)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Car.Add(carModels);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.OwnerID = new SelectList(db.Owner, "ID", "FirstName", carModels.OwnerID);
        //    return View(carModels);
        //}
        public ActionResult Create([Bind(Include = "Brand,Model,Year,VIN,Name,PhotoAdress,DatePurchase,DateSale,PurchasePrice,SellingPrice,OwnerID")] CarModels carModels)
        {
            if (Session["Owner"] != null)
            {
                //var owner = new OwnerModels();
                OwnerModels p1 = (OwnerModels)Session["Owner"];
                carModels.OwnerID = p1.ID;
                carModels.Name = p1.FirstName;
            }

            if (ModelState.IsValid)
            {

                db.Car.Add(carModels);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.OwnerID = new SelectList(db.Owner, "ID", "FirstName", carModels.OwnerID);
            return View(carModels);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerID = new SelectList(db.Owner, "ID", "FirstName", carModels.OwnerID);
            return View(carModels);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Brand,Model,Year,VIN,Name,PhotoAdress,DatePurchase,DateSale,PurchasePrice,SellingPrice,OwnerID")] CarModels carModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerID = new SelectList(db.Owner, "ID", "FirstName", carModels.OwnerID);
            return View(carModels);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModels carModels = db.Car.Find(id);
            if (carModels == null)
            {
                return HttpNotFound();
            }
            return View(carModels);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarModels carModels = db.Car.Find(id);
            db.Car.Remove(carModels);
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