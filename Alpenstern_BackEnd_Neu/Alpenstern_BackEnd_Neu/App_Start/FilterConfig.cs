using System.Web;
using System.Web.Mvc;

namespace Alpenstern_BackEnd_Neu
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
