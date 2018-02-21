using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProIcuc.Models;
using ProIcuc.Models.Academics;

namespace ProIcuc.Controllers
{
    public class ProgCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProgCourses
        public ActionResult Index()
        {
            var progCourses = db.ProgCourses.Include(p => p.AcademicYear).Include(p => p.Course).Include(p => p.Program).Include(p => p.Semester).Include(p => p.YearOfStudy);
            return View(progCourses.ToList());
        }

        // GET: ProgCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgCourse progCourse = db.ProgCourses.Find(id);
            if (progCourse == null)
            {
                return HttpNotFound();
            }
            return View(progCourse);
        }

        // GET: ProgCourses/Create
        public ActionResult Create()
        {
            ViewBag.AcademicYearID = new SelectList(db.AcademicYears, "AcademicYearID", "AcademicYearName");
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName");
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "Sem");
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "YearOfStudyID", "StudyYear");
            return View();
        }

        // POST: ProgCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgCourseID,ProgramID,CourseID,AcademicYearID,SemesterID,YearOfStudyID")] ProgCourse progCourse)
        {
            if (ModelState.IsValid)
            {
                db.ProgCourses.Add(progCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicYearID = new SelectList(db.AcademicYears, "AcademicYearID", "AcademicYearName", progCourse.AcademicYearID);
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", progCourse.CourseID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", progCourse.ProgramID);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "Sem", progCourse.SemesterID);
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "YearOfStudyID", "StudyYear", progCourse.YearOfStudyID);
            return View(progCourse);
        }

        // GET: ProgCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgCourse progCourse = db.ProgCourses.Find(id);
            if (progCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicYearID = new SelectList(db.AcademicYears, "AcademicYearID", "AcademicYearName", progCourse.AcademicYearID);
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", progCourse.CourseID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", progCourse.ProgramID);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "Sem", progCourse.SemesterID);
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "YearOfStudyID", "StudyYear", progCourse.YearOfStudyID);
            return View(progCourse);
        }

        // POST: ProgCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgCourseID,ProgramID,CourseID,AcademicYearID,SemesterID,YearOfStudyID")] ProgCourse progCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(progCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicYearID = new SelectList(db.AcademicYears, "AcademicYearID", "AcademicYearName", progCourse.AcademicYearID);
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", progCourse.CourseID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", progCourse.ProgramID);
            ViewBag.SemesterID = new SelectList(db.Semesters, "SemesterID", "Sem", progCourse.SemesterID);
            ViewBag.YearOfStudyID = new SelectList(db.YearOfStudies, "YearOfStudyID", "StudyYear", progCourse.YearOfStudyID);
            return View(progCourse);
        }

        // GET: ProgCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgCourse progCourse = db.ProgCourses.Find(id);
            if (progCourse == null)
            {
                return HttpNotFound();
            }
            return View(progCourse);
        }

        // POST: ProgCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgCourse progCourse = db.ProgCourses.Find(id);
            db.ProgCourses.Remove(progCourse);
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
