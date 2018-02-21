using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProIcuc.Models;

namespace ProIcuc.Controllers
{
    public class AllowanceScalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AllowanceScales
        public ActionResult Index()
        {
            return View(db.AllowanceScales.ToList());
        }

        // GET: AllowanceScales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllowanceScale allowanceScale = db.AllowanceScales.Find(id);
            if (allowanceScale == null)
            {
                return HttpNotFound();
            }
            return View(allowanceScale);
        }

        // GET: AllowanceScales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllowanceScales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AllowanceScaleID,AllowanceScaleCode,HousingAllowance,PerDM,FuelAllowance,Airtime")] AllowanceScale allowanceScale)
        {
            if (ModelState.IsValid)
            {
                db.AllowanceScales.Add(allowanceScale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allowanceScale);
        }

        // GET: AllowanceScales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllowanceScale allowanceScale = db.AllowanceScales.Find(id);
            if (allowanceScale == null)
            {
                return HttpNotFound();
            }
            return View(allowanceScale);
        }

        // POST: AllowanceScales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AllowanceScaleID,AllowanceScaleCode,HousingAllowance,PerDM,FuelAllowance,Airtime")] AllowanceScale allowanceScale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allowanceScale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allowanceScale);
        }

        // GET: AllowanceScales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllowanceScale allowanceScale = db.AllowanceScales.Find(id);
            if (allowanceScale == null)
            {
                return HttpNotFound();
            }
            return View(allowanceScale);
        }

        // POST: AllowanceScales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllowanceScale allowanceScale = db.AllowanceScales.Find(id);
            db.AllowanceScales.Remove(allowanceScale);
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
