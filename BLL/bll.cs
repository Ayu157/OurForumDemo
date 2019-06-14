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
    }
}
