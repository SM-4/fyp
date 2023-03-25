using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using fyp.Models;

namespace fyp.Utills
{
    public static class CurrentUser
    {
        public static tblCustomer CurrentCustomer { get; set; }
        public static tblAdmin CurrentAdmin { get; set; }
    }
}