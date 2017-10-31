using System.Web;
using System.Web.Optimization;

namespace Egitim5
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

            bundles.Add(new ScriptBundle("~/MainScript").Include("~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/Style.css"));


            bundles.Add(new StyleBundle("~/Content/LightboxCSS").Include("~/Content/Lightbox/lightbox2-master/dist/css/lightbox.css"));

            bundles.Add(new ScriptBundle("~/Content/LightboxJS").Include("~/Content/Lightbox/lightbox2-master/dist/js/lightbox.js"));

            bundles.Add(new ScriptBundle("~/Content/MultiSelectJS").Include("~/Content/MultiSelect/js/bootstrap-multiselect.js"));
            bundles.Add(new StyleBundle("~/Content/MultiSelectCSS").Include("~/Content/MultiSelect/css/bootstrap-multiselect.css"));

        }
    }
}
