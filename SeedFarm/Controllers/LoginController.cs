using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeedFarm.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult GoBill() 
        {
            return RedirectToAction("Index", "Home");
           // return PartialView("BillPartial");
        }
        
    }
}