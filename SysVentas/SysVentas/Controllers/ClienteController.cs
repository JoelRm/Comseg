using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entidad;
using Negocio;
namespace SysVentas.Controllers
{
    public class ClienteController : Controller
    {
        ClienteNE ObjCliente = new ClienteNE();
        TipoPersonaNE ObjTipoPersona = new TipoPersonaNE();
        // GET: Cliente
        public ActionResult Index()
        {
            var lsTipoPersona = ObjTipoPersona.ListarTipoPersona();
            ViewBag.menuActive = 11;
            return View(lsTipoPersona);
        }
        [HttpPost]
        public JsonResult ListarCliente(FiltroCLS flt)
        {

            var lsCliente = ObjCliente.ListarClientePorFiltro(flt);
            return Json(new { lsCliente, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult CambiarEstado(ClienteCLS cli)
        {
            var codigRpt = ObjCliente.CambiarEstado(cli);
            return Json(new { Code = codigRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult AgregarCliente(ClienteCLS cli)
        {
            int codigoRpt = ObjCliente.AgregarCliente(cli);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EliminarCliente(ClienteCLS cli)
        {
            int codigoRpt = ObjCliente.EliminarCliente(cli);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ObtenerClientePorId(int cli)
        {
            var clienteCLS = ObjCliente.ObtenerClientePorId(cli);
            return Json(new { clienteCLS, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult EditarCliente(ClienteCLS cli)
        {
            int codigoRpt = ObjCliente.EditarCliente(cli);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }
    }
}