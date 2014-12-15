using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Starter.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // css bundles
            // use JUST a new Bundle for files that already have minified versions. Use ScriptBundle or StyleBundle to minify. I'm using WebEssentials to minify, so I'll just use Bundle
            bundles.Add(new Bundle(BundleNames.BootStrapBase).Include("~/Content/bootstrap.css"));
            bundles.Add(new Bundle(BundleNames.SiteCss).Include("~/Content/Site.css"));
            // js bundles
        }
    }

    public static class BundleNames
    {
        public static string BootStrapBase = "~/Content/bootstrap";
        public static string SiteCss = "~/Content/site";
    }
}