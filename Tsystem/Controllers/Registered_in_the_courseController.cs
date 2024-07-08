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
    public class Registered_in_the_courseController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Registered_in_the_course
        public ActionResult Index(string searchName, string searchCourse)
        {
            var registered_in_the_courses = db.Registered_in_the_courses.Include(r => r.CourseSchedule).Include(r => r.User);

            if (!String.IsNullOrEmpty(searchName))
            {
                registered_in_the_courses = registered_in_the_courses.Where(s => s.User.Ar_Name.Contains(searchName));
            }

            if (!String.IsNullOrEmpty(searchCourse))
            {
                registered_in_the_courses = registered_in_the_courses.Where(x => x.CourseSchedule.Course_Title.Contains(searchCourse));
            }

            ViewBag.SearchName = searchName;
            ViewBag.SearchCourse = searchCourse;

            return View(registered_in_the_courses.ToList());
        }

        // GET: Registered_in_the_course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registered_in_the_course registered_in_the_course = db.Registered_in_the_courses.Find(id);
            if (registered_in_the_course == null)
            {
                return HttpNotFound();
            }
            return View(registered_in_the_course);
        }

        // GET: Registered_in_the_course/Create
        public ActionResult Create()
        {
            ViewBag.Course_ID = new SelectList(db.CourseSchedules, "Course_ID", "Course_Title");
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "Ar_Name");
            return View();
        }

        // POST: Registered_in_the_course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_ID,Course_ID,Attendance_Status,Evaluation_Status,Certificate_Status")] Registered_in_the_course registered_in_the_course)
        {
            if (ModelState.IsValid)
            {
                db.Registered_in_the_courses.Add(registered_in_the_course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_ID = new SelectList(db.CourseSchedules, "Course_ID", "Course_Title", registered_in_the_course.Course_ID);
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "Ar_Name", registered_in_the_course.User_ID);
            return View(registered_in_the_course);
        }

        // GET: Registered_in_the_course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registered_in_the_course registered_in_the_course = db.Registered_in_the_courses.Find(id);
            if (registered_in_the_course == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_ID = new SelectList(db.CourseSchedules, "Course_ID", "Course_Title", registered_in_the_course.Course_ID);
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "Ar_Name", registered_in_the_course.User_ID);
            return View(registered_in_the_course);
        }

        // POST: Registered_in_the_course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,Course_ID,Attendance_Status,Evaluation_Status,Certificate_Status")] Registered_in_the_course registered_in_the_course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registered_in_the_course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_ID = new SelectList(db.CourseSchedules, "Course_ID", "Course_Title", registered_in_the_course.Course_ID);
            ViewBag.User_ID = new SelectList(db.Users, "User_ID", "Ar_Name", registered_in_the_course.User_ID);
            return View(registered_in_the_course);
        }

        // GET: Registered_in_the_course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registered_in_the_course registered_in_the_course = db.Registered_in_the_courses.Find(id);
            if (registered_in_the_course == null)
            {
                return HttpNotFound();
            }
            return View(registered_in_the_course);
        }

        // POST: Registered_in_the_course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registered_in_the_course registered_in_the_course = db.Registered_in_the_courses.Find(id);
            db.Registered_in_the_courses.Remove(registered_in_the_course);
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
