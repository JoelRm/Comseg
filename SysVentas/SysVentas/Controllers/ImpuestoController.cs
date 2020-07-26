using System.Web.Mvc;
using Entidad;
using Negocio;

namespace SysVentas.Controllers
{
    public class ImpuestoController : Controller
    {
        ImpuestoNE ObjImpuesto = new ImpuestoNE();
        // GET: Impuesto
        public ActionResult Index()
        {
            ViewBag.menuActive = 8;
            return View();
        }
        [HttpPost]
        public JsonResult ListarImpuesto(FiltroCLS flt)
        {
            var lsImpuesto = ObjImpuesto.ListarImpuestoPorFiltro(flt);
            return Json(new { lsImpuesto, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult CambiarEstado(ImpuestoCLS imp)
        {
            var codigRpt = ObjImpuesto.CambiarEstado(imp);
            return Json(new { Code = codigRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult AgregarImpuesto(ImpuestoCLS imp)
        {
            int codigoRpt = ObjImpuesto.AgregarImpuesto(imp);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EliminarImpuesto(ImpuestoCLS imp)
        {
            int codigoRpt = ObjImpuesto.EliminarImpuesto(imp);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ObtenerImpuestoPorId(int imp)
        {
            var ImpuestoCLS = ObjImpuesto.ObtenerImpuestoPorId(imp);
            return Json(new { ImpuestoCLS, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EditarImpuesto(ImpuestoCLS imp)
        {
            int codigoRpt = ObjImpuesto.EditarImpuesto(imp);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }
    }
}