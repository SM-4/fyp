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
    public class tblPetCategoriesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblPetCategories
        public ActionResult Index()
        {
            return View(db.tblPetCategories.ToList());
        }

        // GET: tblPetCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPetCategory tblPetCategory = db.tblPetCategories.Find(id);
            if (tblPetCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblPetCategory);
        }

        // GET: tblPetCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblPetCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblPetCategory tblPetCategory, HttpPostedFileBase pic2)
        {
            string fullpath = Server.MapPath("~/content/pets/" + pic2.FileName);
            pic2.SaveAs(fullpath);
            tblPetCategory.Category_Image = "~/content/pets/" + pic2.FileName;

            if (ModelState.IsValid)
            {
                db.tblPetCategories.Add(tblPetCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPetCategory);
        }

        // GET: tblPetCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPetCategory tblPetCategory = db.tblPetCategories.Find(id);
            if (tblPetCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblPetCategory);
        }

        // POST: tblPetCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblPetCategory tblPetCategory, HttpPostedFileBase pic2)
        {
            if (pic2 != null)
            {
                string fullpath = Server.MapPath("~/content/pets/" + pic2.FileName);
                pic2.SaveAs(fullpath);
                tblPetCategory.Category_Image = "~/content/pets/" + pic2.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(tblPetCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPetCategory);
        }

        // GET: tblPetCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPetCategory tblPetCategory = db.tblPetCategories.Find(id);
            if (tblPetCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblPetCategory);
        }

        // POST: tblPetCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPetCategory tblPetCategory = db.tblPetCategories.Find(id);
            db.tblPetCategories.Remove(tblPetCategory);
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
