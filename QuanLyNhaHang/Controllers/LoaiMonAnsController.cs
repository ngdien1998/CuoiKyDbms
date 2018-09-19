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
    public class LoaiMonAnsController : Controller
    {
        private NhaHangContext db = new NhaHangContext();

        // GET: LoaiMonAns
        public ActionResult Index()
        {
            return View(db.LoaiMonAns.ToList());
        }

        // GET: LoaiMonAns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMonAn loaiMonAn = db.LoaiMonAns.Find(id);
            if (loaiMonAn == null)
            {
                return HttpNotFound();
            }
            return View(loaiMonAn);
        }

        // GET: LoaiMonAns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiMonAns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoaiMonAn1,TenLoaiMonAn,MoTa,HinhLoaiMonAn")] LoaiMonAn loaiMonAn)
        {
            if (ModelState.IsValid)
            {
                db.LoaiMonAns.Add(loaiMonAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiMonAn);
        }

        // GET: LoaiMonAns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMonAn loaiMonAn = db.LoaiMonAns.Find(id);
            if (loaiMonAn == null)
            {
                return HttpNotFound();
            }
            return View(loaiMonAn);
        }

        // POST: LoaiMonAns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoaiMonAn1,TenLoaiMonAn,MoTa,HinhLoaiMonAn")] LoaiMonAn loaiMonAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiMonAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiMonAn);
        }

        // GET: LoaiMonAns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMonAn loaiMonAn = db.LoaiMonAns.Find(id);
            if (loaiMonAn == null)
            {
                return HttpNotFound();
            }
            return View(loaiMonAn);
        }

        // POST: LoaiMonAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiMonAn loaiMonAn = db.LoaiMonAns.Find(id);
            db.LoaiMonAns.Remove(loaiMonAn);
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
