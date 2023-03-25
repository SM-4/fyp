using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fyp.Models;

namespace fyp.Controllers
{
    public class ReportsController : Controller
    {
        Model1 db = new Model1();
        // GET: Reports
        public ActionResult StockReport()
        {
            var p = db.tblPets.ToList();
            return View(p);
        }
        public ActionResult ProfitandLossReport()
        {
            var p = db.tblOrders.ToList();
            return View(p);
        }
        public ActionResult SaleReport(DateTime? DateFrom,DateTime? DateTo,int? CATEGORY,int? SubCATEGORY,int? PET)
        {
            if (DateFrom == null)
            {
                DateFrom = DateTime.Today;
            } 
            if (DateTo == null)
            {
                DateTo = DateTime.Now;
            }
            ViewBag.DateFrom = DateFrom.Value.ToString("s");
            ViewBag.DateTo = DateTo.Value.ToString("s");
            ViewBag.CATEGORY = new SelectList(db.tblPetCategories, "Category_ID", "Category_Name");
            ViewBag.SubCATEGORY = new SelectList(db.tblPetSubcategories, "Subcategory_ID", "Subcategory_Name");
            ViewBag.PET = new SelectList(db.tblPets, "Pets_ID", "Pets_Name");
            var orders = new List<tblOrder>();
            if (CATEGORY != null)
            {
                orders = db.tblOrders.Where(x => x.Order_Status == "Delivered" && x.Customer_FID!=null && x.Order_Date >= DateFrom && x.Order_Date <= DateTo).OrderByDescending(x => x.Order_Date).ToList();
                orders.Where(x => x.tblOrderDetails.Any(z => z.tblPet.tblPetSubcategory.Category_FID == SubCATEGORY)).ToList();
            }
            if (SubCATEGORY != null)
            {
                orders = db.tblOrders.Where(x => x.Order_Status == "Delivered" && x.Customer_FID != null && x.Order_Date >= DateFrom && x.Order_Date <= DateTo).OrderByDescending(x => x.Order_Date).ToList();
                orders.Where(x => x.tblOrderDetails.Any(z => z.tblPet.P_SubcategoryFID == SubCATEGORY)).ToList();
            }
            if (PET != null)
            {
                orders = db.tblOrders.Where(x => x.Order_Status == "Delivered" && x.Customer_FID != null && x.Order_Date >= DateFrom && x.Order_Date <= DateTo).OrderByDescending(x => x.Order_Date).ToList();
                orders.Where(x => x.tblOrderDetails.Any(z => z.Pets_FID == PET)).ToList();
            }
            else
            {
                orders = db.tblOrders.Where(x => x.Order_Status == "Delivered" && x.Customer_FID != null && x.Order_Date >= DateFrom && x.Order_Date <= DateTo).OrderByDescending(x => x.Order_Date).ToList();

            }
            return View(orders);
        }
        public ActionResult PurchaseReport(DateTime? DateFrom,DateTime? DateTo,int? CATEGORY,int? SubCATEGORY,int? PET)
        {
            if (DateFrom == null)
            {
                DateFrom = DateTime.Today;
            } 
            if (DateTo == null)
            {
                DateTo = DateTime.Now;
            }
            ViewBag.DateFrom = DateFrom.Value.ToString("s");
            ViewBag.DateTo = DateTo.Value.ToString("s");
            ViewBag.CATEGORY = new SelectList(db.tblPetCategories, "Category_ID", "Category_Name");
            ViewBag.SubCATEGORY = new SelectList(db.tblPetSubcategories, "Subcategory_ID", "Subcategory_Name");
            ViewBag.PET = new SelectList(db.tblPets, "Pets_ID", "Pets_Name");
            var orders = new List<tblOrder>();
            if (CATEGORY != null)
            {
                orders = db.tblOrders.Where(x => x.Order_Status == "Complete" && x.Admin_FID!=null && x.Order_Date >= DateFrom && x.Order_Date <= DateTo).OrderByDescending(x => x.Order_Date).ToList();
                orders.Where(x => x.tblOrderDetails.Any(z => z.tblPet.tblPetSubcategory.Category_FID == SubCATEGORY)).ToList();
            }
            if (SubCATEGORY != null)
            {
                orders = db.tblOrders.Where(x => x.Order_Status == "Complete" && x.Admin_FID != null && x.Order_Date >= DateFrom && x.Order_Date <= DateTo).OrderByDescending(x => x.Order_Date).ToList();
                orders.Where(x => x.tblOrderDetails.Any(z => z.tblPet.P_SubcategoryFID == SubCATEGORY)).ToList();
            }
            if (PET != null)
            {
                orders = db.tblOrders.Where(x => x.Order_Status == "Complete" && x.Admin_FID != null && x.Order_Date >= DateFrom && x.Order_Date <= DateTo).OrderByDescending(x => x.Order_Date).ToList();
                orders.Where(x => x.tblOrderDetails.Any(z => z.Pets_FID == PET)).ToList();
            }
            else
            {
                orders = db.tblOrders.Where(x => x.Order_Status == "Complete" && x.Admin_FID != null && x.Order_Date >= DateFrom && x.Order_Date <= DateTo).OrderByDescending(x => x.Order_Date).ToList();

            }
            return View(orders);
        }
    }
}