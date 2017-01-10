using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OA.Common
{
    #region SessionName
    public class SessionName
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public readonly static string CurrentUserInfo = "CurrentUserInfo";
        /// <summary>
        /// 最后一次访问的页面
        /// </summary>
        public readonly static string LastPageURL = "LastPageURL";
    }
    #endregion

    public class SessionHelper
    {
        #region 登出操作，清空用户session
        /// <summary>
        /// 登出操作，清空用户session
        /// </summary>
        public static void LoginOut()
        {
            HttpContext.Current.Session.Remove(SessionName.CurrentUserInfo);
        }
        #endregion

        #region 查看用户是否登录
        /// <summary>
        /// 查看用户是否登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            if ((OA.Model.Sys_User)HttpContext.Current.Session[SessionName.CurrentUserInfo] == null)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
