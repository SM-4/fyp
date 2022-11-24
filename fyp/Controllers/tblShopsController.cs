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
    public class tblShopsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblShops
        public ActionResult Index()
        {
            return View(db.tblShops.ToList());
        }

        // GET: tblShops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblShop tblShop = db.tblShops.Find(id);
            if (tblShop == null)
            {
                return HttpNotFound();
            }
            return View(tblShop);
        }

        // GET: tblShops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblShops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Shop_ID,Shop_Name,Shop_Address")] tblShop tblShop)
        {
            if (ModelState.IsValid)
            {
                db.tblShops.Add(tblShop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblShop);
        }

        // GET: tblShops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblShop tblShop = db.tblShops.Find(id);
            if (tblShop == null)
            {
                return HttpNotFound();
            }
            return View(tblShop);
        }

        // POST: tblShops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Shop_ID,Shop_Name,Shop_Address")] tblShop tblShop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblShop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblShop);
        }

        // GET: tblShops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblShop tblShop = db.tblShops.Find(id);
            if (tblShop == null)
            {
                return HttpNotFound();
            }
            return View(tblShop);
        }

        // POST: tblShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblShop tblShop = db.tblShops.Find(id);
            db.tblShops.Remove(tblShop);
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
