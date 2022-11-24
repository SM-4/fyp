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
    public class tblAccessoriesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblAccessories
        public ActionResult Index()
        {
            var tblAccessories = db.tblAccessories.Include(t => t.tblAccSubcategory).Include(t => t.tblShop);
            return View(tblAccessories.ToList());
        }

        // GET: tblAccessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccessory tblAccessory = db.tblAccessories.Find(id);
            if (tblAccessory == null)
            {
                return HttpNotFound();
            }
            return View(tblAccessory);
        }

        // GET: tblAccessories/Create
        public ActionResult Create()
        {
            ViewBag.A_SubcategoryFID = new SelectList(db.tblAccSubcategories, "A_SubcategoryID", "A_SubcategoryName");
            ViewBag.Shop_FID = new SelectList(db.tblShops, "Shop_ID", "Shop_Name");
            return View();
        }

        // POST: tblAccessories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblAccessory tblAccessory, HttpPostedFileBase pic)
        {
            string fullpath = Server.MapPath("~/content/accessory/" + pic.FileName);
            pic.SaveAs(fullpath);
            tblAccessory.Accessories_Image = "~/content/accessory/" + pic.FileName;
          
                if (ModelState.IsValid)
            {
                db.tblAccessories.Add(tblAccessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.A_SubcategoryFID = new SelectList(db.tblAccSubcategories, "A_SubcategoryID", "A_SubcategoryName", tblAccessory.A_SubcategoryFID);
            ViewBag.Shop_FID = new SelectList(db.tblShops, "Shop_ID", "Shop_Name", tblAccessory.Shop_FID);
            return View(tblAccessory);
        }

        // GET: tblAccessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccessory tblAccessory = db.tblAccessories.Find(id);
            if (tblAccessory == null)
            {
                return HttpNotFound();
            }
            ViewBag.A_SubcategoryFID = new SelectList(db.tblAccSubcategories, "A_SubcategoryID", "A_SubcategoryName", tblAccessory.A_SubcategoryFID);
            ViewBag.Shop_FID = new SelectList(db.tblShops, "Shop_ID", "Shop_Name", tblAccessory.Shop_FID);
            return View(tblAccessory);
        }

        // POST: tblAccessories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( tblAccessory tblAccessory, HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                string fullpath = Server.MapPath("~/content/accessory/" + pic.FileName);
                pic.SaveAs(fullpath);
                tblAccessory.Accessories_Image = "~/content/accessory/" + pic.FileName;

            }
            if (ModelState.IsValid)
            {
                db.Entry(tblAccessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.A_SubcategoryFID = new SelectList(db.tblAccSubcategories, "A_SubcategoryID", "A_SubcategoryName", tblAccessory.A_SubcategoryFID);
            ViewBag.Shop_FID = new SelectList(db.tblShops, "Shop_ID", "Shop_Name", tblAccessory.Shop_FID);
            return View(tblAccessory);
        }

        // GET: tblAccessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccessory tblAccessory = db.tblAccessories.Find(id);
            if (tblAccessory == null)
            {
                return HttpNotFound();
            }
            return View(tblAccessory);
        }

        // POST: tblAccessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAccessory tblAccessory = db.tblAccessories.Find(id);
            db.tblAccessories.Remove(tblAccessory);
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
