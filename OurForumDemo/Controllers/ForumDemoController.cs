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
       /// <summary>
       /// 发布帖子
       /// </summary>
       /// <returns></returns>
        public ActionResult AddInvitation()
        {
            return View();
        }
        /// <summary>
        /// 查询详情
        /// </summary>
        /// <returns></returns>
        public ActionResult DetailsInvitation()
        {
            return View();
        }
        public string GetGuInvitation(string guId)
        {
            return bll.GetXZInvitation(guId);
        }
        public string GetComment(string guId)
        {
            var data = bll.GetComment(guId);
            ViewBag.leng = data.Length;
            return data;
        }

    }
}