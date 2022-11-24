using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fyp.Models;

namespace fyp.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }  
        public ActionResult pets()
        {
            return View();
        }  
        public ActionResult PetSubCategory()
        {
            return View();
        }  
        public ActionResult petCategory()
        {
            return View();
        }
        public ActionResult AccCategory()
        {
            return View();
        }
        public ActionResult AccSubCategory()
        {
            return View();
        } 
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(string email, string password)
        {
            int v=db.tblAdmins.Where(x=>x.Admin_Email==email && x.Admin_Password==password).Count();
            if (v > 0)
            {
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