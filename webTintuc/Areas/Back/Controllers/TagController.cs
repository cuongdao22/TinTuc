using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace webTintuc.Areas.Back.Controllers
{
    public class TagController : Controller
    {
        // GET: Back/Tag
        public ActionResult Index(int? page)
        {
            Areas.Models.Tag dm = new Models.Tag();
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (page == null) page = 1;
                ViewBag.username = "Tiến Thành";
                List<Areas.Models.Tag> list = DAL.Tag.getALLTag();
                IEnumerable<Areas.Models.Tag> l = list.OrderByDescending(x => x.TenTag);
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


                return View();

            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Areas.Models.Tag tag)
        {
            Areas.Models.DanhMuc tin = new Models.DanhMuc();
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (DAL.Tag.checkTag(tag.TenTag) > 0)
                {
                    ModelState.AddModelError("", "Đã tồn tại");
                    return View(tag);
                }
                DAL.Tag.insert(tag.TenTag, tag.Url);
                return RedirectToAction("Index", "Tag");

            }

        }

        public ActionResult Update(string id)
        {
            Areas.Models.Tag tag = new Models.Tag();
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                tag = DAL.Tag.getTag(id);
                return View(tag);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Areas.Models.Tag tag)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
               
                DAL.Tag.update(tag.TenTag, tag.Url);
                return RedirectToAction("Index", "Tag");
            }

        }
    }
}