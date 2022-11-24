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
    public class tblPetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblPets
        public ActionResult Index()
        {
            var tblPets = db.tblPets.Include(t => t.tblPetSubcategory).Include(t => t.tblShop);
            return View(tblPets.ToList());
        }

        // GET: tblPets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPet tblPet = db.tblPets.Find(id);
            if (tblPet == null)
            {
                return HttpNotFound();
            }
            return View(tblPet);
        }

        // GET: tblPets/Create
        public ActionResult Create()
        {
            ViewBag.P_SubcategoryFID = new SelectList(db.tblPetSubcategories, "P_SubcategoryID", "P_SubcategoryName");
            ViewBag.Shop_FID = new SelectList(db.tblShops, "Shop_ID", "Shop_Name");
            return View();
        }

        // POST: tblPets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( tblPet tblPet, HttpPostedFileBase pic3)
        {
            string fullpath = Server.MapPath("~/content/pets/" + pic3.FileName);
            pic3.SaveAs(fullpath);
            tblPet.Pets_Image = "~/content/pets/" + pic3.FileName;

            if (ModelState.IsValid)
            {
                db.tblPets.Add(tblPet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.P_SubcategoryFID = new SelectList(db.tblPetSubcategories, "P_SubcategoryID", "P_SubcategoryName", tblPet.P_SubcategoryFID);
            ViewBag.Shop_FID = new SelectList(db.tblShops, "Shop_ID", "Shop_Name", tblPet.Shop_FID);
            return View(tblPet);
        }

        // GET: tblPets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPet tblPet = db.tblPets.Find(id);
            if (tblPet == null)
            {
                return HttpNotFound();
            }
            ViewBag.P_SubcategoryFID = new SelectList(db.tblPetSubcategories, "P_SubcategoryID", "P_SubcategoryName", tblPet.P_SubcategoryFID);
            ViewBag.Shop_FID = new SelectList(db.tblShops, "Shop_ID", "Shop_Name", tblPet.Shop_FID);
            return View(tblPet);
        }

        // POST: tblPets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( tblPet tblPet, HttpPostedFileBase pic3)
        {
            if (pic3 != null)
            {
                string fullpath = Server.MapPath("~/content/pets/" + pic3.FileName);
                pic3.SaveAs(fullpath);
                tblPet.Pets_Image = "~/content/pets/" + pic3.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(tblPet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.P_SubcategoryFID = new SelectList(db.tblPetSubcategories, "P_SubcategoryID", "P_SubcategoryName", tblPet.P_SubcategoryFID);
            ViewBag.Shop_FID = new SelectList(db.tblShops, "Shop_ID", "Shop_Name", tblPet.Shop_FID);
            return View(tblPet);
        }

        // GET: tblPets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPet tblPet = db.tblPets.Find(id);
            if (tblPet == null)
            {
                return HttpNotFound();
            }
            return View(tblPet);
        }

        // POST: tblPets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPet tblPet = db.tblPets.Find(id);
            db.tblPets.Remove(tblPet);
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
