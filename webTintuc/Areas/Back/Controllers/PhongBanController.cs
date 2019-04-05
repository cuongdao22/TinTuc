using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webTintuc.Areas.Back.Controllers
{
    public class PhongBanController : Controller
    {
        // GET: Back/PhongBan
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            ViewBag.username = "Tiến Thành";
            List<Areas.Models.PhongBan> list = DAL.PhongBan.select();
            IEnumerable<Areas.Models.PhongBan> l = list.OrderByDescending(x => x.Id);
            int pageNumber = (page ?? 1);
            return View(l.ToPagedList(pageNumber, 5));
            
        }
        public ActionResult Delete(string id,string idpb)
        {
            DAL.PhongBan.deteleDSMod(id);
            return RedirectToAction("DSNhanVien", "PhongBan",new { idPb = idpb });
           

        }
        public ActionResult DSNhanVien(int? page,string idPb)
        {
            if (page == null) page = 1;
            ViewBag.username = "Tiến Thành";
            ViewBag.idPhongBan = idPb;
            ViewBag.listNV = DAL.PhongBan.selectDSNV();
            List<Areas.Models.NhanVien> list = DAL.PhongBan.selectDSMod(idPb);
            IEnumerable<Areas.Models.NhanVien> l = list.OrderByDescending(x => x.Id);
            int pageNumber = (page ?? 1);


            return View(l.ToPagedList(pageNumber, 5));

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DSNhanVien(int? page, string idPhongBan,string mnv)
        {
            DAL.PhongBan.insertMod(mnv, idPhongBan);
            if (page == null) page = 1;
            ViewBag.username = "Tiến Thành";
            ViewBag.idPhongBan = idPhongBan;
            ViewBag.listNV = DAL.PhongBan.selectDSNV();
            List<Areas.Models.NhanVien> list = DAL.PhongBan.selectDSMod(idPhongBan);
            IEnumerable<Areas.Models.NhanVien> l = list.OrderByDescending(x => x.Id);
            int pageNumber = (page ?? 1);
    
           
            return View(l.ToPagedList(pageNumber, 5));

        }
        public ActionResult Create()
        {
            return View();
        }
    }
}