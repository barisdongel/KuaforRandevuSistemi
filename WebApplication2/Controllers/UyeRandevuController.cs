﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UyeRandevuController : Controller
    {
        private KuaforDB db = new KuaforDB();

        public ActionResult Randevular()
        {
            var id = int.Parse(Session["uyeid"].ToString());

            var tBLRANDEVU = db.TBLRANDEVU.Include(t => t.TBLKUAFOR).Include(t => t.TBLRANDEVUSAAT).Include(t => t.TBLUYE).Where(u => u.ALANUYEID == id);

            return View(tBLRANDEVU.ToList());
        }

        // GET: UyeRandevu/Create

        public ActionResult Create()
        {
            ViewBag.KUAFORID = new SelectList(db.TBLKUAFOR, "KUAFORID", "KUAFORAD");
            ViewBag.RANDEVUSAATID = new SelectList(db.TBLRANDEVUSAAT, "RANDEVUSAATID", "RANDEVUSAATLERI");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RANDEVUID,RANDEVUTARIH,RANDEVUSAATID,KUAFORID")] TBLRANDEVU tBLRANDEVU)
        {
            if (ModelState.IsValid)
            {
                tBLRANDEVU.ALANUYEID = int.Parse(Session["uyeid"].ToString());
                db.TBLRANDEVU.Add(tBLRANDEVU);
                db.SaveChanges();
                return Content("<script> alert('RANDEVU TALEBİNİZ ALINDI '); window.location = '../Home/HomePage'; </script>");
            }

            ViewBag.KUAFORID = new SelectList(db.TBLKUAFOR, "KUAFORID", "KUAFORAD", tBLRANDEVU.KUAFORID);
            ViewBag.RANDEVUSAATID = new SelectList(db.TBLRANDEVUSAAT, "RANDEVUSAATID", "RANDEVUSAATLERI", tBLRANDEVU.RANDEVUSAATID);
            return View(tBLRANDEVU);
        }
    }
}
