using System.Web;
using System.Web.Optimization;

namespace SpeedRacing
{
    public class BundleConfig
    {
        // Więcej informacji dotyczących tworzenia pakietów można znaleźć na stronie http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Użyj wersji deweloperskiej biblioteki Modernizr do nauki i opracowywania rozwiązań. Następnie, kiedy wszystko będzie
            // gotowe do produkcji, wybierz tylko potrzebne testy za pomocą narzędzia kompilacji z witryny http://modernizr.com.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(   
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/JasnyBootstrap/jasny-bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/themes/base/all.css",
                    "~/Content/bootstrap.css",
                    "~/Content/site.css",
                    "~/Content/MojeStyle/style.css",
                    "~/Content/MojeStyle/tm_docs.css",
                    "~/Content/DataTable/dataTables.bootstrap.css",
                    "~/Content//JasnyBootstrap/jasny-bootstrap.min.css"
                    ));

            bundles.Add(new StyleBundle("~/bundles/MojeSkrypty").Include(
                "~/Scripts/MojeJS/scripts.js"
                ));

        }
    }
}
