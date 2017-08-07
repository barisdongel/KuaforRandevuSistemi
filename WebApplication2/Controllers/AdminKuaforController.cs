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
    public class AdminKuaforController : Controller
    {
        ModelKuafor db = new ModelKuafor();

        // GET: AdminKuafor
        public ActionResult Index()
        {
            return View(db.TBLKUAFOR.ToList());
        }

        // GET: AdminKuafor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLKUAFOR tBLKUAFOR = db.TBLKUAFOR.Find(id);
            if (tBLKUAFOR == null)
            {
                return HttpNotFound();
            }
            return View(tBLKUAFOR);
        }

        // GET: AdminKuafor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminKuafor/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KUAFORID,KUAFORAD,KUAFORSOYAD,KUAFORYAS,KUAFORNUMARA,KUAFOREMAİL")] TBLKUAFOR tBLKUAFOR)
        {
            if (ModelState.IsValid)
            {
                db.TBLKUAFOR.Add(tBLKUAFOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBLKUAFOR);
        }

        // GET: AdminKuafor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLKUAFOR tBLKUAFOR = db.TBLKUAFOR.Find(id);
            if (tBLKUAFOR == null)
            {
                return HttpNotFound();
            }
            return View(tBLKUAFOR);
        }

        // POST: AdminKuafor/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KUAFORID,KUAFORAD,KUAFORSOYAD,KUAFORYAS,KUAFORNUMARA,KUAFOREMAİL")] TBLKUAFOR tBLKUAFOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLKUAFOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBLKUAFOR);
        }

        // GET: AdminKuafor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLKUAFOR tBLKUAFOR = db.TBLKUAFOR.Find(id);
            if (tBLKUAFOR == null)
            {
                return HttpNotFound();
            }
            return View(tBLKUAFOR);
        }

        // POST: AdminKuafor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBLKUAFOR tBLKUAFOR = db.TBLKUAFOR.Find(id);
            db.TBLKUAFOR.Remove(tBLKUAFOR);
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
