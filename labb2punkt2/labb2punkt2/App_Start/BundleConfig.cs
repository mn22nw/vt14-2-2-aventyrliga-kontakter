using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace labb2punkt2.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*")
            );

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/style.css")
            );
        }
    }
}