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
            var iid = User.Identity.GetUserId();
            if (iid != null)
            {
                ViewBag.Ord = fil1.DbUserOrder.Where(t => t.User2Id != iid).ToList();
            }
            else
            {
                ViewBag.Ord = fil1.DbUserOrder;
            }
            return View();
        }
        public ActionResult Developers()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.UserListOnPrint = fil1.AspNetUsers.OrderBy(t=>t.Id).Take(10);
            numb = 0;
            return View();
        }
  
        public dbb ff = new dbb();
        [HttpPost]
        public ActionResult Developers(AspNetUsers pic, HttpPostedFileBase uploadImage)
        {
            var r = ff.AspNetUsers.Where(t => t.UserName.Contains(pic.UserName)).ToList();
            
            ViewBag.UserListOnPrint = r;
            //return RedirectToAction("Developers");

            return View();
        }
        public int numb = 0;
        public ActionResult Developers_next()
        {
            ViewBag.Message = "Your contact page.";
            numb += 10;
            ViewBag.UserListOnPrint = fil1.AspNetUsers.OrderBy(t=>t.Id).Skip(numb).Take(10);
            return View("Developers");
        }

        public ActionResult Developers_early()
        {
            ViewBag.Message = "Your contact page.";
            numb -= 10;
            if (numb < 0)
                numb = 0;
            ViewBag.UserListOnPrint = fil1.AspNetUsers.OrderBy(t => t.Id).Skip(numb).Take(10);
            return View("Developers");
        }
    }
}