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
    public class SlideAnhsController : Controller
    {
        private NhaHangContext db = new NhaHangContext();

        // GET: SlideAnhs
        public ActionResult Index()
        {
            return View(db.SlideAnhs.ToList());
        }

        // GET: SlideAnhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlideAnh slideAnh = db.SlideAnhs.Find(id);
            if (slideAnh == null)
            {
                return HttpNotFound();
            }
            return View(slideAnh);
        }

        // GET: SlideAnhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlideAnhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSlideAnh,TenSlide")] SlideAnh slideAnh)
        {
            if (ModelState.IsValid)
            {
                db.SlideAnhs.Add(slideAnh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slideAnh);
        }

        // GET: SlideAnhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlideAnh slideAnh = db.SlideAnhs.Find(id);
            if (slideAnh == null)
            {
                return HttpNotFound();
            }
            return View(slideAnh);
        }

        // POST: SlideAnhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSlideAnh,TenSlide")] SlideAnh slideAnh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slideAnh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slideAnh);
        }

        // GET: SlideAnhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SlideAnh slideAnh = db.SlideAnhs.Find(id);
            if (slideAnh == null)
            {
                return HttpNotFound();
            }
            return View(slideAnh);
        }

        // POST: SlideAnhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SlideAnh slideAnh = db.SlideAnhs.Find(id);
            db.SlideAnhs.Remove(slideAnh);
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
