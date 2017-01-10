using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //注册log4net.config
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(Server.MapPath("log4net.config")));

            //注册视图访问规则
            RegisterView();
        }

        /// <summary>
        /// 移除默认视图配置，注册自己的MyViewEngine配置
        /// </summary>
        protected void RegisterView()
        {
            //移除默认视图配置
            ViewEngines.Engines.Clear();
            //注册自己编写的视图格式
            ViewEngines.Engines.Add(new Models.MyViewEngine());
        }
    }
}
