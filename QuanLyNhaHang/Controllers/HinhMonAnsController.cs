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
    public class HinhMonAnsController : Controller
    {
        private NhaHangContext db = new NhaHangContext();

        // GET: HinhMonAns
        public ActionResult Index()
        {
            var hinhMonAns = db.HinhMonAns.Include(h => h.MonAn);
            return View(hinhMonAns.ToList());
        }

        // GET: HinhMonAns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhMonAn hinhMonAn = db.HinhMonAns.Find(id);
            if (hinhMonAn == null)
            {
                return HttpNotFound();
            }
            return View(hinhMonAn);
        }

        // GET: HinhMonAns/Create
        public ActionResult Create()
        {
            ViewBag.IDMonAn = new SelectList(db.MonAns, "IDMonAn", "TenMonAn");
            return View();
        }

        // POST: HinhMonAns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMonAn,UrlHinh")] HinhMonAn hinhMonAn)
        {
            if (ModelState.IsValid)
            {
                db.HinhMonAns.Add(hinhMonAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMonAn = new SelectList(db.MonAns, "IDMonAn", "TenMonAn", hinhMonAn.IDMonAn);
            return View(hinhMonAn);
        }

        // GET: HinhMonAns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhMonAn hinhMonAn = db.HinhMonAns.Find(id);
            if (hinhMonAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMonAn = new SelectList(db.MonAns, "IDMonAn", "TenMonAn", hinhMonAn.IDMonAn);
            return View(hinhMonAn);
        }

        // POST: HinhMonAns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMonAn,UrlHinh")] HinhMonAn hinhMonAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hinhMonAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMonAn = new SelectList(db.MonAns, "IDMonAn", "TenMonAn", hinhMonAn.IDMonAn);
            return View(hinhMonAn);
        }

        // GET: HinhMonAns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhMonAn hinhMonAn = db.HinhMonAns.Find(id);
            if (hinhMonAn == null)
            {
                return HttpNotFound();
            }
            return View(hinhMonAn);
        }

        // POST: HinhMonAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HinhMonAn hinhMonAn = db.HinhMonAns.Find(id);
            db.HinhMonAns.Remove(hinhMonAn);
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
