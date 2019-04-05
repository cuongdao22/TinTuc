using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webTintuc.Areas.Back.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: Back/NhanVien
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            List<Areas.Models.NhanVien> list = DAL.NhanVien.selectList();
            IEnumerable<Areas.Models.NhanVien> l = list.OrderByDescending(x => x.Id);
            int pageNumber = (page ?? 1);
            return View(l.ToPagedList(pageNumber, 5));
        }
        public ActionResult InsertNV()
        {
            ViewBag.listDM = DAL.DanhMuc.select();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertNV(Areas.Models.NhanVien nv,string selectDM)
        {
            ViewBag.listDM = DAL.DanhMuc.select();
            nv.IdDM = Int32.Parse(selectDM);
            DAL.NhanVien.insert(nv);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.listDM = DAL.DanhMuc.select();
            Areas.Models.NhanVien nv = DAL.NhanVien.selectNV(id);
            nv.Id = id;
            return View(nv);
        }
        [HttpPost]
        public ActionResult Edit(Areas.Models.NhanVien nv, int id)
        {
            ViewBag.listDM = DAL.DanhMuc.select();
            nv.Id = id;
            DAL.NhanVien.update(nv);

            return RedirectToAction("Index");
        }
    }
}