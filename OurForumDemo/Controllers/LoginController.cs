using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BLL;
using MODEL;
namespace OurForumDemo.Controllers
{
    public class LoginController : Controller
    {
        Bll bll = new Bll();
        // GET: Login
        //登录
        public ActionResult Login()
        {         
            return View();
        }
        [HttpPost]
        public int Login(string name, string pwd)
        {
            int i = bll.Login(name, pwd);
            return i;
        }
        //注册
        public int Register(string name,string pwd, string code)
        {
            int i = bll.Register(name,pwd,code);
            return i;
        }

        //短信验证的方法
        private const String host = "http://dingxin.market.alicloudapi.com";
        private const String path = "/dx/sendSms";
        private const String method = "POST";
        private const String appcode = "7edd9a2784a448c790b16237aa9c6fc0";

        public void Duan(string phone)
        {
            Random rad = new Random();
            int value = rad.Next(1000, 10000);
            ViewBag.value = value;
            String querys = "mobile="+phone+"&param=code:"+value+"&tpl_id=TP1711063";
            String bodys = "";
            String url = host + path;
            HttpWebRequest httpRequest = null;
            HttpWebResponse httpResponse = null;

            if (0 < querys.Length)
            {
                url = url + "?" + querys;
            }

            if (host.Contains("https://"))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                httpRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            }
            else
            {
                httpRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            httpRequest.Method = method;
            httpRequest.Headers.Add("Authorization", "APPCODE " + appcode);
            if (0 < bodys.Length)
            {
                byte[] data = Encoding.UTF8.GetBytes(bodys);
                using (Stream stream = httpRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            try
            {
                httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            }
            catch (WebException ex)
            {
                httpResponse = (HttpWebResponse)ex.Response;
            }

            Console.WriteLine(httpResponse.StatusCode);
            Console.WriteLine(httpResponse.Method);
            Console.WriteLine(httpResponse.Headers);
            Stream st = httpResponse.GetResponseStream();
            StreamReader reader = new StreamReader(st, Encoding.GetEncoding("utf-8"));
            Console.WriteLine(reader.ReadToEnd());
            Console.WriteLine("\n");

        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}