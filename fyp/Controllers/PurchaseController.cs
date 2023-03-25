using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fyp.Models;
using fyp.Utills;

namespace fyp.Controllers
{
    public class PurchaseController : Controller
    {
        Model1 db = new Model1();
        // GET: Purchase
        public ActionResult AllProducts()
        {
            return View(db.tblPets.ToList());
        }
        public ActionResult AddtoCart(int petid, int qty)
        {
                List<tblPet> CartList = new List<tblPet>();

                if (Session["pcart"] != null)
                {
                    CartList = (List<tblPet>)Session["pcart"];
                }

                tblPet existingpet = CartList.Where(x => x.Pets_ID == petid).FirstOrDefault();
                if (existingpet != null)
                {
                existingpet.Quantity += qty;
                }
                else
                {
                    tblPet tblPet = db.tblPets.Where(x => x.Pets_ID == petid).FirstOrDefault();
                    tblPet.Quantity = qty;
                    CartList.Add(tblPet);
                }
                Session["pcart"] = CartList;

            return RedirectToAction("Displaycart");
        }
        public ActionResult Displaycart()
        {
            var cartlist = (List<tblPet>)Session["pcart"];
            return View(cartlist);
        }
        public ActionResult OrderComplete()
        {
            return View();
        }
        public ActionResult SavePurchase()
        {
            
            tblOrder order=new tblOrder();
            order.Admin_FID = CurrentUser.CurrentAdmin.Admin_ID;
            order.Order_Date = DateTime.Now;
            order.Order_Status = "Complete";
            order.Payment_Mode = "Cash in hand";
            order.Order_Type = "Purchase";
            db.tblOrders.Add(order);
            db.SaveChanges();

            var cartlist = (List<tblPet>)Session["pcart"];
            foreach (var item in cartlist)
            {
                tblOrderDetail od = new tblOrderDetail();
                od.Pets_FID = item.Pets_ID;
                od.Order_PetQuantity = item.Quantity;
                od.SalePricePet = item.Pets_SalePrice;
                od.PurchasePricePet = item.Pets_PurchasePrice;
                od.Order_FID = order.Order_ID;
                db.tblOrderDetails.Add(od);
                db.SaveChanges();
            }

            TempData["ptorder"] = Session["pcart"];
            Session["pcart"] = null;

            return RedirectToAction("OrderComplete");
        }

    }
}