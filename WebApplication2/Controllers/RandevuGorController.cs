using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RandevuGorController : Controller
    {
        // GET: RandevuGor
        ModelKuafor db = new ModelKuafor();
        public ActionResult Index()
        {
            return View(db.TBLRANDEVU.ToList());
        }
    }
}