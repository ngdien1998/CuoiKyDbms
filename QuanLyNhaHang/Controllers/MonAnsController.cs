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
    public class MonAnsController : Controller
    {
        private NhaHangContext db = new NhaHangContext();

        // GET: MonAns
        public ActionResult Index()
        {
            var monAns = db.MonAns.Include(m => m.LoaiMonAn).Include(m => m.ThucDon);
            return View(monAns.ToList());
        }

        // GET: MonAns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            return View(monAn);
        }

        // GET: MonAns/Create
        public ActionResult Create()
        {
            ViewBag.IDLoaiMonAn = new SelectList(db.LoaiMonAns, "LoaiMonAn1", "TenLoaiMonAn");
            ViewBag.IDThucDon = new SelectList(db.ThucDons, "IDThucDon", "TenThucDon");
            return View();
        }

        // POST: MonAns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMonAn,TenMonAn,DonViTinh,MoTa,MoTaChiTiet,Gia,NgayCapNhat,PhanTramKM,IDLoaiMonAn,IDThucDon")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                db.MonAns.Add(monAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLoaiMonAn = new SelectList(db.LoaiMonAns, "LoaiMonAn1", "TenLoaiMonAn", monAn.IDLoaiMonAn);
            ViewBag.IDThucDon = new SelectList(db.ThucDons, "IDThucDon", "TenThucDon", monAn.IDThucDon);
            return View(monAn);
        }

        // GET: MonAns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLoaiMonAn = new SelectList(db.LoaiMonAns, "LoaiMonAn1", "TenLoaiMonAn", monAn.IDLoaiMonAn);
            ViewBag.IDThucDon = new SelectList(db.ThucDons, "IDThucDon", "TenThucDon", monAn.IDThucDon);
            return View(monAn);
        }

        // POST: MonAns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMonAn,TenMonAn,DonViTinh,MoTa,MoTaChiTiet,Gia,NgayCapNhat,PhanTramKM,IDLoaiMonAn,IDThucDon")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLoaiMonAn = new SelectList(db.LoaiMonAns, "LoaiMonAn1", "TenLoaiMonAn", monAn.IDLoaiMonAn);
            ViewBag.IDThucDon = new SelectList(db.ThucDons, "IDThucDon", "TenThucDon", monAn.IDThucDon);
            return View(monAn);
        }

        // GET: MonAns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            return View(monAn);
        }

        // POST: MonAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonAn monAn = db.MonAns.Find(id);
            db.MonAns.Remove(monAn);
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
