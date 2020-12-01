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
    public class NhapXuatTonsController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: Admin/NhapXuatTons
        public ActionResult Index()
        {
            var nhapXuatTons = db.NhapXuatTons.Include(n => n.VatTu);
            return View(nhapXuatTons.ToList());
        }

        // GET: Admin/NhapXuatTons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapXuatTon nhapXuatTon = db.NhapXuatTons.Find(id);
            if (nhapXuatTon == null)
            {
                return HttpNotFound();
            }
            return View(nhapXuatTon);
        }

        // GET: Admin/NhapXuatTons/Create
        public ActionResult Create()
        {
            ViewBag.VatTu_id = new SelectList(db.VatTus, "id", "TenVatTu");
            return View();
        }

        // POST: Admin/NhapXuatTons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nhap,Xuat,Ton,VatTu_id")] NhapXuatTon nhapXuatTon)
        {
            if (ModelState.IsValid)
            {
                db.NhapXuatTons.Add(nhapXuatTon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VatTu_id = new SelectList(db.VatTus, "id", "TenVatTu", nhapXuatTon.VatTu_id);
            return View(nhapXuatTon);
        }

        // GET: Admin/NhapXuatTons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapXuatTon nhapXuatTon = db.NhapXuatTons.Find(id);
            if (nhapXuatTon == null)
            {
                return HttpNotFound();
            }
            ViewBag.VatTu_id = new SelectList(db.VatTus, "id", "TenVatTu", nhapXuatTon.VatTu_id);
            return View(nhapXuatTon);
        }

        // POST: Admin/NhapXuatTons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nhap,Xuat,Ton,VatTu_id")] NhapXuatTon nhapXuatTon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhapXuatTon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VatTu_id = new SelectList(db.VatTus, "id", "TenVatTu", nhapXuatTon.VatTu_id);
            return View(nhapXuatTon);
        }

        // GET: Admin/NhapXuatTons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapXuatTon nhapXuatTon = db.NhapXuatTons.Find(id);
            if (nhapXuatTon == null)
            {
                return HttpNotFound();
            }
            return View(nhapXuatTon);
        }

        // POST: Admin/NhapXuatTons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhapXuatTon nhapXuatTon = db.NhapXuatTons.Find(id);
            db.NhapXuatTons.Remove(nhapXuatTon);
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
