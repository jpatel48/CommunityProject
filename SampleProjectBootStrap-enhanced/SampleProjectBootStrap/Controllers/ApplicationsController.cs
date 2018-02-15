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

        public ActionResult Index(string sortDirection, string sortField, string actionButton, int? ApplicantID, int? PostingID, int? FileStoreID)
        {
            PopulateDropDownLists();

            var applications = db.Applications.Include(a => a.Applicant).Include(a => a.FileStore).Include(a => a.Posting);

            //Add as many filters as needed
            if (ApplicantID.HasValue)
                applications = applications.Where(p => p.ApplicantID == ApplicantID);

            if (PostingID.HasValue)
                applications = applications.Where(p => p.PostingID == PostingID);

            if (FileStoreID.HasValue)
                applications = applications.Where(p => p.FileStoreID == FileStoreID);


            //sorting
            if (!String.IsNullOrEmpty(actionButton)) //Form Submitted so lets sort!
            {
                if (actionButton != "Filter")//Change of sort is requested
                {
                    if (actionButton == sortField) //Reverse order on same field
                    {
                        sortDirection = String.IsNullOrEmpty(sortDirection) ? "desc" : "";
                    }
                    sortField = actionButton;//Sort by the button clicked
                }
                //Now we know which field and direction to sort by, but a Switch is hard to use for 2 criteria
                //so we will use an if() structure instead.
                if (sortField.Contains("Posting"))//Sorting by Posting Name
                {
                    if (String.IsNullOrEmpty(sortDirection))
                    {
                        applications = applications
                            .OrderBy(p => p.Posting.Title);
                    }
                    else
                    {
                        applications = applications
                            .OrderByDescending(p => p.Posting.Title);
                    }
                }
                else if (sortField.Contains("Applicant"))//Sorting by Applicant
                {
                    if (String.IsNullOrEmpty(sortDirection))
                    {
                        applications = applications.OrderBy(p => p.Applicant.LastName)
                            .ThenBy(p => p.Applicant.FirstName);
                    }
                    else
                    {
                        applications = applications.OrderByDescending(p => p.Applicant.LastName)
                            .ThenBy(p => p.Applicant.FirstName);
                    }
                }
                else if (sortField.Contains("FileStore"))//Sorting by Applicant
                {
                    if (String.IsNullOrEmpty(sortDirection))
                    {
                        applications = applications.OrderBy(p => p.FileStore.FileName);
                    }
                    else
                    {
                        applications = applications.OrderByDescending(p => p.FileStore.FileName);
                    }
                }
            }

            //Set sort for next time
            ViewBag.sortField = sortField;
            ViewBag.sortDirection = sortDirection;
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
            PopulateDropDownLists();
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PostingID,ApplicantID,FileStoreID")] Application application)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Applications.Add(application);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                if (dex.InnerException.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "Unable to save changes. Remember, the same person cannot apply to the same job posting more than once.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }

            }

            PopulateDropDownLists(application);
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
            PopulateDropDownLists(application);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var applicationToUpdate = db.Applications.Find(id);
            if (TryUpdateModel(applicationToUpdate, "",
               new string[] { "PostingID", "ApplicantID", "FileStoreID" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException dex)
                {
                    if (dex.InnerException.InnerException.Message.Contains("IX_"))
                    {
                        ModelState.AddModelError("OHIP", "Unable to save changes. Remember, the same person cannot apply for the sae job posting more than once.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    }
                }
            }
            PopulateDropDownLists(applicationToUpdate);
            return View(applicationToUpdate);
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
            try
            {
                db.Applications.Remove(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(application);
        }


        private void PopulateDropDownLists(Application application = null)
        {
            var dQuery = from d in db.Applicants
                         orderby d.LastName, d.FirstName
                         select d;
            ViewBag.ApplicantID = new SelectList(dQuery, "ID", "FullName", application?.ApplicantID);

            var aQuery = from a in db.Postings.Include(s => s.Position)
                         .OrderBy(s => s.Position.ID)
                         .ThenBy(s => s.ClosingDate)
                         select a;
            ViewBag.PostingID = new SelectList(aQuery, "ID", "Title", application?.PostingID);
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
