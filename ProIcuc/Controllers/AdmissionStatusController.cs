using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProIcuc.Models;
using ProIcuc.Models.Applications;

namespace ProIcuc.Controllers
{
    public class AdmissionStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdmissionStatus
        public ActionResult Index()
        {
            return View(db.AdmissionStatus.ToList());
        }

        // GET: AdmissionStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdmissionStatus admissionStatus = db.AdmissionStatus.Find(id);
            if (admissionStatus == null)
            {
                return HttpNotFound();
            }
            return View(admissionStatus);
        }

        // GET: AdmissionStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdmissionStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdmissionStatusID,AdminStatusName")] AdmissionStatus admissionStatus)
        {
            if (ModelState.IsValid)
            {
                db.AdmissionStatus.Add(admissionStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admissionStatus);
        }

        // GET: AdmissionStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdmissionStatus admissionStatus = db.AdmissionStatus.Find(id);
            if (admissionStatus == null)
            {
                return HttpNotFound();
            }
            return View(admissionStatus);
        }

        // POST: AdmissionStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdmissionStatusID,AdminStatusName")] AdmissionStatus admissionStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admissionStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admissionStatus);
        }

        // GET: AdmissionStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdmissionStatus admissionStatus = db.AdmissionStatus.Find(id);
            if (admissionStatus == null)
            {
                return HttpNotFound();
            }
            return View(admissionStatus);
        }

        // POST: AdmissionStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdmissionStatus admissionStatus = db.AdmissionStatus.Find(id);
            db.AdmissionStatus.Remove(admissionStatus);
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
