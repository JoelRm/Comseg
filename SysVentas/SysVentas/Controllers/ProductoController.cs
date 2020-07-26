using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysVentas.Controllers
{
    public class ProductoController : Controller
    {
        LineaNE objLinea = new LineaNE();
        MarcaNE objMarca = new MarcaNE();
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListarLinea(FiltroCLS fil)
        {
            var lsLinea = objLinea.ListarLineasPorFiltro(fil);
            return Json(new { lsLinea, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ListaMarca(FiltroCLS fil)
        {
            var lsMarca = objMarca.ListarMarcaPorFiltro(fil);
            return Json(new { lsMarca, JsonRequestBehavior.AllowGet });
        }
    }
}