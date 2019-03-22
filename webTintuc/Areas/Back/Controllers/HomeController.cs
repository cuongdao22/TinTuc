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
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            List<Areas.Front.Models.TinTuc> list = DAL.TinTuc.selectList();
            IEnumerable < Areas.Front.Models.TinTuc > l = list.OrderByDescending(x => x.Id1 );
            int pageNumber = (page ?? 1);
            return View(l.ToPagedList(pageNumber,5));
        }
    }
}