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
    public class DanhGiaMonAnsController : Controller
    {
        private NhaHangContext db = new NhaHangContext();

        // GET: DanhGiaMonAns
        public ActionResult Index()
        {
            var danhGiaMonAns = db.DanhGiaMonAns.Include(d => d.MonAn).Include(d => d.NguoiDung);
            return View(danhGiaMonAns.ToList());
        }

        // GET: DanhGiaMonAns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGiaMonAn danhGiaMonAn = db.DanhGiaMonAns.Find(id);
            if (danhGiaMonAn == null)
            {
                return HttpNotFound();
            }
            return View(danhGiaMonAn);
        }

        // GET: DanhGiaMonAns/Create
        public ActionResult Create()
        {
            ViewBag.IDMonAn = new SelectList(db.MonAns, "IDMonAn", "TenMonAn");
            ViewBag.EmailNguoiDung = new SelectList(db.NguoiDungs, "EmailNguoiDung", "TenNguoiDung");
            return View();
        }

        // POST: DanhGiaMonAns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMonAn,EmailNguoiDung,NoiDung,DiemDanhGia")] DanhGiaMonAn danhGiaMonAn)
        {
            if (ModelState.IsValid)
            {
                db.DanhGiaMonAns.Add(danhGiaMonAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMonAn = new SelectList(db.MonAns, "IDMonAn", "TenMonAn", danhGiaMonAn.IDMonAn);
            ViewBag.EmailNguoiDung = new SelectList(db.NguoiDungs, "EmailNguoiDung", "TenNguoiDung", danhGiaMonAn.EmailNguoiDung);
            return View(danhGiaMonAn);
        }

        // GET: DanhGiaMonAns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGiaMonAn danhGiaMonAn = db.DanhGiaMonAns.Find(id);
            if (danhGiaMonAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMonAn = new SelectList(db.MonAns, "IDMonAn", "TenMonAn", danhGiaMonAn.IDMonAn);
            ViewBag.EmailNguoiDung = new SelectList(db.NguoiDungs, "EmailNguoiDung", "TenNguoiDung", danhGiaMonAn.EmailNguoiDung);
            return View(danhGiaMonAn);
        }

        // POST: DanhGiaMonAns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMonAn,EmailNguoiDung,NoiDung,DiemDanhGia")] DanhGiaMonAn danhGiaMonAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhGiaMonAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMonAn = new SelectList(db.MonAns, "IDMonAn", "TenMonAn", danhGiaMonAn.IDMonAn);
            ViewBag.EmailNguoiDung = new SelectList(db.NguoiDungs, "EmailNguoiDung", "TenNguoiDung", danhGiaMonAn.EmailNguoiDung);
            return View(danhGiaMonAn);
        }

        // GET: DanhGiaMonAns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGiaMonAn danhGiaMonAn = db.DanhGiaMonAns.Find(id);
            if (danhGiaMonAn == null)
            {
                return HttpNotFound();
            }
            return View(danhGiaMonAn);
        }

        // POST: DanhGiaMonAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhGiaMonAn danhGiaMonAn = db.DanhGiaMonAns.Find(id);
            db.DanhGiaMonAns.Remove(danhGiaMonAn);
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
