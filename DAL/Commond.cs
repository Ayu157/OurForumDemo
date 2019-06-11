using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Commond
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
    }
}
