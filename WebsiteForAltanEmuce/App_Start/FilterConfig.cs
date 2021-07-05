using System.Web;
using System.Web.Mvc;

namespace WebsiteForAltanEmuce
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
