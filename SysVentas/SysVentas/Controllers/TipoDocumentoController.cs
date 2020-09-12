using Entidad;
using Negocio;
using System.Web.Mvc;

namespace SysVentas.Controllers
{
    public class TipoDocumentoController : Controller
    {
        TipoDocumentoNE objTipoDocumento = new TipoDocumentoNE();
        // GET: TipoDocumento
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListaTipoDocumento(FiltroCLS fil)
        {
            var lsTipoDocumento = objTipoDocumento.ListarTipoDocumentoPorFiltro(fil);
            return Json(new { lsTipoDocumento, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult AgregarTipoDocumento(TipoDocumentoCLS tipoD)
        {
            var codigoRpt = objTipoDocumento.AgregarTipoDocumento(tipoD);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ObtenerTipoDocumentoPorId(int tipoDoc)
        {
            var tipoDocCLS = objTipoDocumento.ObtenerTipoDocumentoPorId(tipoDoc);
            return Json(new { tipoDocCLS, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EditarTipoDocumento(TipoDocumentoCLS tipoD)
        {
            int codigoRpt = objTipoDocumento.EditarTipoDocumento(tipoD);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult CambiarEstadoTipoDocumento(TipoDocumentoCLS tipoD)
        {
            var codigRpt = objTipoDocumento.CambiarEstadoTipoDocumento(tipoD);
            return Json(new { Code = codigRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EliminarTipoDocumento(TipoDocumentoCLS tipoD)
        {
            int codigoRpt = objTipoDocumento.EliminarTipoDocumento(tipoD);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }
    }
}