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
    public class tblVetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblVets
        public ActionResult Index()
        {
            return View(db.tblVets.ToList());
        }

        // GET: tblVets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVet tblVet = db.tblVets.Find(id);
            if (tblVet == null)
            {
                return HttpNotFound();
            }
            return View(tblVet);
        }

        // GET: tblVets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblVets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Veterinarian_ID,Veterinarian_Name,Veterinarian_Contact,Veterinarian_Address")] tblVet tblVet)
        {
            if (ModelState.IsValid)
            {
                db.tblVets.Add(tblVet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblVet);
        }

        // GET: tblVets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVet tblVet = db.tblVets.Find(id);
            if (tblVet == null)
            {
                return HttpNotFound();
            }
            return View(tblVet);
        }

        // POST: tblVets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Veterinarian_ID,Veterinarian_Name,Veterinarian_Contact,Veterinarian_Address")] tblVet tblVet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblVet);
        }

        // GET: tblVets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVet tblVet = db.tblVets.Find(id);
            if (tblVet == null)
            {
                return HttpNotFound();
            }
            return View(tblVet);
        }

        // POST: tblVets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVet tblVet = db.tblVets.Find(id);
            db.tblVets.Remove(tblVet);
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
