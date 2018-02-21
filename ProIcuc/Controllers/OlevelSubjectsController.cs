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
    public class OlevelSubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OlevelSubjects
        public ActionResult Index()
        {
            var olevelSubjects = db.OlevelSubjects.Include(o => o.Applicant);
            return View(olevelSubjects.ToList());
        }

        // GET: OlevelSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OlevelSubject olevelSubject = db.OlevelSubjects.Find(id);
            if (olevelSubject == null)
            {
                return HttpNotFound();
            }
            return View(olevelSubject);
        }

        // GET: OlevelSubjects/Create
        public ActionResult Create()
        {
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ApplicantID", "ApplicantName");
            
            return View();
        }

        // POST: OlevelSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OlevelSubjectID,OlevelSubjectName,Grading,ApplicantID,OlevelDocsID")] OlevelSubject olevelSubject)
        {
            if (ModelState.IsValid)
            {
                db.OlevelSubjects.Add(olevelSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicantID = new SelectList(db.Applicants, "ApplicantID", "ApplicantName", olevelSubject.ApplicantID);
            
            return View(olevelSubject);
        }

        // GET: OlevelSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OlevelSubject olevelSubject = db.OlevelSubjects.Find(id);
            if (olevelSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ApplicantID", "ApplicantName", olevelSubject.ApplicantID);
            
            return View(olevelSubject);
        }

        // POST: OlevelSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OlevelSubjectID,OlevelSubjectName,Grading,ApplicantID,OlevelDocsID")] OlevelSubject olevelSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(olevelSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ApplicantID", "ApplicantName", olevelSubject.ApplicantID);
           
            return View(olevelSubject);
        }

        // GET: OlevelSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OlevelSubject olevelSubject = db.OlevelSubjects.Find(id);
            if (olevelSubject == null)
            {
                return HttpNotFound();
            }
            return View(olevelSubject);
        }

        // POST: OlevelSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OlevelSubject olevelSubject = db.OlevelSubjects.Find(id);
            db.OlevelSubjects.Remove(olevelSubject);
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
