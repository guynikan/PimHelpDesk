using System.Web;
using System.Web.Mvc;

namespace UNIP.PIM.HelpDesk
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
