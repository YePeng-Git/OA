using OA.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using OA.Model;
using OA.Common;
using OA.BLL;

namespace OA.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Logion/
        public ActionResult Index()
        {
            return View("Login");
        }

        /// <summary>
        /// json帮助类
        /// </summary>
        protected JsonResultHelper json = new JsonResultHelper();

        /// <summary>
        /// 数据上下文
        /// </summary>
        public IBLL.ISys_UserService service = new Sys_UserService();

        /// <summary>
        /// 登录校验
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckLogin()
        {
            string Account = Server.UrlDecode(Request["Account"]);
            string Password = Server.UrlDecode(Request["Password"]);

            var user = service.DoSearch(a => a.DeleteMark == false & a.UserName == Account).FirstOrDefault();
            if (user == null)
            {
                json.msg = "系统不存在该人员";
            }
            else
            {
                if (!DecodeHelper.DecodeRSA(user.Password).Equals(Password))
                {
                    json.msg = "密码不正确";
                }
                else if (user.IsDisable ?? false)
                {
                    json.msg = "该账户被禁用";
                }
                else if (user.IsForbid ?? false)
                {
                    json.msg = "该账户被禁止登录";
                }
                else
                {
                    Session[SessionName.CurrentUserInfo] = user;
                    json.success = true;
                }
            }

            return Json(json);
        }
    }
}