﻿using System.Web;
using System.Web.Optimization;

namespace Mejenguitas_UI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/bootstrap.js", "~/Scripts/bootstrap-datepicker.js", "~/Scripts/Site.js", "~/Scripts/jquery.flexslider.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/bootstrap-responsive.css", "~/Content/bootstrap-datepicker.css", "~/Content/Site.css", "~/Content/flexslider.css"));
        }
    }
}