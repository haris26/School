using System.Web;
using System.Web.Optimization;

namespace ProcurementSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                     // "~/Scripts/respond.js",
                     //  "~/Scripts/npm.js",
                      // "~/Scripts/scripts.js",
                         "~/Scripts/jquery.min.js",
                           "~/Scripts/metisMenu.min.js",
                            "~/Scripts/bootstrap.min.js",
                              "~/Scripts/startmin.js"
                                          ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                     
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-social.css",
                      "~/Content/bootstrap-theme.min.css",
                    
                          "~/Content/startmin.css"
                      ));
        }
    }
}
