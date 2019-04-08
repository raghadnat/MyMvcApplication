using System.Web;
using System.Web.Optimization;

namespace MyMVCApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new StyleBundle("~/Sidebar").Include(
                      "~/Sidebar/Sidebar.css"));

        }
    }
}

