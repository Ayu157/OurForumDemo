using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MODEL;
using BLL;
namespace OurForumDemo.Controllers
{
    
    public class ForumDemoController : Controller
    {
        BLL.Bll bll = new Bll();
        // GET: ForumDemo
        public ActionResult Index()
        {
            var data = bll.GetInvitation();
            return View(data);
        }

    }
}