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
    public class DDHsController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: Admin/DDHs
        public ActionResult Index()
        {
            var dDHs = db.DDHs.Include(d => d.KhachHang).Include(d => d.NVGiaoHang);
            return View(dDHs.ToList());
        }

        // GET: Admin/DDHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DDH dDH = db.DDHs.Find(id);
            if (dDH == null)
            {
                return HttpNotFound();
            }
            return View(dDH);
        }

        // GET: Admin/DDHs/Create
        public ActionResult Create()
        {
            ViewBag.KhachHang_id = new SelectList(db.KhachHangs, "id", "TenKhachHang");
            ViewBag.NVGiaoHang_id = new SelectList(db.NVGiaoHangs, "id", "TenNVGH");
            return View();
        }

        // POST: Admin/DDHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,KhachHang_id,NVGiaoHang_id,NgayDH,TongGia,NoiNhan")] DDH dDH)
        {
            if (ModelState.IsValid)
            {
                db.DDHs.Add(dDH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KhachHang_id = new SelectList(db.KhachHangs, "id", "TenKhachHang", dDH.KhachHang_id);
            ViewBag.NVGiaoHang_id = new SelectList(db.NVGiaoHangs, "id", "TenNVGH", dDH.NVGiaoHang_id);
            return View(dDH);
        }

        // GET: Admin/DDHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DDH dDH = db.DDHs.Find(id);
            if (dDH == null)
            {
                return HttpNotFound();
            }
            ViewBag.KhachHang_id = new SelectList(db.KhachHangs, "id", "TenKhachHang", dDH.KhachHang_id);
            ViewBag.NVGiaoHang_id = new SelectList(db.NVGiaoHangs, "id", "TenNVGH", dDH.NVGiaoHang_id);
            return View(dDH);
        }

        // POST: Admin/DDHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,KhachHang_id,NVGiaoHang_id,NgayDH,TongGia,NoiNhan")] DDH dDH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dDH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KhachHang_id = new SelectList(db.KhachHangs, "id", "TenKhachHang", dDH.KhachHang_id);
            ViewBag.NVGiaoHang_id = new SelectList(db.NVGiaoHangs, "id", "TenNVGH", dDH.NVGiaoHang_id);
            return View(dDH);
        }

        // GET: Admin/DDHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DDH dDH = db.DDHs.Find(id);
            if (dDH == null)
            {
                return HttpNotFound();
            }
            return View(dDH);
        }

        // POST: Admin/DDHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DDH dDH = db.DDHs.Find(id);
            db.DDHs.Remove(dDH);
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
