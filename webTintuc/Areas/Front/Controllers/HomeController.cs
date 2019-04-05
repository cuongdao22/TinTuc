using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webTintuc.Areas.Front.Controllers
{
    public class HomeController : Controller
    {
        // GET: Front/Home
        public ActionResult Index()
        {

            ViewBag.listMenu = DAL.DanhMuc.selectALLDM();
            ViewBag.listTT4 = DAL.TinTuc.selectTT4();
            ViewBag.listDM1 = DAL.TinTuc.selectTTDM1();
            
            return View();
        }
        public ActionResult ChiTiet(int id)
        {
            ViewBag.listMenu = DAL.DanhMuc.selectALLDM();
            ViewBag.listTT4 = DAL.TinTuc.selectTT4();
            Areas.Models.TinTuc tt = new Models.TinTuc();
            tt = DAL.TinTuc.selectTT(id.ToString());
            return View(tt);
        }




    }
}