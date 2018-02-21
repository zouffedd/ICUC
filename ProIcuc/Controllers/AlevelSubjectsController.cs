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
using System.Data.Entity.Infrastructure;

namespace ProIcuc.Controllers
{
    public class AlevelSubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AlevelSubjects
        public ActionResult Index()
        {
            var alevelSubjects = db.AlevelSubjects.Include(a => a.Applicant);
            return View(alevelSubjects.ToList());
        }

        // GET: AlevelSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlevelSubject alevelSubject = db.AlevelSubjects.Find(id);
            if (alevelSubject == null)
            {
                return HttpNotFound();
            }
            return View(alevelSubject);
        }

        // GET: AlevelSubjects/Create
        public ActionResult Create()
        {
            PopulateApplicantsDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlevelSubjectID,AlevelSubjectName,ApplicantName,ApplicantID,SubjectGrade,PaperGrade,PaperType,PaperNo,Score")] AlevelSubject alevelSubject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.AlevelSubjects.Add(alevelSubject);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateApplicantsDropDownList(alevelSubject.ApplicantID);
            return View(alevelSubject);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlevelSubject alevelSubject = db.AlevelSubjects.Find(id);
            if (alevelSubject == null)
            {
                return HttpNotFound();
            }
            PopulateApplicantsDropDownList(alevelSubject.ApplicantID);
            return View(alevelSubject);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var alevelSubjectToUpdate = db.AlevelSubjects.Find(id);
            if (TryUpdateModel(alevelSubjectToUpdate, "",
               new string[] { "AlevelSubjectName","SubjectGrade","PaperGrade","PaperType","PaperNo","Score","ApplicantID","Applicantname" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateApplicantsDropDownList(alevelSubjectToUpdate.ApplicantID);
            return View(alevelSubjectToUpdate);
        }

        private void PopulateApplicantsDropDownList(object selectedApplicant = null)
        {
            var applicantsQuery = from d in db.Applicants
                                   orderby d.FirstName
                                   select d;
            ViewBag.ApplicantID = new SelectList(applicantsQuery, "ApplicantID", "ApplicantName", selectedApplicant);
        }


        // GET: AlevelSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlevelSubject alevelSubject = db.AlevelSubjects.Find(id);
            if (alevelSubject == null)
            {
                return HttpNotFound();
            }
            return View(alevelSubject);
        }

        // POST: AlevelSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlevelSubject alevelSubject = db.AlevelSubjects.Find(id);
            db.AlevelSubjects.Remove(alevelSubject);
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
