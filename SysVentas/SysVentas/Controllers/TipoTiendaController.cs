using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Entidad;
using Negocio;

namespace SysVentas.Controllers
{
    public class TipoTiendaController : Controller
    {
        TipoTiendaNE objTipoTienda = new TipoTiendaNE();
        // GET: TipoTienda
        public ActionResult Index()
        {
            ViewBag.menuActive = 5;
            return View();
        }

        [HttpPost]
        public JsonResult ListarTipoTienda(FiltroCLS fil)
        {
            var lsTipoTienda = objTipoTienda.ListarTipoTiendasPorFiltro(fil);
            return Json(new { lsTipoTienda, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult CambiarEstadoTipoTienda(TipoTiendaCLS tnd)
        {
            var codigRpt = objTipoTienda.CambiarEstadoTipoTienda(tnd);
            return Json(new { Code = codigRpt, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult AgregarTipoTienda(TipoTiendaCLS tnd)
        {
            int codigoRpt = objTipoTienda.AgregarTipoTienda(tnd);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult EliminarTipoTienda(TipoTiendaCLS tnd)
        {
            int codigoRpt = objTipoTienda.EliminarTipoTienda(tnd);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult ObtenerTipoTiendaPorId(int tnd)
        {
            var TipoTiendaCLS = objTipoTienda.ObtenerTipoTiendaPorId(tnd);
            return Json(new { TipoTiendaCLS, JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public JsonResult EditarTipoTienda(TipoTiendaCLS tnd)
        {
            int codigoRpt = objTipoTienda.EditarTipoTienda(tnd);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }
    }
}