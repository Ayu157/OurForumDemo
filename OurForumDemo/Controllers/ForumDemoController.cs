using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MODEL;
using BLL;
using Log;
namespace OurForum.Controllers
{
    
    public class ForumDemoController : Controller
    {
        BLL.Bll bll = new Bll();
        // GET: ForumDemo
        ///论坛首页
        public ActionResult Index()
        {
            var data = bll.GetInvitation();
            return View(data);
        }
    }
}