using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace webTintuc.Areas.Back.Controllers
{
    public class HomeController : Controller
    {
        // GET: Back/Home



        public ActionResult Index(int? page, int? id)
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

                ViewBag.PortfolioId = id.ToString();
                return View(l.ToPagedList(pageNumber, 14));
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
                string mnv = Session["login"].ToString();
                ViewBag.listTag = DAL.Tag.getTag();
                //DAL.TinTuc.checkAdmin(id);
                ViewBag.listDM = DAL.DanhMuc.select(mnv);
                ViewBag.username = "Tiến Thành";
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult InsertTT(Areas.Models.TinTuc tt, string selectDM, string url)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string id = Session["login"].ToString();
                tt.DanhMuc1 = Int32.Parse(selectDM);
                 tt.Anh1 = url;

                tt.TacGia1 = id;
                tt.MetaTitle1 = DAL.XuLiChuoi.xoaKhoangTrang(tt.TieuDe1);
                string[] tagg = tt.Tag1.Split(',');
                DAL.TinTuc.insert(tt);
                for (int i = 0; i < tagg.Length; i++)
                {
                    DAL.Tag.insert(tagg[i]);
                    DAL.Tag.insertTagtt(tagg[i], DAL.TinTuc.getIDTT());
                }
                ViewBag.listTag = DAL.Tag.getTag();
                ViewBag.listDM = DAL.DanhMuc.select(id);
                return RedirectToAction("Index", "Home");

            }
        }


        public ActionResult updateTT(string idTT)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string id = Session["login"].ToString();
                Areas.Models.TinTuc tt = new Models.TinTuc();
                tt = DAL.TinTuc.selectTT(idTT);
                tt.Tag1 = tt.Tag1.Trim();
                ViewBag.listTag = DAL.Tag.getTag();
                //DAL.TinTuc.checkAdmin(id);
                ViewBag.listDM = DAL.DanhMuc.select(id);
                ViewBag.username = "Tiến Thành";
                return View(tt);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult updateTT(string idTT, Areas.Models.TinTuc tt, string selectDM, string url )
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string id = Session["login"].ToString();
                // 
                tt.Id1 = Int32.Parse(idTT);
                tt.DanhMuc1 = Int32.Parse(selectDM);
                if (!String.IsNullOrWhiteSpace(url)) tt.Anh1 = url;
                DAL.TinTuc.update(tt);
                string[] tagg = tt.Tag1.Split(',');
                //DAL.TinTuc.checkAdmin(id);
                DAL.Tag.deteleTagtt(tt.Id1.ToString());
                for (int i = 0; i < tagg.Length; i++)
                {
                    DAL.Tag.insert(tagg[i]);                  
                    DAL.Tag.insertTagtt(tagg[i], tt.Id1.ToString());
                }
                return RedirectToAction("Index", "Home");

            }
        }


    }
}