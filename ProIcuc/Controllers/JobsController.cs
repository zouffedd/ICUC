﻿using System;
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
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.AllowanceScale).Include(j => j.SalaryScale);
            return View(jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.AllowanceGradeID = new SelectList(db.AllowanceScales, "AllowanceScaleID", "AllowanceScaleCode");
            ViewBag.SalaryScaleID = new SelectList(db.SalaryScales, "SalaryScaleID", "SalaryScaleName");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobID,JobName,JobDescription,JobAcademicRequirements,RequirementDescription,AllowanceGradeID,SalaryScaleID")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllowanceGradeID = new SelectList(db.AllowanceScales, "AllowanceScaleID", "AllowanceScaleCode", job.AllowanceGradeID);
            ViewBag.SalaryScaleID = new SelectList(db.SalaryScales, "SalaryScaleID", "SalaryScaleName", job.SalaryScaleID);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.AllowanceGradeID = new SelectList(db.AllowanceScales, "AllowanceScaleID", "AllowanceScaleCode", job.AllowanceGradeID);
            ViewBag.SalaryScaleID = new SelectList(db.SalaryScales, "SalaryScaleID", "SalaryScaleName", job.SalaryScaleID);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobID,JobName,JobDescription,JobAcademicRequirements,RequirementDescription,AllowanceGradeID,SalaryScaleID")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllowanceGradeID = new SelectList(db.AllowanceScales, "AllowanceScaleID", "AllowanceScaleCode", job.AllowanceGradeID);
            ViewBag.SalaryScaleID = new SelectList(db.SalaryScales, "SalaryScaleID", "SalaryScaleName", job.SalaryScaleID);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
