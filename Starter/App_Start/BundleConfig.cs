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
            bundles.Add(new StyleBundle(BundleNames.BootStrapBase).Include("~/Content/bootstrap.css"));
            // js bundles
        }
    }

    public static class BundleNames
    {
        public static string BootStrapBase = "~/bundles/bootstrap";
    }
}