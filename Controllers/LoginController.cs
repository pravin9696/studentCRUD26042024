using studentCRUD26042024.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studentCRUD26042024.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmpLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmpLogin(LoginModel lm)
        {
            DB220424Entities dbo=new DB220424Entities();
            var login = dbo.tblLogins.FirstOrDefault(x => x.userid == lm.userid && x.password == lm.password);
            if (login == null)
            {
                ViewBag.msg = "Invlid user ID or Password";
                return View();
            }
            else
            {
                return RedirectToAction("index","student");
            }
        }
        public ActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signup(LoginModel lm)
        {
            DB220424Entities dbo = new DB220424Entities();

            try
            {

            
            var login = dbo.tblLogins.FirstOrDefault(x => x.userid == lm.userid);
            //if (login != null)
            //{
            //    ViewBag.msg = "User ID exiest....";
            //    return View();
            //}

                tblLogin lg = new tblLogin();
            lg.userid = lm.userid;
            lg.password = lm.password;
            lg.id = lm.id;

            dbo.tblLogins.Add(lg);
            int n=dbo.SaveChanges();
            if(n>0)
            {
                return RedirectToAction("EmpLogin");
            }
            else
            {
                ViewBag.msg = "Signup  Error.....";
                return View();
            }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("userid", "Duplicate USer ID found..");
                return View();
                throw;
            }


        }
    }
}