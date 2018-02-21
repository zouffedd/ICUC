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
    public class ResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Results
        public ActionResult Index()
        {
            var results = db.Results.Include(r => r.AcademicYear).Include(r => r.Comment).Include(r => r.Semester).Include(r => r.YearOfStudy);
            return View(results.ToList());
        }

        // GET: Results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: Results/Create
        public ActionResult Create()
        {
            ViewBag.AcademicYearID = new SelectList(db.AcademicYears, "AcademicYearID", "AcademicYearName");
            ViewBag.CommentID = new SelectList(db.Comments, "CommentID", "CommentName");
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "Sem");
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "YearOfStudyID", "StudyYear");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResultID,RegNo,CreditUnits,CommentID,AcademicYearID,SemesterID,YearOfStudyID,CourseWorkMark,TestMark,ExamMark")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Results.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicYearID = new SelectList(db.AcademicYears, "AcademicYearID", "AcademicYearName", result.AcademicYearID);
            ViewBag.CommentID = new SelectList(db.Comments, "CommentID", "CommentName", result.CommentID);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "Sem", result.SemesterID);
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "YearOfStudyID", "StudyYear", result.YearOfStudyID);
            return View(result);
        }

        // GET: Results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicYearID = new SelectList(db.AcademicYears, "AcademicYearID", "AcademicYearName", result.AcademicYearID);
            ViewBag.CommentID = new SelectList(db.Comments, "CommentID", "CommentName", result.CommentID);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "Sem", result.SemesterID);
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "YearOfStudyID", "StudyYear", result.YearOfStudyID);
            return View(result);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResultID,RegNo,CreditUnits,CommentID,AcademicYearID,SemesterID,YearOfStudyID,CourseWorkMark,TestMark,ExamMark")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicYearID = new SelectList(db.AcademicYears, "AcademicYearID", "AcademicYearName", result.AcademicYearID);
            ViewBag.CommentID = new SelectList(db.Comments, "CommentID", "CommentName", result.CommentID);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "Sem", result.SemesterID);
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "YearOfStudyID", "StudyYear", result.YearOfStudyID);
            return View(result);
        }

        // GET: Results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Result result = db.Results.Find(id);
            db.Results.Remove(result);
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
