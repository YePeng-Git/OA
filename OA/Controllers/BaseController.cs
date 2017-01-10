using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using OA.Model;
using Newtonsoft.Json;
using OA.Common;
using OA.Models;

namespace OA.Extend
{
    public class BaseController : System.Web.Mvc.Controller
    {
        #region log4net类
        /// <summary>
        /// log4net类
        /// </summary>
        protected static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region  json帮助类
        /// <summary>
        /// json帮助类
        /// </summary>
        protected JsonResultHelper json = new JsonResultHelper();
        #endregion

        #region 数据上下文
        /// <summary>
        /// 数据上下文
        /// </summary>
        protected DataModelContainer entity = new DataModelContainer();
        #endregion

        #region 取Cookies中的easyui样式
        /// <summary>
        /// 取Cookies中的easyui样式
        /// </summary>
        protected string easyuiTheme
        {
            get
            {
                if (HttpContext.Request.Cookies["easyuiThemeName"] == null)
                {
                    return "/Content/jquery-easyui-1.5/bootstrap/easyui.css";
                }
                else
                {
                    return System.Web.HttpUtility.UrlDecode(HttpContext.Request.Cookies["easyuiThemeName"].Value);
                }
            }
        }
        #endregion

        #region 当前登录的用户属性
        /// <summary>
        /// 当前登录的用户属性
        /// </summary>
        public Sys_User CurrentUserInfo { get; set; }
        #endregion

        /// <summary>
        /// 在调用操作方法前发生前调用。 
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //得到用户登录的信息
            CurrentUserInfo = Session[SessionName.CurrentUserInfo] as Sys_User;
            //判断用户是否为空
            if (CurrentUserInfo == null)
            {
                Response.Redirect("/Login/Index");
            }
        }

        /// <summary>
        /// 身份验证
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthentication(System.Web.Mvc.Filters.AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
        }


        /// <summary>
        /// 在调用操作方法后调用，在result执行前发生 (在 view 呈现前)  
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        /// <summary>
        /// 在执行由操作方法返回操作结果前调用(在view 呈现前)  
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        /// <summary>
        /// 在执行由操作方法返回操作结果后调用(在view 呈现后)
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            //string pageUrl = "";

            ////获取触发当前方法的的Action所在的控制器名字
            //string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            //string actionName = filterContext.ActionDescriptor.ActionName;

            ////获取触发当前方法的Action方法的所有参数（因为参数可能有多个，所以它是一个集合,它的返回值类型是IDictionary<string ,object> 
            //var paramss = filterContext.ActionParameters;

            //string str = "";
            //if (paramss.Any()) //Any是判断这个集合是否包含任何元素，如果包含元素返回true，否则返回false
            //{
            //    foreach (var key in paramss.Keys) //遍历它的键；(因为我们要获取的是参数的名称s,所以遍历键)
            //    {
            //        str = "&" + key + "=" + paramss[key];  //paramss[key] 是key的值
            //    }
            //}

            //pageUrl = "/" + controllerName + "/" + actionName + (str.Length > 0 ? ("?" + str.TrimStart('&')) : "");

            //filterContext.HttpContext.Session[SessionName.LastPageURL] = pageUrl;
        }

        /// <summary>
        /// 页面初始化事件
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            var context = requestContext.HttpContext;

            ViewBag.easyuiTheme = easyuiTheme;

        }

        /// <summary>  
        /// 统一错误日志编写  
        /// </summary>  
        /// <param name="filterContext"></param>  
        protected override void OnException(ExceptionContext filterContext)
        {
            // 错误日志编写      
            string controllerNamer = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();
            string exception = filterContext.Exception.ToString();

            log.Error(exception);

            // 执行基类中的OnException      
            base.OnException(filterContext);
        }

        /// <summary>
        /// 未知的路径
        /// </summary>
        /// <param name="actionName"></param>
        protected override void HandleUnknownAction(string actionName)
        {
            log.Error(actionName);
            base.HandleUnknownAction(actionName);
        }

        /// <summary>
        /// 重写Json方法，使之返回JsonNetResult类型
        /// </summary>
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }


        /// <summary>
        /// 返回处理过的时间的Json字符串
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public ContentResult JsonDate(object date)
        {
            var timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return Content(JsonConvert.SerializeObject(date, Formatting.Indented, timeConverter));
        }
    }
}
