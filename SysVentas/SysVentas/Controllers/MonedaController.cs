using System.Web.Mvc;
using Entidad;
using Negocio;

namespace SysVentas.Controllers
{
    public class MonedaController : Controller
    {
        MonedaNE objMoneda = new MonedaNE();
        // GET: Moneda
        public ActionResult Index()
        {
            ViewBag.menuActive = 7;
            return View();

        }
        [HttpPost]
        public JsonResult ListarMoneda(FiltroCLS fil)
        {
            var lsMoneda = objMoneda.ListarMonedasPorFiltro(fil);
            return Json(new { lsMoneda, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult CambiarEstadoMoneda(MonedaCLS mod)
        {
            var codigRpt = objMoneda.CambiarEstadoMoneda(mod);
            return Json(new { Code = codigRpt, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult AgregarMoneda(MonedaCLS mod)
        {
            int codigoRpt = objMoneda.AgregarMoneda(mod);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult EliminarMoneda(MonedaCLS mod)
        {
            int codigoRpt = objMoneda.EliminarMoneda(mod);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult ObtenerMonedaPorId(int mod)
        {
            var MonedaCLS = objMoneda.ObtenerMonedaPorId(mod);
            return Json(new { MonedaCLS, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult EditarMoneda(MonedaCLS mod)
        {
            int codigoRpt = objMoneda.EditarMoneda(mod);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }
    }
}