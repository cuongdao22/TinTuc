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

            return View();
        }

    }
}