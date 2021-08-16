using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EregistationController : Controller
    {
        private EmpLoyeeManaGementEntities db = new EmpLoyeeManaGementEntities();

        // GET: Eregistation
        public ActionResult Index()
        {
            var eregistations = db.Eregistations.Include(e => e.batch).Include(e => e.SalaryD);
            return View(eregistations.ToList());
        }

        // GET: Eregistation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eregistation eregistation = db.Eregistations.Find(id);
            if (eregistation == null)
            {
                return HttpNotFound();
            }
            return View(eregistation);
        }

        // GET: Eregistation/Create
        public ActionResult Create()
        {
            ViewBag.Batch_Id = new SelectList(db.batches, "Id", "Batch_Id");
            ViewBag.Salary_Id = new SelectList(db.SalaryDs, "Id", "Department");
            return View();
        }

        // POST: Eregistation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,CNIC,Batch_Id,Salary_Id,TelNo,Address,District")] Eregistation eregistation)
        {
            if (ModelState.IsValid)
            {
                db.Eregistations.Add(eregistation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Batch_Id = new SelectList(db.batches, "Id", "Batch_Id", eregistation.Batch_Id);
            ViewBag.Salary_Id = new SelectList(db.SalaryDs, "Id", "Department", eregistation.Salary_Id);
            return View(eregistation);
        }

        // GET: Eregistation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eregistation eregistation = db.Eregistations.Find(id);
            if (eregistation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Batch_Id = new SelectList(db.batches, "Id", "Batch_Id", eregistation.Batch_Id);
            ViewBag.Salary_Id = new SelectList(db.SalaryDs, "Id", "Department", eregistation.Salary_Id);
            return View(eregistation);
        }

        // POST: Eregistation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,CNIC,Batch_Id,Salary_Id,TelNo,Address,District")] Eregistation eregistation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eregistation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Batch_Id = new SelectList(db.batches, "Id", "Batch_Id", eregistation.Batch_Id);
            ViewBag.Salary_Id = new SelectList(db.SalaryDs, "Id", "Department", eregistation.Salary_Id);
            return View(eregistation);
        }

        // GET: Eregistation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eregistation eregistation = db.Eregistations.Find(id);
            if (eregistation == null)
            {
                return HttpNotFound();
            }
            return View(eregistation);
        }

        // POST: Eregistation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eregistation eregistation = db.Eregistations.Find(id);
            db.Eregistations.Remove(eregistation);
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
