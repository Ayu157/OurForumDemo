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
        public ActionResult DetailsInvitation(string Com_InvGuId=null)
        {
            if (Com_InvGuId!=null)
            {
                ViewBag.Com_InvGuId = Com_InvGuId;
            }
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
        //盖楼
        public string GetCommentByUserGu(string aguId)
        {
            return bll.GetCommentByUserGu(aguId);
        }
        /// <summary>
        /// 点赞方法
        /// </summary>
        public void ClickPraise(int User_Id, int Com_Id,string Com_InvGuId)
        {
            //根据id查询是否有关系表
            bool i = bll.ClickPraise(User_Id);
            if (i == true)
            {
                //如果没有添加关系表
                int n = bll.AddRelationTable(User_Id, Com_Id, Com_InvGuId);
                if (n > 0)
                {
                    //数加1
                    int n1 = bll.AddComment(Com_Id);
                    if (n1 > 0)
                    {
                        Response.Redirect("/ForumDemo/DetailsInvitation?Com_InvGuId=" + Com_InvGuId);
                    }
                }
            }
            else
            {
                //如果有删除关系表
                int n = bll.DelRelationTable(User_Id);
                if (n > 0)
                {
                    //数减1
                    int n1 = bll.DelComment(Com_Id);
                    if (n1 > 0)
                    {
                        Response.Redirect("/ForumDemo/DetailsInvitation?Com_InvGuId=" + Com_InvGuId);
                    }
                }
            }
        }

    }
}