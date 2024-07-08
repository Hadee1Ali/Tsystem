using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tsystem.Models;

namespace Tsystem.Controllers
{
    public class CourseSchedulesController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: CourseSchedules
        public ActionResult Index()
        {
            var courseSchedules = db.CourseSchedules.Include(c => c.CertificateTemplate).Include(c => c.CourseClassification);
            return View(courseSchedules.ToList());
        }

        // GET: CourseSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseSchedule courseSchedule = db.CourseSchedules.Find(id);
            if (courseSchedule == null)
            {
                return HttpNotFound();
            }
            return View(courseSchedule);
        }

        // GET: CourseSchedules/Create
        public ActionResult Create()
        {
            ViewBag.Certificate_ID = new SelectList(db.CertificateTemplates, "Certificate_ID", "Certificate_Template");
            ViewBag.Classification_ID = new SelectList(db.CourseClassifications, "Classification_ID", "Classification_Name");
            return View();
        }

        // POST: CourseSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Course_ID,Course_Title,Description,Language,Date,Start_Time,End_Time,Course_Status,Seats_Number,Course_Place,user_Type,Classification_ID,Course_Type,Certificate_ID,Trainer_Name")] CourseSchedule courseSchedule)
        {
            if (ModelState.IsValid)
            {
                db.CourseSchedules.Add(courseSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Certificate_ID = new SelectList(db.CertificateTemplates, "Certificate_ID", "Certificate_Template", courseSchedule.Certificate_ID);
            ViewBag.Classification_ID = new SelectList(db.CourseClassifications, "Classification_ID", "Classification_Name", courseSchedule.Classification_ID);
            return View(courseSchedule);
        }

        // GET: CourseSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseSchedule courseSchedule = db.CourseSchedules.Find(id);
            if (courseSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.Certificate_ID = new SelectList(db.CertificateTemplates, "Certificate_ID", "Certificate_Template", courseSchedule.Certificate_ID);
            ViewBag.Classification_ID = new SelectList(db.CourseClassifications, "Classification_ID", "Classification_Name", courseSchedule.Classification_ID);
            return View(courseSchedule);
        }

        // POST: CourseSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Course_ID,Course_Title,Description,Language,Date,Start_Time,End_Time,Course_Status,Seats_Number,Course_Place,user_Type,Classification_ID,Course_Type,Certificate_ID,Trainer_Name")] CourseSchedule courseSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Certificate_ID = new SelectList(db.CertificateTemplates, "Certificate_ID", "Certificate_Template", courseSchedule.Certificate_ID);
            ViewBag.Classification_ID = new SelectList(db.CourseClassifications, "Classification_ID", "Classification_Name", courseSchedule.Classification_ID);
            return View(courseSchedule);
        }

        // GET: CourseSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseSchedule courseSchedule = db.CourseSchedules.Find(id);
            if (courseSchedule == null)
            {
                return HttpNotFound();
            }
            return View(courseSchedule);
        }

        // POST: CourseSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseSchedule courseSchedule = db.CourseSchedules.Find(id);
            db.CourseSchedules.Remove(courseSchedule);
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
