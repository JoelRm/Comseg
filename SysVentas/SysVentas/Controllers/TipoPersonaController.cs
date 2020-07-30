using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entidad;
using Negocio;

namespace SysVentas.Controllers
{
    public class TipoPersonaController : Controller
    {
        TipoPersonaNE objTipoPersona = new TipoPersonaNE();
        // GET: TipoPersona
        public ActionResult Index()
        {
            ViewBag.menuActive = 10;
            return View();
        }
        [HttpPost]
        public JsonResult ListarTipoPersona(FiltroCLS fil)
        {
            var lsTipoPersona = objTipoPersona.ListarTipoPersonaPorFiltro(fil);
            return Json(new { lsTipoPersona, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult CambiarEstadoTipoPersona(TipoPersonaCLS per)
        {
            var codigRpt = objTipoPersona.CambiarEstadoTipoPersona(per);
            return Json(new { Code = codigRpt, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult AgregarTipoPersona(TipoPersonaCLS per)
        {
            int codigoRpt = objTipoPersona.AgregarTipoPersona(per);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult EliminarTipoPersona(TipoPersonaCLS per)
        {
            int codigoRpt = objTipoPersona.EliminarTipoPersona(per);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult ObtenerTipoPersonaPorId(int per)
        {
            var TipoPersonaCLS = objTipoPersona.ObtenerTipoPersonaPorId(per);
            return Json(new { TipoPersonaCLS, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult EditarTipoPersona(TipoPersonaCLS per)
        {
            int codigoRpt = objTipoPersona.EditarTipoPersona(per);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }
    }
}