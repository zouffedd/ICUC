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
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Applicant).Include(s => s.FacultyDepartment).Include(s => s.ModeOfStudy).Include(s => s.Program);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ApplicantID", "FirstName");
            ViewBag.FacultyID= new SelectList(db.Faculties, "FacultyID", "FacultyName");

            ViewBag.FacultyDepartmentID = new SelectList(db.FacultyDepartments, "FacultyDepartmentID", "FacultyDepartmentName");
            ViewBag.PreferenceID = new SelectList(db.Preferences, "PreferenceId", "PreferenceId");
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,RegNo,FacultyID,FacultyDepartmentID,ProgramID,ApplicantID,PreferenceID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicantID = new SelectList(db.Applicants, "ApplicantID", "FirstName", student.ApplicantID);
            ViewBag.FacultyDepartmentID = new SelectList(db.FacultyDepartments, "FacultyDepartmentID", "FacultyDepartmentName", student.FacultyDepartmentID);
            ViewBag.PreferenceID = new SelectList(db.Preferences, "PreferenceId", "PreferenceId", student.PreferenceID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", student.ProgramID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ApplicantID", "FirstName", student.ApplicantID);
            ViewBag.FacultyDepartmentID = new SelectList(db.FacultyDepartments, "FacultyDepartmentID", "FacultyDepartmentName", student.FacultyDepartmentID);
            ViewBag.PreferenceID = new SelectList(db.Preferences, "PreferenceId", "PreferenceId", student.PreferenceID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", student.ProgramID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,RegNo,FacultyID,FacultyDepartmentID,ProgramID,ApplicantID,PreferenceID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ApplicantID", "FirstName", student.ApplicantID);
            ViewBag.FacultyDepartmentID = new SelectList(db.FacultyDepartments, "FacultyDepartmentID", "FacultyDepartmentName", student.FacultyDepartmentID);
            ViewBag.PreferenceID = new SelectList(db.Preferences, "PreferenceId", "PreferenceId", student.PreferenceID);
            ViewBag.ProgramID = new SelectList(db.Programs, "ProgramID", "ProgramName", student.ProgramID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
