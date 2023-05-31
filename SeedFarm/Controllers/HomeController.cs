using SeedFarm.DataLayer;
using SeedFarm.Models;
using System;
using System.Web.Mvc;

namespace SeedFarm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Billing()
        {
            var model = new BillDescriptionViewModel();
            return PartialView("BillPartial",model);
        }

        [HttpPost]
        public ActionResult SaveBill(BillDescriptionViewModel data) 
        {
            DataAccess da = new DataAccess();
            data.BillId= da.Insert(data);
            data.BillDate = DateTime.Now;
            return PartialView("Invoice", data);
        }
    }
}