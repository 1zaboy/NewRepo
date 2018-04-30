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
            ViewBag.UserListOnPrint = fil1.AspNetUsers;
            return View();
        }
    }
}