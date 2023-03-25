using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fyp.Models;
using fyp.Utills;

namespace fyp.Controllers
{

    public class CartController : Controller
    {
        Model1 db = new Model1();
        // GET: Cart

        //Add to Cart
        public ActionResult AddtoCart(int petid)
        {
            List<tblPet> CartList = new List<tblPet>();

            if (Session["cart"] != null)
            {
                CartList = (List<tblPet>)Session["cart"];
            }

            tblPet existingpet = CartList.Where(x => x.Pets_ID == petid).FirstOrDefault();
            if (existingpet != null)
            {
                existingpet.Quantity++;
            }
            else
            {
                tblPet tblPet = db.tblPets.Where(x => x.Pets_ID == petid).FirstOrDefault();
                tblPet.Quantity = 1;
                CartList.Add(tblPet);
            }
            Session["cart"] = CartList;

            return RedirectToAction("Displaycart");
        }

        public ActionResult Displaycart()
        {
            return View();
        }
        //Remove from cart
        public ActionResult RemoveFromCart(int id)
        {
            List<tblPet> list = new List<tblPet>();
            list = (List<tblPet>)Session["cart"];
            list.RemoveAt(id);
            Session["cart"] = list;
            return RedirectToAction("Displaycart");
        }
        //Plus to cart
        public ActionResult PlusToCart(int id)
        {
            List<tblPet> list = new List<tblPet>();
            list = (List<tblPet>)Session["cart"];
            list[id].Quantity++;
            Session["cart"] = list;
            return RedirectToAction("Displaycart");
        }
        //Minus from cart
        public ActionResult MinusFromCart(int id)
        {
            List<tblPet> list = new List<tblPet>();
            list = (List<tblPet>)Session["cart"];
            list[id].Quantity--;
            if (list[id].Quantity < 1)
            {
                list.RemoveAt(id);
            }
            Session["cart"] = list;
            return RedirectToAction("Displaycart");
        }
        //Accessories Cart
        //public ActionResult AddtoCart2(int id)
        //{
        //    List<tblAccessory> Cartlist = new List<tblAccessory>();
        //    if (Session["acart"] != null)
        //    {
        //        Cartlist = (List<tblAccessory>)Session["acart"];
        //    }
        //    tblAccessory existingAccessory = Cartlist.Where(x => x.Accessories_ID == id).FirstOrDefault();
        //    if(existingAccessory != null)
        //    {
        //        existingAccessory.AccQuantity++;
        //    }
        //    else
        //    {
        //        tblAccessory tblAccessory = db.tblAccessories.Where(x => x.Accessories_ID == id).FirstOrDefault();
        //        tblAccessory.AccQuantity = 1;
        //        Cartlist.Add(tblAccessory);
        //    }
        //    Session["acart"] = Cartlist;
        //    return RedirectToAction("Displaycart");
        //}


        //Order Booked
        public ActionResult OrderBooked(tblOrder order)
        {
            order.Order_Status = "Booked";
            order.Order_Type = "Sale";
            order.Customer_FID = CurrentUser.CurrentCustomer.Customer_ID;
            order.Order_Date = System.DateTime.Now;
            db.tblOrders.Add(order);
            db.SaveChanges();

            tblOrderDetail od = new tblOrderDetail();
            var pet = (List<tblPet>)Session["cart"];

            foreach (var item in pet)
            {
                od.Pets_FID = item.Pets_ID;
                od.Order_PetQuantity = item.Quantity;
                od.SalePricePet = item.Pets_SalePrice;
                od.PurchasePricePet = item.Pets_PurchasePrice;
                od.Order_FID = order.Order_ID;

            }
            db.tblOrderDetails.Add(od);
            db.SaveChanges();

            string mailBody = "Your Order has been confirmed.Your order will be deliver within 3 days.";
            EmailProvider.Email(CurrentUser.CurrentCustomer.Customer_Email, "Order Confirmation", mailBody);

            TempData["petorder"] = Session["cart"];
            Session["cart"] = null;
            return RedirectToAction("CompleteOrder");
        }

        public ActionResult CompleteOrder()
        {
            return View();
        }
        //Checkout
        public ActionResult checkout()
        {

            if (CurrentUser.CurrentCustomer == null)
            {
                return RedirectToAction("CustomerLogin", "Home");
            }
            return View();
        }
    }
}