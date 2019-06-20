using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UptLogin
{
    public class UptPassword
    {
        [Display(Name = "用户编号")]
        public int userId { get; set; }
        [Display(Name = "登录名")]
        public string userName { get; set; }

        [Display(Name = "旧密码")]
        public string pwd { get; set; }
        [Display(Name = "新密码")]
        public string NewPwd { get; set; }
        [Display(Name = "确认密码")]
        public string confirmPwd { get; set; }
    }
}
