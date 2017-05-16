using System.Web.Optimization;

namespace Application.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/Content/css").Include(
				"~/Content/css/main/main.css",
				"~/Content/css/main/header.css",
				"~/Content/scss/bundled.css"));
		}
	}
}