using OA.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using OA.Model;
using OA.BLL;
using OA.Common;

namespace OA.Controllers.System
{
    public class OrganController : BaseController
    {
        public IBLL.IOrg_OrganService service = new Org_OrganService();

        //
        // GET: /Organ/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public JsonResult InitGrid()
        {
            var ParentID = Request["ParentID"];
            var sort = Request["sort"];
            var order = Request["order"];
            var pageNumber = string.IsNullOrWhiteSpace(Request["page"]) ? 0 : int.Parse(Request["page"]);
            var pageSize = string.IsNullOrWhiteSpace(Request["rows"]) ? 0 : int.Parse(Request["rows"]);

            var total = 0;


            var newdb = entity.Org_Organ.Select(a => new
            {
                a.AccountNumber,
                a.Bank,
                a.Code,
                a.DeleteMark,
                a.Fax,
                a.FullName,
                a.ID,
                a.IsDisable,
                a.IsVirtual,
                a.ParentID,
                a.Path,
                a.PathName,
                a.ShortName,
                a.Sort,
                a.SortStr,
                a.TaxNumber,
                a.Tel,
                a.TypeID,
                TypeName = a.TypeID.Equals("01") ? "机构" : "部门"
            });

            Expression<Func<Org_Organ, bool>> whereLambda = c => c.DeleteMark == 0 & c.ParentID == ParentID;

            

            var pageInfo = service.PageHelper(pageNumber, pageSize, out total, whereLambda, sort, order);

            JEasyUIJsonHelper.DataGrid dg = new JEasyUIJsonHelper.DataGrid()
            {
                total = total,
                rows = pageInfo
            };


            return Json(json.obj = dg);
        }

        //
        // GET: /Organ/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Organ/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Organ/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Organ/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Organ/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Organ/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Organ/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        /// <summary>
        /// 加载部门树
        /// </summary>
        /// <returns></returns>
        public ActionResult InitDeptTree()
        {
            string ParentID = Request["ParentID"];
            if (string.IsNullOrWhiteSpace(ParentID))
            {
                var treeNode = entity.Sys_UnitInfo.Select(a => new
                {
                    id = "0",
                    text = a.Name,
                    iconCls = "icon-root",
                    state = "closed",
                    attributes = new { URL = "List?ParentID=0" }
                });
                json.rows = treeNode;
            }
            else
            {
                var treeNode = entity.Org_Organ.Where(a => a.DeleteMark == 0 & a.ParentID == ParentID).OrderBy(a => new { a.Sort, a.SortStr }).Select(a => new
                {
                    id = a.ID,
                    text = a.FullName,
                    iconCls = a.TypeID == "01" ? "icon-org" : "icon-dept",
                    state = entity.Org_Organ.Where(b => b.ParentID == a.ID & b.DeleteMark == 0).Count() > 0 ? "closed" : "open",
                    attributes = new { URL = "List?ParentID=" + a.ID }
                });
                json.rows = treeNode;
            }

            json.success = true;
            return Json(json);
        }
    }
}
