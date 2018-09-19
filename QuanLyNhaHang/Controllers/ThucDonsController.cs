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
    public class ThucDonsController : Controller
    {
        private NhaHangContext db = new NhaHangContext();

        // GET: ThucDons
        public ActionResult Index()
        {
            return View(db.ThucDons.ToList());
        }

        // GET: ThucDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucDon thucDon = db.ThucDons.Find(id);
            if (thucDon == null)
            {
                return HttpNotFound();
            }
            return View(thucDon);
        }

        // GET: ThucDons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThucDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDThucDon,TenThucDon,HinhThucDon,MoTa,Gia,PhanTramKM,SoLuongKhach")] ThucDon thucDon)
        {
            if (ModelState.IsValid)
            {
                db.ThucDons.Add(thucDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thucDon);
        }

        // GET: ThucDons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucDon thucDon = db.ThucDons.Find(id);
            if (thucDon == null)
            {
                return HttpNotFound();
            }
            return View(thucDon);
        }

        // POST: ThucDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDThucDon,TenThucDon,HinhThucDon,MoTa,Gia,PhanTramKM,SoLuongKhach")] ThucDon thucDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thucDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thucDon);
        }

        // GET: ThucDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucDon thucDon = db.ThucDons.Find(id);
            if (thucDon == null)
            {
                return HttpNotFound();
            }
            return View(thucDon);
        }

        // POST: ThucDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThucDon thucDon = db.ThucDons.Find(id);
            db.ThucDons.Remove(thucDon);
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
