using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProIcuc.Models;
using ProIcuc.Models.Examination;

    namespace ProIcuc.Controllers
    {
    public class YearOfStudiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: YearOfStudies
        public ActionResult Index()
        {
            return View(db.YearOfStudies.ToList());
        }

        // GET: YearOfStudies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearOfStudy yearOfStudy = db.YearOfStudies.Find(id);
            if (yearOfStudy == null)
            {
                return HttpNotFound();
            }
            return View(yearOfStudy);
        }

        // GET: YearOfStudies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YearOfStudies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YearOfStudyID,StudyYear")] YearOfStudy yearOfStudy)
        {
            if (ModelState.IsValid)
            {
                db.YearOfStudies.Add(yearOfStudy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

                return View(yearOfStudy);
        }

        // GET: YearOfStudies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearOfStudy yearOfStudy = db.YearOfStudies.Find(id);
            if (yearOfStudy == null)
            {
                return HttpNotFound();
            }
            return View(yearOfStudy);
        }

        // POST: YearOfStudies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YearOfStudyID,StudyYear")] YearOfStudy yearOfStudy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearOfStudy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yearOfStudy);
        }

        // GET: YearOfStudies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearOfStudy yearOfStudy = db.YearOfStudies.Find(id);
            if (yearOfStudy == null)
            {
                return HttpNotFound();
            }
            return View(yearOfStudy);
        }

        // POST: YearOfStudies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearOfStudy yearOfStudy = db.YearOfStudies.Find(id);
            db.YearOfStudies.Remove(yearOfStudy);
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
