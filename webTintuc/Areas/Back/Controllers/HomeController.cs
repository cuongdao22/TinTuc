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
        public ActionResult Index(int? page,string id)
        {

            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (page == null) page = 1;
                List<Areas.Models.TinTuc> list = DAL.TinTuc.selectList();
                IEnumerable<Areas.Models.TinTuc> l = list.OrderByDescending(x => x.Id1);
                int pageNumber = (page ?? 1);
                ViewBag.test2 = id;
                ViewBag.PortfolioId = "âsasasas";
                return View(l.ToPagedList(pageNumber, 5));
            }
        }
        [HttpPost]
        public ActionResult Index(int? page, string idd,string id)
        {

            if (page == null) page = 1;
            List<Areas.Models.TinTuc> list = DAL.TinTuc.selectList();
            IEnumerable<Areas.Models.TinTuc> l = list.OrderByDescending(x => x.Id1);
            int pageNumber = (page ?? 1);
            ViewBag.test2 = idd;
            return View(l.ToPagedList(pageNumber, 5));
        }
        public ActionResult InsertTT()
        {
            
            return View();
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