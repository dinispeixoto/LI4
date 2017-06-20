using System.Web;
using System.Web.Optimization;
using WhatsYummy.DataAPI;
using WhatsYummy.Models;

namespace WhatsYummy
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

             Parser p = new Parser();
            if (p != null)
            {
                p.Load("restaurant", "Braga").Wait();

                Load l = new Load();
                l.LoadTags();
            }

            } 
        }
    
}
