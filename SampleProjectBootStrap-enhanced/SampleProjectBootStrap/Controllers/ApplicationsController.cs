using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectPlanning.Models;
using SampleProjectBootStrap.DAL;

namespace SampleProjectBootStrap.Controllers
{
    public class ApplicationsController : Controller
    {
        private JobEntities db = new JobEntities();

        // GET: Applications
        public ActionResult Index()
        {
            var applications = db.Applications.Include(a => a.Applicant).Include(a => a.FileStore).Include(a => a.Posting);
            return View(applications.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ID", "FirstName");
            ViewBag.FileStoreID = new SelectList(db.FileStores, "ID", "FileContent");
            ViewBag.PostingID = new SelectList(db.Postings, "ID", "Title");
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PostingID,ApplicantID,FileStoreID")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicantID = new SelectList(db.Applicants, "ID", "FirstName", application.ApplicantID);
            ViewBag.FileStoreID = new SelectList(db.FileStores, "ID", "FileContent", application.FileStoreID);
            ViewBag.PostingID = new SelectList(db.Postings, "ID", "Title", application.PostingID);
            return View(application);
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ID", "FirstName", application.ApplicantID);
            ViewBag.FileStoreID = new SelectList(db.FileStores, "ID", "FileContent", application.FileStoreID);
            ViewBag.PostingID = new SelectList(db.Postings, "ID", "Title", application.PostingID);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PostingID,ApplicantID,FileStoreID")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicantID = new SelectList(db.Applicants, "ID", "FirstName", application.ApplicantID);
            ViewBag.FileStoreID = new SelectList(db.FileStores, "ID", "FileContent", application.FileStoreID);
            ViewBag.PostingID = new SelectList(db.Postings, "ID", "Title", application.PostingID);
            return View(application);
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
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
