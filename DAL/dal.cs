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
        public string GetComment(string guId, int User_Id = 0)
        {
            try
            {
                Log.FileLogService.Instance.Info("查询评论信息，Id=" + guId + "");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    var da = conn.Query<AllInfo>("select *  from UserInfo a inner join Comment b on a.User_GuId=b.Com_UserGuId  where b.Com_InvGuId ='" + guId+"'");
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
        //盖楼
        public string GetCommentByUserGu(string guId)
        {
            try
            {
                Log.FileLogService.Instance.Info("查询盖楼评论信息，Id=" + guId + "");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    var da = conn.Query<AllInfo>("select *  from UserInfo a inner join Comment b on a.User_GuId=b.Com_UserGuId where Com_GuId ='" + guId + "'");
                    var data = JsonConvert.SerializeObject(da);
                    return data;
                }
            }
            catch (Exception)
            {
                Log.FileLogService.Instance.Error("查询盖楼评论信息失败！Id=" + guId + "");
                throw;
            }
        }
        /// <summary>
        /// 点赞方法
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
            using (IDbConnection conn = Commond.SqlConnection())
            {
                var sql = conn.Query<AllInfo>("select * from RelationTable where Rel_UserId="+ User_Id).ToList();
                if (sql.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        //修改评论表+1
        public int AddComment(int Com_Id)
        {
            try
            {
                Log.FileLogService.Instance.Info("修改评论表+1，执行编号为" + Com_Id + "");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    int n = conn.Execute("update Comment set Com_Click=Com_Click+1 where Com_Id=" + Com_Id);
                    return n;
                }
            }
            catch (Exception)
            {
                Log.FileLogService.Instance.Error("修改评论表+1失败！执行编号为" + Com_Id + "");
                throw;
            }
            
        }
        //修改评论表-1
        public int DelComment(int Com_Id)
        {
            try
            {
                Log.FileLogService.Instance.Info("修改评论表-1，执行编号为" + Com_Id + "");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    int n = conn.Execute("update Comment set Com_Click=Com_Click-1 where Com_Id=" + Com_Id);
                    return n;
                }
            }
            catch (Exception)
            {
                Log.FileLogService.Instance.Error("修改评论表-1失败！执行编号为" + Com_Id + "");
                throw;
            }
            
        }
        //删除关系表
        public int DelRelationTable(int User_Id)
        {

            try
            {
                Log.FileLogService.Instance.Info("删除关系表，执行编号为" + User_Id + "");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    int n = conn.Execute("delete from RelationTable where Rel_UserId=" + User_Id);
                    return n;
                }
            }
            catch (Exception)
            {
                Log.FileLogService.Instance.Error("删除关系表，执行编号为" + User_Id + "");
                throw;
            }

        }
        //添加关系表
        public int AddRelationTable(int User_Id, int Com_Id, string Com_InvGuId)
        {
            try
            {
                Log.FileLogService.Instance.Info("添加关系表，执行编号为" + User_Id + "");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    int n = conn.Execute($"insert into RelationTable values(newid(),'{Com_InvGuId}','{Com_Id}','{User_Id}')");
                    return n;
                }
            }
            catch (Exception)
            {
                Log.FileLogService.Instance.Error("添加关系表，执行编号为" + User_Id + "");
                throw;
            }
            
        }

        //登录
        public List<AllInfo> Login(string name, string pwd)
        {
            try
            {
                Log.FileLogService.Instance.Info("登录事件："+name+","+pwd+"成功");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    var user = conn.Query<AllInfo>("select * from UserInfo where User_LoginName='" + name + "' and User_PassWord='" + pwd + "' ").ToList();
                    return user;
                }
            }
            catch (Exception)
            {
                Log.FileLogService.Instance.Error("登录事件：" + name + "," + pwd + "失败");
                throw;
            }
      
        }
        //注册
        public int Register(string name, string pwd, string code)
        {
            int result = 0;
            try
            {
                Log.FileLogService.Instance.Info("注册事件：" + name + "," + pwd + ","+code+"成功");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    string sqlCommandText = string.Format("insert into UserInfo(User_LoginName,User_PassWord,User_Phone)values('{0}','{1}','{2}')", name, pwd, code);
                    result = conn.Execute(sqlCommandText);
                }
            }
            catch (Exception)
            {
                Log.FileLogService.Instance.Error("注册事件：" + name + "," + pwd + ","+code+"失败");
                throw;
            }
            
            return result;
        }
        //忘记密码
        public int Forget(AllInfo all)
        {
            int result = 0;
            try
            {
                Log.FileLogService.Instance.Info("LosePwd事件：成功");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    string sqlCommandText = string.Format("Update UserInfo set User_PassWord ='{0}'  where User_LoginName='{1}'", all.User_PassWord, all.User_LoginName);
                    result = conn.Execute(sqlCommandText);
                }
            }
            catch (Exception)
            {
                Log.FileLogService.Instance.Error("LosePwd事件：失败");
                throw;
            }
            return result;
        }
        //盖楼评论
        public int CommenttoGu(string userGu, string invGu, string comGu,string comBody)
        {
            int result = 0;
            try
            {
                Log.FileLogService.Instance.Info("盖楼人" + userGu + ",帖子" + invGu + "," + comGu + "," + comBody + "");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    string sqlCommandText = string.Format("insert into Comment(Com_UserGuId,Com_InvGuId,Com_ComGuId,Com_Body) values('" + userGu + "','" + invGu + "','" + comGu + "','" + comBody + "')");
                    result = conn.Execute(sqlCommandText);
                }
            }
            catch (Exception)
            {
                Log.FileLogService.Instance.Error("盖楼人" + userGu + ",帖子" + invGu + "," + comGu + "," + comBody + "失败！");
                throw;
            }
            return result;
        }
        public int CommentByUser(string userGu, string invGu, string comBody)
        {
            int result = 0;
            try
            {
                Log.FileLogService.Instance.Info("评论" + userGu + ",帖子" + invGu + "," + comBody + "");
                using (IDbConnection conn = Commond.SqlConnection())
                {
                    string sqlCommandText = string.Format("insert into Comment(Com_UserGuId,Com_InvGuId,Com_Body) values('" + userGu + "','" + invGu + "','" + comBody + "')");
                    result = conn.Execute(sqlCommandText);
                }
            }
            catch (Exception)
            {
                Log.FileLogService.Instance.Error("评论" + userGu + ",帖子" + invGu + "," + comBody + "");
                throw;
            }
            return result;
        }
    }
}
