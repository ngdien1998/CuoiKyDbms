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
    public class BaiVietsController : Controller
    {
        private NhaHangContext db = new NhaHangContext();

        // GET: BaiViets
        public ActionResult Index()
        {
            var baiViets = db.BaiViets.Include(b => b.LoaiBaiViet).Include(b => b.NhanVien);
            return View(baiViets.ToList());
        }

        // GET: BaiViets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // GET: BaiViets/Create
        public ActionResult Create()
        {
            ViewBag.IDLoaiBaiViet = new SelectList(db.LoaiBaiViets, "IDLoai", "TenLoai");
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "TenNhanVien");
            return View();
        }

        // POST: BaiViets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBaiViet,NoiDung,NgayDang,IDNhanVien,IDLoaiBaiViet")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                db.BaiViets.Add(baiViet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLoaiBaiViet = new SelectList(db.LoaiBaiViets, "IDLoai", "TenLoai", baiViet.IDLoaiBaiViet);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "TenNhanVien", baiViet.IDNhanVien);
            return View(baiViet);
        }

        // GET: BaiViets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLoaiBaiViet = new SelectList(db.LoaiBaiViets, "IDLoai", "TenLoai", baiViet.IDLoaiBaiViet);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "TenNhanVien", baiViet.IDNhanVien);
            return View(baiViet);
        }

        // POST: BaiViets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBaiViet,NoiDung,NgayDang,IDNhanVien,IDLoaiBaiViet")] BaiViet baiViet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baiViet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLoaiBaiViet = new SelectList(db.LoaiBaiViets, "IDLoai", "TenLoai", baiViet.IDLoaiBaiViet);
            ViewBag.IDNhanVien = new SelectList(db.NhanViens, "IDNhanVien", "TenNhanVien", baiViet.IDNhanVien);
            return View(baiViet);
        }

        // GET: BaiViets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiViet baiViet = db.BaiViets.Find(id);
            if (baiViet == null)
            {
                return HttpNotFound();
            }
            return View(baiViet);
        }

        // POST: BaiViets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiViet baiViet = db.BaiViets.Find(id);
            db.BaiViets.Remove(baiViet);
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
