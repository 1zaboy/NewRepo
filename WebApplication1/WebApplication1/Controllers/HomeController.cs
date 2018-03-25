using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        db fil1 = new db();
        public ActionResult Index()
        {
            
            ViewBag.Home_Card = fil1.DtHomeImgInfos;
            ViewBag.Home_Corouse = fil1.DtHomeImgCarousel;
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
            ViewBag.Ord = fil1.DbUserOrder;
            return View();
        }
        public ActionResult Developers()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.UserListOnPrint = fil1.AspNetUsers;
            return View();
        }
    }
}