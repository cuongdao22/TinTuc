using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webTintuc.Areas.Back.Controllers
{
    public class DuyetController : Controller
    {
        // GET: Back/Duyet
        public ActionResult Index(int? page)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (page == null) page = 1;
                ViewBag.username = "Tiến Thành";
                List<Areas.Models.TinTuc> list = DAL.TinTuc.selectList_Duyet("0");
                IEnumerable<Areas.Models.TinTuc> l = list.OrderByDescending(x => x.Id1);
                int pageNumber = (page ?? 1);

                return View(l.ToPagedList(pageNumber, 14));
            }
            
        }
        public ActionResult Duyet(int id)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                DAL.Duyet.duyet(id.ToString());

                return RedirectToAction("Index", "Duyet");
            }

        }


    }
}