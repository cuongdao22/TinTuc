using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webTintuc.Areas.Back.Controllers
{
    public class ChuyenMucController : Controller
    {
        // GET: Back/ChuyenMuc
        public ActionResult Index(int? page)
        {
            Areas.Models.DanhMuc dm = new Models.DanhMuc();
            
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (page == null) page = 1;
                ViewBag.username = "Tiến Thành";
                List<Areas.Models.DanhMuc> list = DAL.DanhMuc.selectAll();
                IEnumerable<Areas.Models.DanhMuc> l = list.OrderByDescending(x => x.Id);
                int pageNumber = (page ?? 1);
                

                return View(l.ToPagedList(pageNumber, 5));
            }
           
        }

        public ActionResult Create()
        {
            Areas.Models.DanhMuc tin = new Models.DanhMuc();
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.listDM = DAL.DanhMuc.select();

            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Areas.Models.DanhMuc tin,string selectDM)
        {
            
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                tin.DanhMucCha = Int32.Parse(selectDM);
                DAL.DanhMuc.insert(tin);
                return RedirectToAction("Index", "ChuyenMuc");
            }
            
        }
        public ActionResult Update(Areas.Models.DanhMuc danhmuc,int id)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                danhmuc = DAL.DanhMuc.selectDM(id.ToString());
                ViewBag.listDM = DAL.DanhMuc.select();
                return View(danhmuc);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Areas.Models.DanhMuc danhmuc, int id,string selectDM)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                
                
                ViewBag.listDM = DAL.DanhMuc.select();
                danhmuc.DanhMucCha = Int32.Parse(selectDM);
                danhmuc.Id = id;
                DAL.DanhMuc.update(danhmuc);
                return RedirectToAction("Index", "ChuyenMuc");
            }

        }



    }
}