using OA.Common;
using OA.Extend;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Default()
        {
            ViewBag.Title = "首页";
            return View("Default");
        }

        #region 加载首页菜单
        /// <summary>
        /// 加载菜单
        /// </summary>
        /// <returns></returns>
        public JsonResult LoadMenu()
        {
            //获取对应的系统编号
            var SysCode = ConfigurationManager.AppSettings["SysCode"];
            if (string.IsNullOrWhiteSpace(SysCode))
            {
                json.msg = "WebConfig不存在SysCode，请先设置对应的系统编号";
                return Json(json);
            }


            //获取系统id
            var SysInfo = (from c in entity.Sys_SysInfo where c.SysCode == SysCode select c).FirstOrDefault();

            if (SysInfo == null)
            {
                json.msg = "菜单加载失败：没有对应的SysID";
                return Json(json);
            }

            var MenuList = new List<OA.Model.Sys_Menu>();

            var MenuShowParent = ConfigurationManager.AppSettings["MenuShowParent"];
            if (MenuShowParent.Equals("1"))
            {
                //获取一级菜单
                MenuList = (from c in entity.Sys_Menu
                            where c.SysID == SysInfo.SysID
                            & c.DeleteMark == false
                            & c.ParentID == 0
                            & c.IsShow == 1
                            select c).OrderBy(c => c.MenuCode).ToList();
            }
            else
            {
                var firstMenu = (from c in entity.Sys_Menu
                                 where c.SysID == SysInfo.SysID
                                 & c.DeleteMark == false
                                 & c.ParentID == 0
                                 & c.IsShow == 1
                                 select c).FirstOrDefault();

                if (firstMenu != null)
                {
                    MenuList = (from c in entity.Sys_Menu
                                where c.ParentID == firstMenu.MenuID
                                & c.DeleteMark == false
                                & c.IsShow == 1
                                select c).OrderBy(c => c.MenuCode).ToList();
                }
            }



            json.success = true;
            json.rows = MenuList;

            return Json(json);
        }

        /// <summary>
        /// 加载下级菜单
        /// </summary>
        /// <returns></returns>
        public JsonResult LoadChildMenu()
        {
            int ParentID = int.Parse(Request["ParentID"]);

            var MenuList =
                            entity.Sys_Menu.Where
                            (
                                a =>
                                a.ParentID == ParentID &
                                a.DeleteMark == false &
                                a.IsShow == 1
                            ).Select(
                                a => new
                                {
                                    id = a.MenuID,
                                    text = a.MenuName,
                                    sort = a.MenuCode,
                                    iconCls = "icon-form",
                                    state = entity.Sys_Menu.Where(b => b.ParentID == a.MenuID & b.DeleteMark == false & b.IsShow == 1).Count() > 0 ? "closed" : "open",
                                    attributes = entity.Sys_Module.Where(c => c.ModuleID == a.ModuleID & c.DeleteMark == false).Select(c => new { URL = c.WebURL }).FirstOrDefault()
                                }
                            ).OrderBy(a => a.sort);


            json.success = true;
            json.rows = MenuList;
            return Json(json);
        }
        #endregion
    }
}