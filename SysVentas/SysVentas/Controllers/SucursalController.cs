using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entidad;
using Negocio;

namespace SysVentas.Controllers
{
    public class SucursalController : Controller
    {
        SucursalNE ObjSucursal = new SucursalNE();
        TipoTiendaNE ObjtipoTiendaNE = new TipoTiendaNE();
        // GET: Sucursal
        public ActionResult Index()
        {
            var lstTipoTienda = ObjtipoTiendaNE.ListarTipoTiendas();
            ViewBag.menuActive = 6;
            return View(lstTipoTienda);
        }

        [HttpPost]
        public JsonResult ListarSucursales(FiltroCLS flt)
        {
            var lsSucursales = ObjSucursal.ListarSucursalesPorFiltro(flt);
            return Json(new { lsSucursales, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult CambiarEstado(SucursalCLS scl)
        {
            var codigRpt = ObjSucursal.CambiarEstado(scl);
            return Json(new { Code = codigRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult AgregarSucursal(SucursalCLS scl)
        {
            int codigoRpt = ObjSucursal.AgregarSucursal(scl);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EliminarSucursal(SucursalCLS scl)
        {
            int codigoRpt = ObjSucursal.EliminarSucursal(scl);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ObtenerSucursalPorId(int scl)
        {
            var SucursalCLS = ObjSucursal.ObtenerSucursalPorId(scl);
            return Json(new { SucursalCLS, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EditarSucursal(SucursalCLS scl)
        {
            int codigoRpt = ObjSucursal.EditarSucursal(scl);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }
    }
}