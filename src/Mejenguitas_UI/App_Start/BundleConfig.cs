using System.Web;
using System.Web.Optimization;

namespace Mejenguitas_UI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/bootstrap.js", "~/Scripts/bootstrap-datepicker.js", "~/Scripts/Site.js", "~/Scripts/jquery.flexslider.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.unobtrusive*", "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/bootstrap-datepicker.js"));
            bundles.Add(new ScriptBundle("~/bundles/Site").Include("~/Scripts/Site.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/themes/base/jquery-ui.css,~/Content/bootstrap.css", "~/Content/bootstrap-responsive.css", "~/Content/bootstrap-datepicker.css", "~/Content/Site.css", "~/Content/flexslider.css"));
        }
    }
}