using System.Web;
using System.Web.Optimization;

namespace MyTravelBlog
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
                      "~/Scripts/respond.js"));

            #region ThirdParty scripts
            ScriptBundle thirdPartyScripts = new ScriptBundle("~/Scripts/ThirdParty");
            thirdPartyScripts.Include("~/Scripts/owl.carousel.min.js",
                                      "~/Scripts/unitegallery.min.js",
                                      "~/Scripts/ug-theme-tiles.js",
                                      "~/Scripts/custom.js");

            bundles.Add(thirdPartyScripts);
            #endregion

            #region Common Angular scripts
            ScriptBundle angularScripts = new ScriptBundle("~/bundles/Angular");
            angularScripts.Include("~/Scripts/angular/angular-1.5.0.js",
                                   "~/Scripts/angular/angular-route.js");
            angularScripts.IncludeDirectory("~/Scripts/app/", "*.js");
            angularScripts.IncludeDirectory("~/Scripts/app/common", "*.js");

            bundles.Add(angularScripts);
            #endregion

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #region ThirdParty CSS
            StyleBundle thirdPartyStyles = new StyleBundle("~/Content/ThirdParty");
            thirdPartyStyles.Include("~/Content/style.css",
                                     "~/Content/responsive.css",
                                     "~/Content/font-awesome.min.css",
                                     "~/Content/animate.css",
                                     "~/Content/owl.carousel.min.css",
                                     "~/Content/owl.theme.default.min.css",
                                     "~/Content/unite-gallery.css");

            bundles.Add(thirdPartyStyles);
            #endregion

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
