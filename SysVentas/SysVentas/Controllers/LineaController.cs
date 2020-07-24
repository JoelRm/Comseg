using Entidad;
using Negocio;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysVentas.Controllers
{
    public class LineaController : Controller
    {
        LineaNE objLinea = new LineaNE();
        // GET: Linea
        public ActionResult Index()
        {
            ViewBag.menuActive = 3;
            return View();
        }


        [HttpPost]
        public JsonResult ListarLinea(FiltroCLS fil)
        {
            var lsLinea = objLinea.ListarLineasPorFiltro(fil);
            return Json(new { lsLinea, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult CambiarEstadoLinea(LineaCLS lna)
        {
            var codigRpt = objLinea.CambiarEstadoLinea(lna);
            return Json(new { Code = codigRpt, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult AgregarLinea(LineaCLS lna)
        {
            int codigoRpt = objLinea.AgregarLinea(lna);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult EliminarLinea(LineaCLS lna)
        {
            int codigoRpt = objLinea.EliminarLinea(lna);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult ObtenerLineaPorId(int lna)
        {
            var lineaCLS = objLinea.ObtenerLineaPorId(lna);
            return Json(new { lineaCLS, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult EditarLinea(LineaCLS lna)
        {
            int codigoRpt = objLinea.EditarLinea(lna);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

    }
}