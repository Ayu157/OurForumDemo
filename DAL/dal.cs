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
using Newtonsoft.Json;
using Log;

namespace DAL
{

    public class Dal
    {
        public List<AllInfo> GetInvitation()//获取帖子的信息
        {
            Log.FileLogService.Instance.Info("调用一次帖子的显示");
            using (IDbConnection conn = Commond.SqlConnection())
            {
                var data = conn.Query<AllInfo>("select *  from UserInfo a inner join Invitation b on a.User_GuId=b.Inv_UserGuId").ToList();
                return data;
            }
        }
        public string GetXZInvitation(string IguId)
        {
            try
            {
                Log.FileLogService.Instance.Info("查询帖子详细信息，Id=" + IguId + "");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    var da = conn.Query<AllInfo>("  select *  from UserInfo a inner join Invitation b on a.User_GuId=b.Inv_UserGuId where b.Inv_GuId='" + IguId + "'");
                    var data = JsonConvert.SerializeObject(da);
                    return data;
                }
            }
            catch (Exception)
            {
                Log.FileLogService.Instance.Error("查询帖子详细信息失败！Id=" + IguId + "");
                throw;
            }
        }
        public string GetComment(string guId)
        {
            try
            {
                Log.FileLogService.Instance.Info("查询评论信息，Id=" + guId + "");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    var da = conn.Query<AllInfo>("select *  from UserInfo a inner join Comment b on a.User_GuId=b.Com_UserGuId where b.Com_InvGuId ='" + guId + "'");
                    var data = JsonConvert.SerializeObject(da);
                    return data;
                }
            }
            catch (Exception)
            {
                Log.FileLogService.Instance.Error("查询评论信息失败！Id=" + guId + "");
                throw;
            }
        }

    }
}
