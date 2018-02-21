using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProIcuc.Models;
using ProIcuc.Models.HumanResource;

namespace ProIcuc.Controllers
{
    public class SalaryScalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SalaryScales
        public ActionResult Index()
        {
            return View(db.SalaryScales.ToList());
        }

        // GET: SalaryScales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryScale salaryScale = db.SalaryScales.Find(id);
            if (salaryScale == null)
            {
                return HttpNotFound();
            }
            return View(salaryScale);
        }

        // GET: SalaryScales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalaryScales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalaryScaleID,SalaryScaleName,SalaryAmount")] SalaryScale salaryScale)
        {
            if (ModelState.IsValid)
            {
                db.SalaryScales.Add(salaryScale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salaryScale);
        }

        // GET: SalaryScales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryScale salaryScale = db.SalaryScales.Find(id);
            if (salaryScale == null)
            {
                return HttpNotFound();
            }
            return View(salaryScale);
        }

        // POST: SalaryScales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalaryScaleID,SalaryScaleName,SalaryAmount")] SalaryScale salaryScale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salaryScale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salaryScale);
        }

        // GET: SalaryScales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryScale salaryScale = db.SalaryScales.Find(id);
            if (salaryScale == null)
            {
                return HttpNotFound();
            }
            return View(salaryScale);
        }

        // POST: SalaryScales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalaryScale salaryScale = db.SalaryScales.Find(id);
            db.SalaryScales.Remove(salaryScale);
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
