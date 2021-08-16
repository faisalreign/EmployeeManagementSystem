using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class LoginController : Controller
    {
        EmpLoyeeManaGementEntities db = new EmpLoyeeManaGementEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objchk)
        {

            if (ModelState.IsValid)
            {
                using (EmpLoyeeManaGementEntities db = new EmpLoyeeManaGementEntities())
                {
                    //var obj = db.users.Where(a >= a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();

                    var obj = db.users.Where(a => a.UserName.Equals(objchk.UserName) && a.Password.Equals(objchk.Password)).FirstOrDefault();


                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {

                        ModelState.AddModelError("", "The UserName or Password Incorrect");
                    }

                }

            }
            return View(objchk);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");

        }
    }
}