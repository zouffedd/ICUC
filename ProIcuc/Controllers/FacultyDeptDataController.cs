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
using ProIcuc.ViewModels;

namespace ProIcuc.Controllers
{
    public class FacultyDeptDataController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FacultyDeptData
        public ActionResult Index(int? id, int? programID)
        {
            var viewModel = new FacultyDeptData();

            viewModel.FacultyDepartment = db.FacultyDepartments
                .Include(i => i.Faculty)
                .Include(i => i.Programs.Select(c => c.FacultyDepartment))
                .OrderBy(i => i.FacultyDepartmentID);

            if (id != null)
            {
                ViewBag.FacultyDepartment = id.Value;
                viewModel.Programs = viewModel.FacultyDepartment.Where(
                    i => i.FacultyDepartmentID == id.Value).Single().Programs;
            }

            if (programID != null)
            {
                ViewBag.CourseID = programID.Value;
                // Lazy loading
                viewModel.Courses = viewModel.Programs.Where(
                    x => x.ProgramID == programID).Single().Courses;
                // Explicit loading
                //var selectedProgram = viewModel.Programs.Where(x => x.ProgramID == programID).Single();
                //db.Entry(selectedProgram).Collection(x => x.Courses).Load();
                //foreach (Course course in selectedProgram.Courses)
                //{
                //    db.Entry(course).Reference(x => x.Course).Load();
                //}

                //viewModel.Courses = selectedProgram.Courses;

            }

            return View(viewModel);
        }

        // GET: FacultyDeptData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultyDepartment facultyDepartment = db.FacultyDepartments.Find(id);
            if (facultyDepartment == null)
            {
                return HttpNotFound();
            }
            return View(facultyDepartment);
        }

        // GET: FacultyDeptData/Create
        public ActionResult Create()
        {
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName");
            return View();
        }

        // POST: FacultyDeptData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacultyDepartmentID,FacultyDepartmentName,FacultyID,TotalCount,PageSize,PageNumber,PagerCount")] FacultyDepartment facultyDepartment)
        {
            if (ModelState.IsValid)
            {
                db.FacultyDepartments.Add(facultyDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", facultyDepartment.FacultyID);
            return View(facultyDepartment);
        }

        // GET: FacultyDeptData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultyDepartment facultyDepartment = db.FacultyDepartments.Find(id);
            if (facultyDepartment == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", facultyDepartment.FacultyID);
            return View(facultyDepartment);
        }

        // POST: FacultyDeptData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacultyDepartmentID,FacultyDepartmentName,FacultyID,TotalCount,PageSize,PageNumber,PagerCount")] FacultyDepartment facultyDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facultyDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", facultyDepartment.FacultyID);
            ViewBag.FacultyID = new SelectList(db.Programs, "ProgramID", "ProgramName", facultyDepartment.FacultyID);
            return View(facultyDepartment);
        }

        // GET: FacultyDeptData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultyDepartment facultyDepartment = db.FacultyDepartments.Find(id);
            if (facultyDepartment == null)
            {
                return HttpNotFound();
            }
            return View(facultyDepartment);
        }

        // POST: FacultyDeptData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacultyDepartment facultyDepartment = db.FacultyDepartments.Find(id);
            db.FacultyDepartments.Remove(facultyDepartment);
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
