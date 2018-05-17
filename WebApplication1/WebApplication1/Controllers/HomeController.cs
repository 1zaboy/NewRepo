using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication1;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        dbb fil1 = new dbb();
        public ActionResult Index()
        {
            
            ViewBag.Home_Card = fil1.DtHomeImgInfos.ToList();
            ViewBag.Home_Corouse = fil1.DtHomeImgCarousel.ToList();
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
        public ActionResult Orders()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Ord = fil1.DbUserOrder.OrderBy(t=>t.DateIn).Where(t=>t.User2Id == null).Take(30);
            var Lis = fil1.AspNetUsers.ToList();
            Bol = Lis.Count > 10;
            ViewBag.Bool = Bol;
            numb = 0;            
            return View();
        }

        public ActionResult Order_next()
        {
            ViewBag.Message = "Your contact page.";
            numb += 10;
            ViewBag.UserListOnPrint = fil1.DbUserOrder.OrderBy(t => t.DateIn).Where(t => t.User2Id == null).Skip(numb).Take(10);
            ViewBag.Bool = Bol;
            return View("Order");
        }

        public ActionResult Order_early()
        {
            ViewBag.Message = "Your contact page.";
            numb -= 10;
            if (numb < 0)
                numb = 0;
            ViewBag.UserListOnPrint = fil1.DbUserOrder.OrderBy(t => t.DateIn).Where(t => t.User2Id == null).Skip(numb).Take(10);
            ViewBag.Bool = Bol;
            return View("Order");
        }
        public ActionResult Developers()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.UserListOnPrint = fil1.AspNetUsers.OrderBy(t=>t.Id).Take(10);
            var Lis = fil1.AspNetUsers.ToList();
            Bol = Lis.Count > 10;
            ViewBag.Bool = Bol;
            numb = 0;
            return View();
        }
  
        public dbb ff = new dbb();
        private bool Bol = false;
        [HttpPost]
        public ActionResult Developers(AspNetUsers pic, HttpPostedFileBase uploadImage)
        {
            var r = ff.AspNetUsers.Where(t => t.UserName.Contains(pic.UserName)).ToList();
            
            ViewBag.UserListOnPrint = r;
            
            ViewBag.Bool = Bol;
            //return RedirectToAction("Developers");

            return View();
        }
        public int numb = 0;
        public ActionResult Developers_next()
        {
            ViewBag.Message = "Your contact page.";
            numb += 10;
            ViewBag.UserListOnPrint = fil1.AspNetUsers.OrderBy(t=>t.Id).Skip(numb).Take(10);
            ViewBag.Bool = Bol;
            return View("Developers");
        }

        public ActionResult Developers_early()
        {
            ViewBag.Message = "Your contact page.";
            numb -= 10;
            if (numb < 0)
                numb = 0;
            ViewBag.UserListOnPrint = fil1.AspNetUsers.OrderBy(t => t.Id).Skip(numb).Take(10);
            ViewBag.Bool = Bol;
            return View("Developers");
        }
    }
}