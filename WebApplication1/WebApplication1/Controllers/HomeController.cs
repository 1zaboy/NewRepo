using System;
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
            var Lis = fil1.DbUserOrder.ToList();
            ViewBag.Count = Lis.Count;
            Bol = Lis.Count > 15;
            ViewBag.Bool = Bol;            
            return View();
        }      
        public ActionResult Developers()
        {
            ViewBag.Message = "Your contact page.";            
            var Lis = fil1.AspNetUsers.ToList();
            Bol = Lis.Count > 10;
            ViewBag.Bool = Bol;            
            return View();
        }
        public dbb ff = new dbb();
        private bool Bol;        
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
                var dir = Server.MapPath("/Content/image");
                var path = dir + "\\NotImg.jpg";
                var image0 = imgC.RezizeImage(Image.FromFile(path, false), 200, 200);
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
        public ActionResult ViewCardAjax(int numb)
        {
            var val = numb * 15;
            var allbooks = ff.DbUserOrder.Where(t=>t.User2Id == null).OrderByDescending(t=>t.Id).Skip(val).Take(15);
            return PartialView(allbooks);
        }        
        public ActionResult ViewDevAjax(int numb, string name1)
        {
            var val = numb * 10;
            var allbooks = ff.AspNetUsers.Where(t=>t.UserName.Contains(name1)).OrderByDescending(t => t.Id).Skip(val).Take(10);
            return PartialView(allbooks);
        }        
        

    }
}