using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fyp.Models;

namespace fyp.Controllers
{
    public class AdminSideController : Controller
    {
        // GET: AdminSide
        Model1 db=new Model1(); 
        public ActionResult NewOrders()
        {
            var orders=db.tblOrders.Where(x => x.Order_Status == "Booked").OrderByDescending(x=>x.Order_Date).ToList();
            return View(orders);
        }  
        public ActionResult ProceedOrders()
        {
            var orders=db.tblOrders.Where(x => x.Order_Status == "Proceed").OrderByDescending(x=>x.Order_Date).ToList();
            return View(orders);
        } 
        public ActionResult invoice(int id)
        {
            var order=db.tblOrders.Where(x => x.Order_ID == id).FirstOrDefault();
            return View(order);
        }
        public ActionResult AddtoProceed(int id)
        {
            var order=db.tblOrders.Where(x => x.Order_ID == id).FirstOrDefault();
            order.Order_Status = "Proceed";
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            TempData["msg"] = "<script> alert(' Order Updated ') </script>";
            return RedirectToAction("NewOrders");
        }
        public ActionResult AddtoDelivered(int id)
        {
            var order=db.tblOrders.Where(x => x.Order_ID == id).FirstOrDefault();
            order.Order_Status = "Delivered";
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            TempData["msg"] = "<script> alert(' Order Updated ') </script>";
            return RedirectToAction("ProceedOrders");
        }
    }
}