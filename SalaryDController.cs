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
    public class SalaryDController : Controller
    {
        private EmpLoyeeManaGementEntities db = new EmpLoyeeManaGementEntities();

        // GET: SalaryD
        public ActionResult Index()
        {
            return View(db.SalaryDs.ToList());
        }

        // GET: SalaryD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryD salaryD = db.SalaryDs.Find(id);
            if (salaryD == null)
            {
                return HttpNotFound();
            }
            return View(salaryD);
        }

        // GET: SalaryD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalaryD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Department,WorkingDay,Leaves,TotalSalary")] SalaryD salaryD)
        {
            if (ModelState.IsValid)
            {
                db.SalaryDs.Add(salaryD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salaryD);
        }

        // GET: SalaryD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryD salaryD = db.SalaryDs.Find(id);
            if (salaryD == null)
            {
                return HttpNotFound();
            }
            return View(salaryD);
        }

        // POST: SalaryD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Department,WorkingDay,Leaves,TotalSalary")] SalaryD salaryD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salaryD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salaryD);
        }

        // GET: SalaryD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryD salaryD = db.SalaryDs.Find(id);
            if (salaryD == null)
            {
                return HttpNotFound();
            }
            return View(salaryD);
        }

        // POST: SalaryD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalaryD salaryD = db.SalaryDs.Find(id);
            db.SalaryDs.Remove(salaryD);
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
