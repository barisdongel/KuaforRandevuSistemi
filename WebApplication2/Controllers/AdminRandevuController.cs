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
    public class AdminRandevuController : Controller
    {
        private KuaforDB db = new KuaforDB();

        // GET: AdminRandevu
        public ActionResult Index()
        {
            var tBLRANDEVU = db.TBLRANDEVU.Include(t => t.TBLKUAFOR).Include(t => t.TBLRANDEVUSAAT).Include(t => t.TBLUYE);
            return View(tBLRANDEVU.ToList());
        }

        // GET: AdminRandevu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLRANDEVU tBLRANDEVU = db.TBLRANDEVU.Find(id);
            if (tBLRANDEVU == null)
            {
                return HttpNotFound();
            }
            return View(tBLRANDEVU);
        }

        // GET: AdminRandevu/Create
        public ActionResult Create()
        {
            ViewBag.KUAFORID = new SelectList(db.TBLKUAFOR, "KUAFORID", "KUAFORAD");
            ViewBag.RANDEVUSAATID = new SelectList(db.TBLRANDEVUSAAT, "RANDEVUSAATID", "RANDEVUSAATLERI");
            ViewBag.ALANUYEID = new SelectList(db.TBLUYE, "UYEID", "AD");
            return View();
        }

        // POST: AdminRandevu/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RANDEVUID,ALANUYEID,RANDEVUTARIH,RANDEVUSAATID,KUAFORID")] TBLRANDEVU tBLRANDEVU)
        {
            if (ModelState.IsValid)
            {
                db.TBLRANDEVU.Add(tBLRANDEVU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KUAFORID = new SelectList(db.TBLKUAFOR, "KUAFORID", "KUAFORAD", tBLRANDEVU.KUAFORID);
            ViewBag.RANDEVUSAATID = new SelectList(db.TBLRANDEVUSAAT, "RANDEVUSAATID", "RANDEVUSAATLERI", tBLRANDEVU.RANDEVUSAATID);
            ViewBag.ALANUYEID = new SelectList(db.TBLUYE, "UYEID", "AD", tBLRANDEVU.ALANUYEID);
            return View(tBLRANDEVU);
        }

        // GET: AdminRandevu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLRANDEVU tBLRANDEVU = db.TBLRANDEVU.Find(id);
            if (tBLRANDEVU == null)
            {
                return HttpNotFound();
            }
            ViewBag.KUAFORID = new SelectList(db.TBLKUAFOR, "KUAFORID", "KUAFORAD", tBLRANDEVU.KUAFORID);
            ViewBag.RANDEVUSAATID = new SelectList(db.TBLRANDEVUSAAT, "RANDEVUSAATID", "RANDEVUSAATLERI", tBLRANDEVU.RANDEVUSAATID);
            return View(tBLRANDEVU);
        }

        // POST: AdminRandevu/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RANDEVUID,RANDEVUTARIH,RANDEVUSAATID,KUAFORID")] TBLRANDEVU tBLRANDEVU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLRANDEVU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KUAFORID = new SelectList(db.TBLKUAFOR, "KUAFORID", "KUAFORAD", tBLRANDEVU.KUAFORID);
            ViewBag.RANDEVUSAATID = new SelectList(db.TBLRANDEVUSAAT, "RANDEVUSAATID", "RANDEVUSAATLERI", tBLRANDEVU.RANDEVUSAATID);
            return View(tBLRANDEVU);
        }

        // GET: AdminRandevu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLRANDEVU tBLRANDEVU = db.TBLRANDEVU.Find(id);
            if (tBLRANDEVU == null)
            {
                return HttpNotFound();
            }
            return View(tBLRANDEVU);
        }

        // POST: AdminRandevu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBLRANDEVU tBLRANDEVU = db.TBLRANDEVU.Find(id);
            db.TBLRANDEVU.Remove(tBLRANDEVU);
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
