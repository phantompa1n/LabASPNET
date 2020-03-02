using System.Web;
using System.Web.Optimization;

namespace GameAPP
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css"));
        }
    }
}
