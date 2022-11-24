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
    public class tblAccCategoriesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblAccCategories
        public ActionResult Index()
        {
            return View(db.tblAccCategories.ToList());
        }

        // GET: tblAccCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccCategory tblAccCategory = db.tblAccCategories.Find(id);
            if (tblAccCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblAccCategory);
        }

        // GET: tblAccCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblAccCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( tblAccCategory tblAccCategory, HttpPostedFileBase pic2)
        {
            string fullpath = Server.MapPath("~/content/accessory/" + pic2.FileName);
            pic2.SaveAs(fullpath);
            tblAccCategory.A_CategoryImage = "~/content/accessory/" + pic2.FileName;

            if (ModelState.IsValid)
            {
                db.tblAccCategories.Add(tblAccCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAccCategory);
        }

        // GET: tblAccCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccCategory tblAccCategory = db.tblAccCategories.Find(id);
            if (tblAccCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblAccCategory);
        }

        // POST: tblAccCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( tblAccCategory tblAccCategory, HttpPostedFileBase pic2)
        {
            if (pic2 != null)
            {
                string fullpath = Server.MapPath("~/content/accessory/" + pic2.FileName);
                pic2.SaveAs(fullpath);
                tblAccCategory.A_CategoryImage = "~/content/accessory/" + pic2.FileName;

            }
            if (ModelState.IsValid)
            {
                db.Entry(tblAccCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAccCategory);
        }

        // GET: tblAccCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccCategory tblAccCategory = db.tblAccCategories.Find(id);
            if (tblAccCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblAccCategory);
        }

        // POST: tblAccCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAccCategory tblAccCategory = db.tblAccCategories.Find(id);
            db.tblAccCategories.Remove(tblAccCategory);
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
