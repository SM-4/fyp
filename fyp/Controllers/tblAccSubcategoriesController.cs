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
    public class tblAccSubcategoriesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblAccSubcategories
        public ActionResult Index()
        {
            var tblAccSubcategories = db.tblAccSubcategories.Include(t => t.tblAccCategory);
            return View(tblAccSubcategories.ToList());
        }

        // GET: tblAccSubcategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccSubcategory tblAccSubcategory = db.tblAccSubcategories.Find(id);
            if (tblAccSubcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblAccSubcategory);
        }

        // GET: tblAccSubcategories/Create
        public ActionResult Create()
        {
            ViewBag.A_CategoryFID = new SelectList(db.tblAccCategories, "A_CategoryID", "A_CategoryName");
            return View();
        }

        // POST: tblAccSubcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( tblAccSubcategory tblAccSubcategory, HttpPostedFileBase pic1)
        {
            string fullpath = Server.MapPath("~/content/accessory/" + pic1.FileName);
            pic1.SaveAs(fullpath);
            tblAccSubcategory.A_SubcategoryImage = "~/content/accessory/" + pic1.FileName;

            if (ModelState.IsValid)
            {
                db.tblAccSubcategories.Add(tblAccSubcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.A_CategoryFID = new SelectList(db.tblAccCategories, "A_CategoryID", "A_CategoryName", tblAccSubcategory.A_CategoryFID);
            return View(tblAccSubcategory);
        }

        // GET: tblAccSubcategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccSubcategory tblAccSubcategory = db.tblAccSubcategories.Find(id);
            if (tblAccSubcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.A_CategoryFID = new SelectList(db.tblAccCategories, "A_CategoryID", "A_CategoryName", tblAccSubcategory.A_CategoryFID);
            return View(tblAccSubcategory);
        }

        // POST: tblAccSubcategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( tblAccSubcategory tblAccSubcategory, HttpPostedFileBase pic1)
        {
            if (pic1 != null)
            {
                string fullpath = Server.MapPath("~/content/accessory/" + pic1.FileName);
                pic1.SaveAs(fullpath);
                tblAccSubcategory.A_SubcategoryImage = "~/content/accessory/" + pic1.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(tblAccSubcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.A_CategoryFID = new SelectList(db.tblAccCategories, "A_CategoryID", "A_CategoryName", tblAccSubcategory.A_CategoryFID);
            return View(tblAccSubcategory);
        }

        // GET: tblAccSubcategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccSubcategory tblAccSubcategory = db.tblAccSubcategories.Find(id);
            if (tblAccSubcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblAccSubcategory);
        }

        // POST: tblAccSubcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAccSubcategory tblAccSubcategory = db.tblAccSubcategories.Find(id);
            db.tblAccSubcategories.Remove(tblAccSubcategory);
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
