using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UptLogin;

namespace OurForumDemo.Controllers
{
    public class UptLoginController : Controller
    {
        // GET: UptLogin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UptPwd()
        {
            UptPassword u = new UptPassword();
            if (Request["User_Name"] == null)
            {

            }
            else
            {
                string userName = Request["User_Name"].ToString();
            }
            u.userId = 0;
            return Json(u, JsonRequestBehavior.AllowGet);
        }
    }
}