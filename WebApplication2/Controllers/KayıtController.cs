using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class KayıtController : Controller
    {
        // GET: Kayıt
        ModelKuafor db = new ModelKuafor();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TBLUYE uye)
        {
            if (ModelState.IsValid)
            {
                uye.YETKIID = 2;
                db.TBLUYE.Add(uye);
                db.SaveChanges();
                Session["uyeid"] = uye.UYEID;
                Session["mail"] = uye.EMAIL;

                return Content("<script> alert('KAYDINIZ OLUŞTURULDU !'); window.location = '../Uye/Login'; </script>");

            }

            else
            {
                ModelState.AddModelError("Kayıt", "Boş Alanları Doldurunuz");
            }
            return View(uye);
        }
    }
}