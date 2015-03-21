using System.Web.Mvc;

namespace SignalRSqlDemo.Controllers
{
    public class HomeController : Controller
    {
       public ActionResult Status()
        {
            return View();
        }
    }
}