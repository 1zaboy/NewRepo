﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication1;
using System.Drawing;
using System.IO;
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
            numb = 0;
            ViewBag.Message = "Your contact page.";
            ViewBag.Ord = fil1.DbUserOrder.OrderBy(t=>t.DateIn).Where(t=>t.User2Id == null).Take(15);
            var Lis = fil1.DbUserOrder.ToList();
            Bol = Lis.Count > 15;
            ViewBag.Bool = Bol;
            numb = 0;            
            return View();
        }

        public ActionResult Order_next()
        {
            ViewBag.Message = "Your contact page.";
            numb += 15;
            ViewBag.Ord = fil1.DbUserOrder.OrderBy(t => t.DateIn).Where(t => t.User2Id == null).Skip(numb).Take(15);
            var Lis = fil1.DbUserOrder.ToList();
            Bol = Lis.Count > 15;
            ViewBag.Bool = Bol;
            return View("Orders");
        }

        public ActionResult Order_early()
        {
            ViewBag.Message = "Your contact page.";
            numb -= 15;
            if (numb < 0)
                numb = 0;
            ViewBag.Ord = fil1.DbUserOrder.OrderBy(t => t.DateIn).Where(t => t.User2Id == null).Skip(numb).Take(15);
            var Lis = fil1.DbUserOrder.ToList();
            Bol = Lis.Count > 15;
            ViewBag.Bool = Bol;
            return View("Orders");
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
        private bool Bol;
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
            var Lis = fil1.AspNetUsers.ToList();
            Bol = Lis.Count > 10;
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
            var Lis = fil1.AspNetUsers.ToList();
            Bol = Lis.Count > 10;
            ViewBag.Bool = Bol;
            return View("Developers");
        }
        public AspNetUsers getUser(string IdUser)
        {
            return ff.AspNetUsers.Where(t => t.Id == IdUser).ToList().First();
        }
        public ActionResult UserImg(string id)
        {
            Stream stream;
            var t = getUser(id);
            if (t.Icon!=null)
            {
                var image0 = imgC.ByteToImage(t.Icon);
                image0 = imgC.RezizeImage(image0, 200, 200);
                stream = new MemoryStream(imgC.ImageToByte(image0));
                
            }
            else
            {
                
                var image0 = imgC.RezizeImage(Image.FromFile("~/Content/image/icon_about_us.png",false), 200, 200);
                stream = new MemoryStream(imgC.ImageToByte(image0));
            }
            return new FileStreamResult(stream, "image/jpeg");
        }
        public ActionResult UserName(string id)//text/plain
        {
            var gg = getUser(id).UserName;
            Stream stream = new MemoryStream(Convert.FromBase64String(gg));
            return new FileStreamResult(stream, "text/plain");
            
        }
        private help_cs.img imgC = new help_cs.img();
        public ActionResult OrderImg(int id)
        {
            var t1 = ff.DbUserOrder.Where(t => t.Id == id).ToList().First();
            
            Stream stream = new MemoryStream(t1.WayFile);
            return new FileStreamResult(stream, "image/jpeg");
        }
       
    }
}