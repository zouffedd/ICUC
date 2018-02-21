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
    public class PreferencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Preferences
        public ActionResult Index()
        {
            var preferences = db.Preferences.Include(p => p.Applicant).Include(p => p.ModeOfStudy).Include(p => p.Program);
            return View(preferences.ToList());
        }

        // GET: Preferences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preference preference = db.Preferences.Find(id);
            if (preference == null)
            {
                return HttpNotFound();
            }
            return View(preference);
        }

        // GET: Preferences/Create
        public ActionResult Create()
        {
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ApplicantID", "FirstName");
            ViewBag.ModeOfStudyID = new SelectList(db.ModeOfStudies, "ModeOfStudyID", "ModeOfStudyName");
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName");
            return View();
        }

        // POST: Preferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PreferenceId,ApplicantID,Choice,ModeOfStudyID,ProgramID")] Preference preference)
        {
            if (ModelState.IsValid)
            {
                db.Preferences.Add(preference);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicantID = new SelectList(db.Applicants, "ApplicantID", "FirstName", preference.ApplicantID);
            ViewBag.ModeOfStudyID = new SelectList(db.ModeOfStudies, "ModeOfStudyID", "ModeOfStudyName", preference.ModeOfStudyID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", preference.ProgramID);
            return View(preference);
        }

        // GET: Preferences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preference preference = db.Preferences.Find(id);
            if (preference == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ApplicantID", "FirstName", preference.ApplicantID);
            ViewBag.ModeOfStudyID = new SelectList(db.ModeOfStudies, "ModeOfStudyID", "ModeOfStudyName", preference.ModeOfStudyID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", preference.ProgramID);
            return View(preference);
        }

        // POST: Preferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PreferenceId,ApplicantID,Choice,ModeOfStudyID,ProgramID")] Preference preference)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preference).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ApplicantID", "FirstName", preference.ApplicantID);
            ViewBag.ModeOfStudyID = new SelectList(db.ModeOfStudies, "ModeOfStudyID", "ModeOfStudyName", preference.ModeOfStudyID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", preference.ProgramID);
            return View(preference);
        }

        // GET: Preferences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preference preference = db.Preferences.Find(id);
            if (preference == null)
            {
                return HttpNotFound();
            }
            return View(preference);
        }

        // POST: Preferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Preference preference = db.Preferences.Find(id);
            db.Preferences.Remove(preference);
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
