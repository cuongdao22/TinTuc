using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace webTintuc.Areas.Back.Controllers
{
    public class HomeController : Controller
    {
        // GET: Back/Home
        public ActionResult Index(int? page,int ?id)
        {

            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (page == null) page = 1;
                ViewBag.username = "Tiến Thành";
                List<Areas.Models.TinTuc> list = DAL.TinTuc.selectList();
                IEnumerable<Areas.Models.TinTuc> l = list.OrderByDescending(x => x.Id1);
                int pageNumber = (page ?? 1);
                
                ViewBag.PortfolioId =  id.ToString();
                return View(l.ToPagedList(pageNumber, 5));
            }
        }
        [HttpPost]
        public ActionResult Index(int? page, string idd)
        {
            ViewBag.PortfolioId = idd;

            if (page == null) page = 1;
            List<Areas.Models.TinTuc> list = DAL.TinTuc.selectList();
            IEnumerable<Areas.Models.TinTuc> l = list.OrderByDescending(x => x.Id1);
            int pageNumber = (page ?? 1);
            ViewBag.test2 = idd;
            return View(l.ToPagedList(pageNumber, 5));
        }
        public ActionResult InsertTT()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string id = Session["login"].ToString();
                ViewBag.listTag = DAL.Tag.getTag();
                //DAL.TinTuc.checkAdmin(id);
                ViewBag.username = "Tiến Thành";
                return View();
            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult InsertTT(Areas.Models.TinTuc tt,string select)
        {
            ViewBag.noidung = tt.NoiDung1;
          
            return View();
        }
    }
}