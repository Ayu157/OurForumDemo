using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
using Log;
namespace BLL
{
    public class Bll
    {
        DAL.Dal dal = new Dal();
        /// <summary>
        /// 这是现实
        /// </summary>
        /// <returns></returns>
        public List<AllInfo> GetInvitation()
        {
            return dal.GetInvitation();
        }
        public string GetXZInvitation(string IguId)
        {
            return dal.GetXZInvitation(IguId);
        }
        public string GetComment(string guId)
        {
            return dal.GetComment(guId);
        }
        //盖楼
        public string GetCommentByUserGu(string guId)
        {
            return dal.GetCommentByUserGu(guId);
        }
        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="ClickPraise">根据用户id查询关系表</param>
        /// <param name="AddComment">修改评论表+1</param>
        /// <param name="DelComment">修改评论表-1</param>
        /// <param name="DelRelationTable">删除关系表</param>
        /// <param name="AddRelationTable">添加关系表</param>
        /// <returns></returns>
        //根据用户id查询关系表
        public bool ClickPraise(int User_Id)
        {
            return dal.ClickPraise(User_Id);
        }
        //修改评论表+1
        public int AddComment(int Com_Id)
        {
            return dal.AddComment(Com_Id);
        }
        //修改评论表-1
        public int DelComment(int Com_Id)
        {
            return dal.DelComment(Com_Id);
        }
        //删除关系表
        public int DelRelationTable(int User_Id)
        {
            return dal.DelRelationTable(User_Id);
        }
        //添加关系表
        public int AddRelationTable(int User_Id, int Com_Id, string Com_InvGuId)
        {
            return dal.AddRelationTable(User_Id, Com_Id, Com_InvGuId);
        }
        //登录
        public int Login(string name, string pwd)
        {
            return dal.Login(name, pwd);
        }
        //注册
        public int Register(string name, string pwd, string code)
        {
            return dal.Register(name, pwd, code);
        }
        //忘记密码
        public int Forget()
        {
            return dal.Forget();

        }
    }
}
