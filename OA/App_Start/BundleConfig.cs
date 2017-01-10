using System.Web;
using System.Web.Optimization;

namespace OA
{
    public class BundleConfig : System.Web.SessionState.IRequiresSessionState
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            /*easyui-script*/
            bundles.Add(new ScriptBundle("~/script-easyui").Include(
                "~/Scripts/jquery-easyui-1.5/jquery.min.js",
                "~/Scripts/jquery-easyui-1.5/jquery.easyui.min.js",
                "~/Scripts/jquery-easyui-1.5/easyuiloader.js",
                "~/Scripts/jquery-easyui-1.5/easyui-lang-zh_CN.js",
                "~/Scripts/jquery.cookie.js"
               // "~/Scripts/jquery-easyui-1.5/iconsExtend/jeasyui.icons.all.js"

            ));

            /*easyui-style*/
            bundles.Add(new StyleBundle("~/style-easyui").Include(
                "~/Content/custom.css",
                //"~/Content/jquery-easyui-1.5/default/easyui.css",
                //"~/Content/jquery-easyui-1.5/bootstrap/easyui.css",
                "~/Content/jquery-easyui-1.5/color.css",
                "~/Content/jquery-easyui-1.5/icon.css",
                "~/Content/jquery-easyui-1.5/iconsExtend/icon-all.css"
            ));


            /*easyui-style*/
            bundles.Add(new StyleBundle("~/style-login").Include(
                "~/Content/learunui-framework.css",
                "~/Content/learunui-login.css",
                "~/Content/zzsc.css"
            ));
        }
    }
}
