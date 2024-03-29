﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class AllInfo
    {
        //宇大大qwe
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
        /// <summary>
        /// 这是评论表所需要的字段
        /// </summary>
        //评论表自增Id
        public int Com_Id { get; set; }
        //帖子唯一Id
        public string Com_InvGuId { get; set; }
        //评论表唯一Id
        public string Com_GuId { get; set; }
        //回复人Id
        public string Com_UserGuId { get; set; }
        //盖楼Id 默认null
        public string Com_ComGuId { get; set; }
        //评论内容
        public string Com_Body { get; set; }
        //回复的图片  默认null
        public string Com_Img { get; set; }
        //评论时间
        public DateTime Com_CreateTime { get; set; }
        //点赞
        public int Com_Click { get; set; }
        /// <summary>
        /// 关系表
        /// </summary>
        //关系自增id
        public int Rel_Id { get; set; }
        //关系唯一id
        public string Rel_GuId { get; set; }
        //帖子外键
        public string Rel_InvId { get; set; }
        //评论外键
        public int Rel_CommentId { get; set; }
        //用户外键
        public int Rel_UserId { get; set; }
    }
}
