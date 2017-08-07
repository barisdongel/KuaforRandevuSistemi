using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{

    public class UyeController : Controller
    {

        // GET: Uye
        ModelKuafor db = new ModelKuafor();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TBLUYE uye)
        {
            var login = db.TBLUYE.Where(u => u.EMAIL == uye.EMAIL).SingleOrDefault();
            if (login != null)
            {

                if (login.EMAIL == uye.EMAIL && login.SIFRE == uye.SIFRE)
                {
                    Session["uyeid"] = login.UYEID;
                    Session["mail"] = login.EMAIL;
                    Session["yetkiid"] = login.YETKIID;
                    if (login.YETKIID == 1)
                    {
                        return RedirectToAction("AdminPage", "Admin");
                    }
                    else
                    {

                        return RedirectToAction("Create", "UyeRandevu");
                    }

                }
                else
                {
                    Response.Write("<script>alert('HATALI GİRİŞ !')</script>");
                    return View();
                }
            }
            else
            {
                Response.Write("<script>alert('HATALI GİRİŞ !')</script>");
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["uyeid"] = null;
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }
    }
}