using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webTintuc.Areas.Front.Controllers
{
    public class ChuDeController : Controller
    {
        // GET: Front/ChuDe
        public ActionResult Index(int id, int? page)
        {
            ViewBag.listMenu = DAL.DanhMuc.selectALLDM();
            ViewBag.listTT4 = DAL.TinTuc.selectTT4();
            List<Areas.Models.TinTuc> list = DAL.TinTuc.selectTTDM(id.ToString());
            if (list.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                IEnumerable<Areas.Models.TinTuc> l = list.OrderByDescending(x => x.Id1);
                ViewBag.tenChuDe = list[0].TenDM1;
                int pageNumber = (page ?? 1);
                return View(l.ToPagedList(pageNumber, 10));
            }
            
        }
    }
}