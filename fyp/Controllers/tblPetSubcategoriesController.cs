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
    public class tblPetSubcategoriesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblPetSubcategories
        public ActionResult Index()
        {
            var tblPetSubcategories = db.tblPetSubcategories.Include(t => t.tblPetCategory);
            return View(tblPetSubcategories.ToList());
        }

        // GET: tblPetSubcategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPetSubcategory tblPetSubcategory = db.tblPetSubcategories.Find(id);
            if (tblPetSubcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblPetSubcategory);
        }

        // GET: tblPetSubcategories/Create
        public ActionResult Create()
        {
            ViewBag.Category_FID = new SelectList(db.tblPetCategories, "Category_ID", "Category_Name");
            return View();
        }

        // POST: tblPetSubcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( tblPetSubcategory tblPetSubcategory, HttpPostedFileBase pic4)
        {
            string fullpath = Server.MapPath("~/content/pets/" + pic4.FileName);
            pic4.SaveAs(fullpath);
            tblPetSubcategory.Subcategory_Image = "~/content/pets/" + pic4.FileName;

            if (ModelState.IsValid)
            {
                db.tblPetSubcategories.Add(tblPetSubcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_FID = new SelectList(db.tblPetCategories, "Category_ID", "Category_Name", tblPetSubcategory.Category_FID);
            return View(tblPetSubcategory);
        }

        // GET: tblPetSubcategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPetSubcategory tblPetSubcategory = db.tblPetSubcategories.Find(id);
            if (tblPetSubcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_FID = new SelectList(db.tblPetCategories, "Category_ID", "Category_Name", tblPetSubcategory.Category_FID);
            return View(tblPetSubcategory);
        }

        // POST: tblPetSubcategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( tblPetSubcategory tblPetSubcategory, HttpPostedFileBase pic4)
        {
            if (pic4 != null)
            {
                string fullpath = Server.MapPath("~/content/pets/" + pic4.FileName);
                pic4.SaveAs(fullpath);
                tblPetSubcategory.Subcategory_Image = "~/content/pets/" + pic4.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(tblPetSubcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_FID = new SelectList(db.tblPetCategories, "Category_ID", "Category_Name", tblPetSubcategory.Category_FID);
            return View(tblPetSubcategory);
        }

        // GET: tblPetSubcategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPetSubcategory tblPetSubcategory = db.tblPetSubcategories.Find(id);
            if (tblPetSubcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblPetSubcategory);
        }

        // POST: tblPetSubcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPetSubcategory tblPetSubcategory = db.tblPetSubcategories.Find(id);
            db.tblPetSubcategories.Remove(tblPetSubcategory);
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
