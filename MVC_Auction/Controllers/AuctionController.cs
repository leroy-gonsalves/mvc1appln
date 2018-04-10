using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Auction.Controllers
{
    public class AuctionController : Controller
    {
        //
        // GET: /Auction/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TempDataResult()
        {
            TempData["SuccessMessage"] = "Temp Data Message";

            return RedirectToAction("Index");
        }

        public ActionResult Auction()
        {

            var auction = new MVC_Auction.Models.Auction()
            {
                Title = "Sample Auction",
                Description = "this is auction",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(7),
                StartPrice = 1.00m,
                CurrentPrice = null,

            };

           // ViewData["Auction"] = auction;
            return View(auction);
        }
    }
}