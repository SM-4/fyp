using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fyp.Models;
using fyp.Utills;

namespace fyp.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Vet()
        {
            return View();
        }
        public ActionResult Shelter()
        {
            return View();
        } 
        public ActionResult Training()
        {
            return View();
        }
        public ActionResult ProductDetail(int id)
        {
            ViewData["detailid"] = id;
            return View();
            //var product = db.tblPets.Where(x => x.Pets_ID == id).FirstOrDefault();
            //return View(product);
        }
        //Feedback
        public ActionResult Feedback()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Feedback(tblFeedback feedback)
        {
            if (CurrentUser.CurrentCustomer == null)
            {
                return RedirectToAction("CustomerLogin");
            }
            feedback.Feedback_Date = DateTime.Now;
            feedback.Customer_FID = CurrentUser.CurrentCustomer.Customer_ID;
            db.tblFeedbacks.Add(feedback);
            db.SaveChanges();
            return RedirectToAction("ProductDetail", new { id = feedback.Pets_FID });
        }
        //wishlist
        public ActionResult Wishlist(int id)
        {
            if (CurrentUser.CurrentCustomer == null)
            {
                return RedirectToAction("CustomerLogin");
            }
            if(db.tblWishlists.Any(x=>x.Pet_FID==id && x.Customer_FID == CurrentUser.CurrentCustomer.Customer_ID))
            {
                tblWishlist wish = db.tblWishlists.Where(x => x.Pet_FID == id).FirstOrDefault();
                db.tblWishlists.Remove(wish);
                db.SaveChanges();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    tblWishlist wish1 = new tblWishlist();
                    wish1.Pet_FID = id;
                    wish1.Customer_FID = CurrentUser.CurrentCustomer.Customer_ID;
                    db.tblWishlists.Add(wish1);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("pets", "Home");
        }
            public ActionResult Shop()
        {
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult ForgetPassword(string email)
        {
            var customer = db.tblCustomers.Where(x => x.Customer_Email == email).FirstOrDefault();
            if (customer == null)
            {
                TempData["error"] = "Invalid Email";
                return RedirectToAction("CustomerLogin");
            }
            Random random = new Random();
            int Code = random.Next(1001, 9999);
            Session["code"] = Code;
            Session["userforgetpassword"] = customer;
            string mailBody = "Your Verification vode is" + Code;
            EmailProvider.Email(customer.Customer_Email, "Verification Code", mailBody);
            return RedirectToAction("CodeVerify");
        }
        //Code Verify
        public ActionResult CodeVerify()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CodeVerify(int code)
        {
            int sendCode = (int)Session["code"];
            if (code == sendCode)
            {
                return RedirectToAction("NewPassword");
            }
            TempData["error"] = "Invalid code";
            return View();
        }
        //New Password
        public ActionResult NewPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewPassword(string password)
        {
            var user = (tblCustomer)Session["userforgetpassword"];
            var updatecus = db.tblCustomers.Where(x => x.Customer_Email == user.Customer_Email).FirstOrDefault();
            updatecus.Customer_Password = password;
            db.Entry(updatecus).State = EntityState.Modified;
            db.SaveChanges();
            TempData["msg"] = "Password updated successfully";
            return RedirectToAction("CustomerLogin");
        }
        //Customer Login
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(tblCustomer customer)
        {
            //    List<tblCustomer> checking = new List<tblCustomer>;
            //    if (Session["check"] != null)
            //    {
            //        checking = (List<tblCustomer>)Session["check"];
            //    }
            //    Session["check"] = checking;

            if (customer.Customer_Name == null || customer.Customer_Address == null || customer.Customer_Contact == null)
            {
                tblCustomer cus = db.tblCustomers.Where(x => x.Customer_Email == customer.Customer_Email && x.Customer_Password == customer.Customer_Password).FirstOrDefault();
               
                if (cus != null)
                {
                    CurrentUser.CurrentCustomer = cus;
                    if (Session["cart"] != null)
                    {
                        return RedirectToAction("Displaycart", "Cart");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.msg = "<script> alert('Invalid Email and Password') </script>";
                }
            }

            if (ModelState.IsValid)
            {
                db.tblCustomers.Add(customer);
                db.SaveChanges();
                ViewBag.msg = "<script>alert('Account Is Created Successfully')</script>";
            }
            return View();
        }
        public ActionResult pets(int? id)
        {
            if (id != null)
            {
                ViewData["catid"] = id;
            }
            return View();
        }
        public ActionResult SubCategory(int id)
        {
            ViewData["catid"] = id;
            return View();
        }
        //Login Admin
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(string email, string password)
        {
            tblAdmin v = db.tblAdmins.Where(x => x.Admin_Email == email && x.Admin_Password == password).FirstOrDefault();
            if (v != null)
            {
                CurrentUser.CurrentAdmin = v;
                return RedirectToAction("IndexAdmin");
            }
            else
            {
                ViewBag.loginerror = "Invalid Email and Password";
                return View();
            }

        }
        public ActionResult IndexCustomer()
        {
            return View();
        }
        public ActionResult IndexAdmin()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}