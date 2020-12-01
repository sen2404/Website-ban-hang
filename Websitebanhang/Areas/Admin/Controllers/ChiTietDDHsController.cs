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
    public class ChiTietDDHsController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: Admin/ChiTietDDHs
        public ActionResult Index()
        {
            var chiTietDDHs = db.ChiTietDDHs.Include(c => c.DDH).Include(c => c.VatTu);
            return View(chiTietDDHs.ToList());
        }

        // GET: Admin/ChiTietDDHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDDH chiTietDDH = db.ChiTietDDHs.Find(id);
            if (chiTietDDH == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDDH);
        }

        // GET: Admin/ChiTietDDHs/Create
        public ActionResult Create()
        {
            ViewBag.DDH_id = new SelectList(db.DDHs, "id", "NoiNhan");
            ViewBag.VatTu_id = new SelectList(db.VatTus, "id", "TenVatTu");
            return View();
        }

        // POST: Admin/ChiTietDDHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,DDH_id,VatTu_id,SoLuongMua,DonGia")] ChiTietDDH chiTietDDH)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietDDHs.Add(chiTietDDH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DDH_id = new SelectList(db.DDHs, "id", "NoiNhan", chiTietDDH.DDH_id);
            ViewBag.VatTu_id = new SelectList(db.VatTus, "id", "TenVatTu", chiTietDDH.VatTu_id);
            return View(chiTietDDH);
        }

        // GET: Admin/ChiTietDDHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDDH chiTietDDH = db.ChiTietDDHs.Find(id);
            if (chiTietDDH == null)
            {
                return HttpNotFound();
            }
            ViewBag.DDH_id = new SelectList(db.DDHs, "id", "NoiNhan", chiTietDDH.DDH_id);
            ViewBag.VatTu_id = new SelectList(db.VatTus, "id", "TenVatTu", chiTietDDH.VatTu_id);
            return View(chiTietDDH);
        }

        // POST: Admin/ChiTietDDHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,DDH_id,VatTu_id,SoLuongMua,DonGia")] ChiTietDDH chiTietDDH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietDDH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DDH_id = new SelectList(db.DDHs, "id", "NoiNhan", chiTietDDH.DDH_id);
            ViewBag.VatTu_id = new SelectList(db.VatTus, "id", "TenVatTu", chiTietDDH.VatTu_id);
            return View(chiTietDDH);
        }

        // GET: Admin/ChiTietDDHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDDH chiTietDDH = db.ChiTietDDHs.Find(id);
            if (chiTietDDH == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDDH);
        }

        // POST: Admin/ChiTietDDHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietDDH chiTietDDH = db.ChiTietDDHs.Find(id);
            db.ChiTietDDHs.Remove(chiTietDDH);
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
