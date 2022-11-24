using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fyp.Models;

namespace fyp.Controllers
{
    public class tblSheltersController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblShelters
        public ActionResult Index()
        {
            return View(db.tblShelters.ToList());
        }

        // GET: tblShelters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblShelter tblShelter = db.tblShelters.Find(id);
            if (tblShelter == null)
            {
                return HttpNotFound();
            }
            return View(tblShelter);
        }

        // GET: tblShelters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblShelters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Shelter_ID,Shelter_Name,Shelter_Contact,Shelter_Address")] tblShelter tblShelter)
        {
            if (ModelState.IsValid)
            {
                db.tblShelters.Add(tblShelter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblShelter);
        }

        // GET: tblShelters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblShelter tblShelter = db.tblShelters.Find(id);
            if (tblShelter == null)
            {
                return HttpNotFound();
            }
            return View(tblShelter);
        }

        // POST: tblShelters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Shelter_ID,Shelter_Name,Shelter_Contact,Shelter_Address")] tblShelter tblShelter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblShelter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblShelter);
        }

        // GET: tblShelters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblShelter tblShelter = db.tblShelters.Find(id);
            if (tblShelter == null)
            {
                return HttpNotFound();
            }
            return View(tblShelter);
        }

        // POST: tblShelters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblShelter tblShelter = db.tblShelters.Find(id);
            db.tblShelters.Remove(tblShelter);
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
