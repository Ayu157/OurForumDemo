using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BLL
{
    public class Bll
    {
        DAL.Dal dal = new Dal();
        public List<AllInfo> GetInvitation()
        {
            return dal.GetInvitation();
        }
        //登录
        public int Login(string name, string pwd)
        {
            return dal.Login(name,pwd);
        }
        //注册
        public int Register(string name, string pwd, string code)
        {
            return dal.Register(name, pwd, code);
        }
    }
}
