using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyNhaHang.Models.DataModels;

namespace QuanLyNhaHang.Controllers
{
    public class DatHangOnlinesController : Controller
    {
        private NhaHangContext db = new NhaHangContext();

        // GET: DatHangOnlines
        public ActionResult Index()
        {
            var datHangOnlines = db.DatHangOnlines.Include(d => d.NguoiDung).Include(d => d.NhanVien);
            return View(datHangOnlines.ToList());
        }

        // GET: DatHangOnlines/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatHangOnline datHangOnline = db.DatHangOnlines.Find(id);
            if (datHangOnline == null)
            {
                return HttpNotFound();
            }
            return View(datHangOnline);
        }

        // GET: DatHangOnlines/Create
        public ActionResult Create()
        {
            ViewBag.EmailNguoiDung = new SelectList(db.NguoiDungs, "EmailNguoiDung", "TenNguoiDung");
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "TenNhanVien");
            return View();
        }

        // POST: DatHangOnlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNhanVien,EmailNguoiDung,NgayDatHang,GhiChu")] DatHangOnline datHangOnline)
        {
            if (ModelState.IsValid)
            {
                db.DatHangOnlines.Add(datHangOnline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmailNguoiDung = new SelectList(db.NguoiDungs, "EmailNguoiDung", "TenNguoiDung", datHangOnline.EmailNguoiDung);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "TenNhanVien", datHangOnline.IDNhanVien);
            return View(datHangOnline);
        }

        // GET: DatHangOnlines/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatHangOnline datHangOnline = db.DatHangOnlines.Find(id);
            if (datHangOnline == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmailNguoiDung = new SelectList(db.NguoiDungs, "EmailNguoiDung", "TenNguoiDung", datHangOnline.EmailNguoiDung);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "TenNhanVien", datHangOnline.IDNhanVien);
            return View(datHangOnline);
        }

        // POST: DatHangOnlines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNhanVien,EmailNguoiDung,NgayDatHang,GhiChu")] DatHangOnline datHangOnline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datHangOnline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmailNguoiDung = new SelectList(db.NguoiDungs, "EmailNguoiDung", "TenNguoiDung", datHangOnline.EmailNguoiDung);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "TenNhanVien", datHangOnline.IDNhanVien);
            return View(datHangOnline);
        }

        // GET: DatHangOnlines/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatHangOnline datHangOnline = db.DatHangOnlines.Find(id);
            if (datHangOnline == null)
            {
                return HttpNotFound();
            }
            return View(datHangOnline);
        }

        // POST: DatHangOnlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DatHangOnline datHangOnline = db.DatHangOnlines.Find(id);
            db.DatHangOnlines.Remove(datHangOnline);
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
