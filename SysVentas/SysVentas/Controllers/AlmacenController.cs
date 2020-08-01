using Entidad;
using Negocio;
using System.Web.Mvc;

namespace SysVentas.Controllers
{
    public class AlmacenController : Controller
    {
        SucursalNE objSucursal = new SucursalNE();
        AlmacenNE objAlmacen = new AlmacenNE();
        // GET: Almacen
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListarSucursal(FiltroCLS fil)
        {
            var lsSucursal = objSucursal.ListarSucursalesPorFiltro(fil);
            return Json(new { lsSucursal, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult AgregarAlmacen(AlmacenCLS alm)
        {
            var codigoRpt = objAlmacen.AgregarAlmacen(alm);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ListaAlmacen(FiltroCLS fil)
        {
            var lsAlmacen = objAlmacen.ListarAlmacenPorFiltro(fil);
            return Json(new { lsAlmacen, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ObtenerAlmacenPorId(int alm)
        {
            var almacenCLS = objAlmacen.ObtenerAlmacenPorId(alm);
            return Json(new { almacenCLS, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult CambiarEstadoAlmacen(AlmacenCLS alm)
        {
            var codigRpt = objAlmacen.CambiarEstadoAlmacen(alm);
            return Json(new { Code = codigRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EliminarAlmacen(AlmacenCLS alm)
        {
            int codigoRpt = objAlmacen.EliminarAlmacen(alm);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EditarAlmacen(AlmacenCLS alm)
        {
            int codigoRpt = objAlmacen.EditarAlmacen(alm);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

    }
}