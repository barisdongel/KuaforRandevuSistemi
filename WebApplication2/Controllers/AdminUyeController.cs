using System;
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
    public class AdminUyeController : Controller
    {
        KuaforDB db = new KuaforDB();

        // GET: AdminUye
        public ActionResult Index()
        {
            var tBLUYE = db.TBLUYE.Include(t => t.TBLYETKI);
            return View(tBLUYE.OrderByDescending(u=>u.UYEID).ToList());
        }

        // GET: AdminUye/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLUYE tBLUYE = db.TBLUYE.Find(id);
            if (tBLUYE == null)
            {
                return HttpNotFound();
            }
            return View(tBLUYE);
        }

        // GET: AdminUye/Create
        public ActionResult Create()
        {
            ViewBag.YETKIID = new SelectList(db.TBLYETKI, "YETKIID", "YETKIAD");
            return View();
        }

        // POST: AdminUye/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UYEID,AD,SOYAD,NUMARA,EMAIL,SIFRE,YETKIID")] TBLUYE tBLUYE)
        {
            if (ModelState.IsValid)
            {
                db.TBLUYE.Add(tBLUYE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.YETKIID = new SelectList(db.TBLYETKI, "YETKIID", "YETKIAD", tBLUYE.YETKIID);
            return View(tBLUYE);
        }

        // GET: denemecontroller/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLUYE tBLUYE = db.TBLUYE.Find(id);
            if (tBLUYE == null)
            {
                return HttpNotFound();
            }
            ViewBag.YETKIID = new SelectList(db.TBLYETKI, "YETKIID", "YETKIAD", tBLUYE.YETKIID);
            return View(tBLUYE);
        }

        // POST: denemecontroller/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UYEID,AD,SOYAD,NUMARA,EMAIL,SIFRE,YETKIID")] TBLUYE tBLUYE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLUYE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YETKIID = new SelectList(db.TBLYETKI, "YETKIID", "YETKIAD", tBLUYE.YETKIID);
            return View(tBLUYE);
        }

        // GET: AdminUye/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLUYE tBLUYE = db.TBLUYE.Find(id);
            if (tBLUYE == null)
            {
                return HttpNotFound();
            }
            return View(tBLUYE);
        }

        // POST: AdminUye/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBLUYE tBLUYE = db.TBLUYE.Find(id);
            db.TBLUYE.Remove(tBLUYE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
