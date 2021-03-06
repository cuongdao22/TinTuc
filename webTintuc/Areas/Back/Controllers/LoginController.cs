﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webTintuc.Areas.Back.Controllers
{
    public class LoginController : Controller
    {
        // GET: Front/Login
        public ActionResult Index()
        {
            if (Session["login"] == null)
            {

            }
            else
            {

                return RedirectToAction("Index", "Home");
            }
           
            return View();
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string username, string pass)
        {
            int kq;
            if (Int32.TryParse(username, out kq))
            {
                kq = DAL.Login.login(username, pass);
            }
            else kq = 0;
            
            if (kq != 0)
            {
                Areas.Models.NhanVien nv = new Areas.Models.NhanVien();
                nv = DAL.Login.getauthority(username);
                Session["login"] = username;
                //return RedirectToAction("Index", "Home", new { id = "100" });
                return RedirectToAction("Index", "Home",new { id = nv.Id});

            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không thành công");
            }
           
            return View();
        }
    }
}