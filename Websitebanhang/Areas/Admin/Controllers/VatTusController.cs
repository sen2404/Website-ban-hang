using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Websitebanhang.Models;

namespace Websitebanhang.Areas.Admin.Controllers
{
    public class VatTusController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: Admin/VatTus
        public ActionResult Index()
        {
            return View(db.VatTus.ToList());
        }

        // GET: Admin/VatTus/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTu vatTu = db.VatTus.Find(id);
            if (vatTu == null)
            {
                return HttpNotFound();
            }
            return View(vatTu);
        }

        // GET: Admin/VatTus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/VatTus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TenVatTu,DonGia,DonViTinh,SoLuong")] VatTu vatTu)
        {
            if (ModelState.IsValid)
            {
                db.VatTus.Add(vatTu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vatTu);
        }

        // GET: Admin/VatTus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTu vatTu = db.VatTus.Find(id);
            if (vatTu == null)
            {
                return HttpNotFound();
            }
            return View(vatTu);
        }

        // POST: Admin/VatTus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TenVatTu,DonGia,DonViTinh,SoLuong")] VatTu vatTu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vatTu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vatTu);
        }

        // GET: Admin/VatTus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VatTu vatTu = db.VatTus.Find(id);
            if (vatTu == null)
            {
                return HttpNotFound();
            }
            return View(vatTu);
        }

        // POST: Admin/VatTus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VatTu vatTu = db.VatTus.Find(id);
            db.VatTus.Remove(vatTu);
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
