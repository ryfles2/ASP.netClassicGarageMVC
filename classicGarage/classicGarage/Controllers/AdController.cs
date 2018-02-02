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
            if(id!=null)
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdModels adModels = db.Advertisement.Find(id);
            if (adModels == null)
            {
                return HttpNotFound();
            }
            var g = db.Advertisement.Where(d => d.ID == id);
            int search = 0;
            foreach (AdModels s in g)
            {
                search = s.CarID;
            }
            ViewBag.CarID = new SelectList(db.Car.Where(d => d.ID == search), "ID", "Brand");

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
        //************************************************************************CAR*****************************************
        //Car************************************************************
        public ActionResult CarView()
        {
            var ad = db.Advertisement.Include(a => a.Car);
            return View(ad.ToList());
        }
        public ActionResult CarDetailsOwner(int? id)
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
        //Car*********************************************************
        public ActionResult CarDetails(int? id)
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
        public ActionResult CarEdit(int? id)
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
            ViewBag.OwnerID = new SelectList(db.Owner.Where(u => u.Email == User.Identity.Name), "ID", "FirstName");
            return View(carModels);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CarEdit([Bind(Include = "ID,Brand,Model,Year,VIN,Name,PhotoAdress,DatePurchase,DateSale,PurchasePrice,SellingPrice,OwnerID")] CarModels carModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CarView");
            }
            ViewBag.OwnerID = new SelectList(db.Owner, "ID", "FirstName", carModels.OwnerID);
            return View(carModels);
        }
        public ActionResult CarCreate()
        {
            //ID przypisane z automatu do użytkownika który dodaje auto
            ViewBag.OwnerID = new SelectList(db.Owner.Where(u => u.Email == User.Identity.Name), "ID", "FirstName");
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CarCreate([Bind(Include = "Brand,Model,Year,VIN,Name,PhotoAdress,DatePurchase,DateSale,PurchasePrice,SellingPrice,OwnerID")] CarModels carModels)
        {
            if (ModelState.IsValid)
            {
                var ad = new AdModels();

                ad.CarID = carModels.ID;
                ad.Active = false;
                ad.Mail = User.Identity.Name;

                db.Advertisement.Add(ad);
                db.Car.Add(carModels);
                db.SaveChanges();

                return RedirectToAction("CarView");
            }

            ViewBag.OwnerID = new SelectList(db.Owner, "ID", "FirstName", carModels.OwnerID);
            return View(carModels);
        }
        public ActionResult CarDelete(int? id)
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
        [HttpPost, ActionName("CarDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CarDeleteConfirmed(int id)
        {
            CarModels carModels = db.Car.Find(id);

            var x = db.Advertisement.Where(u => u.CarID == carModels.ID);
            int z = 0;
            foreach (var s in x)
            {
                z = s.ID;
            }


            AdModels ad = db.Advertisement.Find(z);

            db.Advertisement.Remove(ad);

            db.Car.Remove(carModels);
            db.SaveChanges();
            return RedirectToAction("CarView");
        }
    }

}
