using System.Web.Optimization;

namespace PhotoAlbum.WEB
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerycookie").Include(
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/jquery.cookie-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/ensure-cookies-enabled").Include(
                        "~/Scripts/ensure.cookies.enabled.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/alert")
                .Include("~/Scripts/reload.alerts.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-modal-form").Include(
                        "~/Scripts/modalform.js",
                        "~/Scripts/jquery.form*"));

            bundles.Add(new ScriptBundle("~/bundles/fancybox").Include(
                        "~/Scripts/jquery.fancybox.pack.js",
                        "~/Scripts/jquery.mousewheel-*"));

            bundles.Add(new ScriptBundle("~/bundles/rateit").Include(
                        "~/Scripts/jquery.rateit*"));

            bundles.Add(new ScriptBundle("~/bundles/rated")
                .Include("~/Scripts/rated.js"));

            bundles.Add(new ScriptBundle("~/bundles/additional-nav-bar").Include(
                        "~/Scripts/additional-nav-bar.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.css",
                "~/Content/font-awesome*",
                "~/Content/jquery.fancybox*",
                "~/Content/rateit.css"));
        }
    }
}
