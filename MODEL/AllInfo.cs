using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class AllInfo
    {
        //宇大大
        //测试
        /// <summary>
        /// 用户表的具体字段
        /// </summary>
        //-用户自增Id主键
        public int User_Id { get; set; }
        //状态 0普通，1管理，2最高
        public int User_State { get; set; }
        //用户唯一Id
        public string User_GuId { get; set; }
        //用户名
        public string User_Name { get; set; }
        //登录名
        public string User_LoginName { get; set; }
        //密码
        public string User_PassWord { get; set; }
        //问题
        public string User_Question { get; set; }
        //答案
        public string User_Answer { get; set; }
        //邮箱
        public string User_Email { get; set; }
        //电话
        public string User_Phone { get; set; }
        //用户头像
        public string User_HeadImg { get; set; }
        //创建时间
        public DateTime User_CreateTime { get; set; }
        //积分or发帖数
        public int User_Integral { get; set; }
        /// <summary>
        /// 帖子的具体字段
        /// </summary>
        //自增ID
        public int Inv_Id { get; set; }
        //唯一Id
        public string Inv_GuId { get; set; }
        //发帖人Id
        public string Inv_UserGuId { get; set; }
        //标题
        public string Inv_Tittle { get; set; }
        //发帖内容
        public string Inv_Body { get; set; }
        //发帖时间
        public DateTime Inv_CreateTime { get; set; }
        //点击数
        public int Inv_Click { get; set; }
        //帖子图片
        public string Inv_Img { get; set; }

    }
}
