using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysVentas.Controllers
{
    public class UnidadController : Controller
    {
        UnidadNE ObjUnidad = new UnidadNE();
        // GET: Unidad
        public ActionResult Index()
        {
            //var lsUnidades = ObjUnidad.ListarUnidades();
            ViewBag.menuActive = 2;
            return View();
        }

        [HttpPost]
        public JsonResult ListarUnidades(string id)
        {
            var lsUnidades = ObjUnidad.ListarUnidades();
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
    }
}