using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Metrics.Models;

namespace Metrics.Controllers
{
    public class SMARTSOLVEController : Controller
    {
        private MetricEntities db = new MetricEntities();

        // GET: SMARTSOLVE
        public ActionResult Index()
        {
            return View(db.SMARTSOLVEModels.ToList());
        }

        // GET: SMARTSOLVE/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMARTSOLVEModels sMARTSOLVEModels = db.SMARTSOLVEModels.Find(id);
            if (sMARTSOLVEModels == null)
            {
                return HttpNotFound();
            }
            return View(sMARTSOLVEModels);
        }

        // GET: SMARTSOLVE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMARTSOLVE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RPT_DATE,EMP_NO,METRIC_ID,VALUE,Company_ID,MODIFIED_DATE")] SMARTSOLVEModels sMARTSOLVEModels)
        {
            if (ModelState.IsValid)
            {
                db.SMARTSOLVEModels.Add(sMARTSOLVEModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sMARTSOLVEModels);
        }

        // GET: SMARTSOLVE/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMARTSOLVEModels sMARTSOLVEModels = db.SMARTSOLVEModels.Find(id);
            if (sMARTSOLVEModels == null)
            {
                return HttpNotFound();
            }
            return View(sMARTSOLVEModels);
        }

        // POST: SMARTSOLVE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RPT_DATE,EMP_NO,METRIC_ID,VALUE,Company_ID,MODIFIED_DATE")] SMARTSOLVEModels sMARTSOLVEModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMARTSOLVEModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sMARTSOLVEModels);
        }

        // GET: SMARTSOLVE/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMARTSOLVEModels sMARTSOLVEModels = db.SMARTSOLVEModels.Find(id);
            if (sMARTSOLVEModels == null)
            {
                return HttpNotFound();
            }
            return View(sMARTSOLVEModels);
        }

        // POST: SMARTSOLVE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            SMARTSOLVEModels sMARTSOLVEModels = db.SMARTSOLVEModels.Find(id);
            db.SMARTSOLVEModels.Remove(sMARTSOLVEModels);
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
