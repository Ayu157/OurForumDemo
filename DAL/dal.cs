using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data;
using MODEL;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class Dal
    {
        public List<AllInfo> GetInvitation()//获取帖子的信息
        {
            using (IDbConnection conn = Commond.SqlConnection())
            {
                var data = conn.Query<AllInfo>("select *  from UserInfo a inner join Invitation b on a.User_GuId=b.Inv_UserGuId").ToList();
                return data;
            }
        }
        //登录
        public int Login(string name,string pwd)
        {
            using (IDbConnection conn = Commond.SqlConnection())
            {
                int statu = 0;//状态
                var user = conn.Query<AllInfo>("select * from UserInfo");
                foreach (var item in user)
                {
                    if(item.User_LoginName==name && item.User_PassWord==pwd)
                    {
                        statu = 1;
                        break;
                    }
                    else
                    {
                        statu = 0;
                    }
                }
                return statu;
            }
        }
        //注册
        public int Register(string name, string pwd, string code)
        {
            int result = 0;
            using (IDbConnection conn = Commond.SqlConnection())
            {
                string sqlCommandText = string.Format("insert into UserInfo(User_LoginName,User_PassWord,User_Phone)values('{0}','{1}','{2}')",name,pwd,code);
                 result = conn.Execute(sqlCommandText);
            }
            return result;
        }
    }
}
