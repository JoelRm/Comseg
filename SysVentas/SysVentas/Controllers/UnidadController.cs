using Entidad;
using Negocio;
using System.Web.Mvc;

namespace SysVentas.Controllers
{
    public class UnidadController : Controller
    {
        UnidadNE ObjUnidad = new UnidadNE();
        // GET: Unidad
        public ActionResult Index()
        {
            ViewBag.menuActive = 2;
            return View();
        }

        [HttpPost]
        public JsonResult ListarUnidades(FiltroCLS flt)
        {
            var lsUnidades = ObjUnidad.ListarUnidadesPorFiltro(flt);
            return Json(new { lsUnidades, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult CambiarEstado(UnidadCLS und)
        {
            var codigRpt = ObjUnidad.CambiarEstado(und);
            return Json(new { Code = codigRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult AgregarUnidad(UnidadCLS und)
        {
            int codigoRpt = ObjUnidad.AgregarUnidad(und);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EliminarUnidad(UnidadCLS und)
        {
            int codigoRpt = ObjUnidad.EliminarUnidad(und);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ObtenerUnidadPorId(int und)
        {
            var unidadCLS = ObjUnidad.ObtenerUnidadPorId(und);
            return Json(new { unidadCLS, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EditarUnidad(UnidadCLS und)
        {
            int codigoRpt = ObjUnidad.EditarUnidad(und);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }
    }
}