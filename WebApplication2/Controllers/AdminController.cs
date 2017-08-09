using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ModelKuafor db = new ModelKuafor();

        public ActionResult AdminPage()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["admin"] = null;
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }
    }
}