using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webTintuc.Areas.Back.Controllers
{
    public class TongBienTapController : Controller
    {
        // GET: Back/TongBienTap
        public ActionResult Index(int? page)
        {

            if (page == null) page = 1;
            ViewBag.username = "Tiến Thành";
            
            ViewBag.listNV = DAL.PhongBan.selectDSNV();
            List<Areas.Models.NhanVien> list = DAL.TongBienTap.selectDSTongBT();
            IEnumerable<Areas.Models.NhanVien> l = list.OrderByDescending(x => x.Id);
            int pageNumber = (page ?? 1);


            return View(l.ToPagedList(pageNumber, 5));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? page,string mnv)
        {
            DAL.TongBienTap.insert(mnv);
            if (page == null) page = 1;
            ViewBag.username = "Tiến Thành";

            ViewBag.listNV = DAL.PhongBan.selectDSNV();
            List<Areas.Models.NhanVien> list = DAL.TongBienTap.selectDSTongBT();
            IEnumerable<Areas.Models.NhanVien> l = list.OrderByDescending(x => x.Id);
            int pageNumber = (page ?? 1);


            return View(l.ToPagedList(pageNumber, 5));
        }
        public ActionResult Delete(string id)
        {
            DAL.TongBienTap.detele(id);
            return RedirectToAction("Index", "TongBienTap");

        }
    }
}