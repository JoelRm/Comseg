using System.Web.Mvc;

namespace SysVentas.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.menuActive = 1;
            return View();
        }
    }
}