﻿using System;
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
    public class dal
    {
        public static SqlConnection SqlConnection()//连接字符串
        {
            string sqlconnectionString = ConfigurationManager.ConnectionStrings["sqlconnectionString"].ConnectionString;
            var connection = new SqlConnection(sqlconnectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            return connection;
        }
        public List<AllInfo> GetInvitation()//获取帖子的信息
        {
            using (IDbConnection conn = SqlConnection())
            {
                var data = conn.Query<AllInfo>("select * from Invitation ").ToList();
                int e = 3;
                return data;
            }
        }
    }
}
