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
    public class ChiTietSlideAnhsController : Controller
    {
        private NhaHangContext db = new NhaHangContext();

        // GET: ChiTietSlideAnhs
        public ActionResult Index()
        {
            var chiTietSlideAnhs = db.ChiTietSlideAnhs.Include(c => c.SlideAnh);
            return View(chiTietSlideAnhs.ToList());
        }

        // GET: ChiTietSlideAnhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSlideAnh chiTietSlideAnh = db.ChiTietSlideAnhs.Find(id);
            if (chiTietSlideAnh == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSlideAnh);
        }

        // GET: ChiTietSlideAnhs/Create
        public ActionResult Create()
        {
            ViewBag.IDSlideAnh = new SelectList(db.SlideAnhs, "IDSlideAnh", "TenSlide");
            return View();
        }

        // POST: ChiTietSlideAnhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDChiTietSlide,UrlHinh,IDSlideAnh,MoTa")] ChiTietSlideAnh chiTietSlideAnh)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietSlideAnhs.Add(chiTietSlideAnh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDSlideAnh = new SelectList(db.SlideAnhs, "IDSlideAnh", "TenSlide", chiTietSlideAnh.IDSlideAnh);
            return View(chiTietSlideAnh);
        }

        // GET: ChiTietSlideAnhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSlideAnh chiTietSlideAnh = db.ChiTietSlideAnhs.Find(id);
            if (chiTietSlideAnh == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDSlideAnh = new SelectList(db.SlideAnhs, "IDSlideAnh", "TenSlide", chiTietSlideAnh.IDSlideAnh);
            return View(chiTietSlideAnh);
        }

        // POST: ChiTietSlideAnhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDChiTietSlide,UrlHinh,IDSlideAnh,MoTa")] ChiTietSlideAnh chiTietSlideAnh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietSlideAnh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDSlideAnh = new SelectList(db.SlideAnhs, "IDSlideAnh", "TenSlide", chiTietSlideAnh.IDSlideAnh);
            return View(chiTietSlideAnh);
        }

        // GET: ChiTietSlideAnhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSlideAnh chiTietSlideAnh = db.ChiTietSlideAnhs.Find(id);
            if (chiTietSlideAnh == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSlideAnh);
        }

        // POST: ChiTietSlideAnhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietSlideAnh chiTietSlideAnh = db.ChiTietSlideAnhs.Find(id);
            db.ChiTietSlideAnhs.Remove(chiTietSlideAnh);
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
