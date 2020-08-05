using Entidad;
using Negocio;
using System.Web.Mvc;

namespace SysVentas.Controllers
{
    public class ProveedorController : Controller
    {

        ProveedorNE objProveedorNE = new ProveedorNE();
        TipoPersonaNE objTipoPersonaNE = new TipoPersonaNE();


        // GET: Proveedor
        public ActionResult Index()
        {
            var lsTipoPersona = objTipoPersonaNE.ListarTipoPersona();
            lsTipoPersona.Insert(0, new TipoPersonaCLS { NombreTipoPersona = "--SELECCIONE--", IdTipoPersona = 0 });

            return View(lsTipoPersona);
        }

        [HttpPost]
        public JsonResult ListaProveedor(FiltroCLS fil)
        {
            var lsProveedor = objProveedorNE.ListarProveedorPorFiltro(fil);
            return Json(new { lsProveedor, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult AgregarProveedor(ProveedorCLS prov)
        {
            int codigoRpt = objProveedorNE.AgregarProveedor(prov);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ObtenerProveedorPorId(int prov)
        {
            var proveedorCLS = objProveedorNE.ObtenerProveedorPorId(prov);
            return Json(new { proveedorCLS, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EditarProveedor(ProveedorCLS prov)
        {
            int codigoRpt = objProveedorNE.EditarProveedor(prov);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult CambiarEstadoProveedor(ProveedorCLS prov)
        {
            var codigRpt = objProveedorNE.CambiarEstadoProveedor(prov);
            return Json(new { Code = codigRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EliminarProveedor(ProveedorCLS prov)
        {
            int codigoRpt = objProveedorNE.EliminarProveedor(prov);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

    }
}