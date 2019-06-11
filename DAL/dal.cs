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
    }
}
