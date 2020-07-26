using Entidad;
using Negocio;
using System.Web.Mvc;

namespace SysVentas.Controllers
{
    public class MarcaController : Controller
    {
        MarcaNE objMarca = new MarcaNE();
        // GET: Marca
        public ActionResult Index()
        {
            ViewBag.menuActive = 4;
            return View();
        }

        [HttpPost]
        public JsonResult ListaMarca(FiltroCLS fil)
        {
            var lsMarca = objMarca.ListarMarcaPorFiltro(fil);
            return Json(new { lsMarca, JsonRequestBehavior.AllowGet });
        }



        [HttpPost]
        public JsonResult CambiarEstadoMarca(MarcaCLS mca)
        {
            var codigRpt = objMarca.CambiarEstadoMarca(mca);
            return Json(new { Code = codigRpt, JsonRequestBehavior.AllowGet });
        }



        [HttpPost]
        public JsonResult AgregarMarca(MarcaCLS mca)
        {
            int codigoRpt = objMarca.AgregarMarca(mca);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }



        [HttpPost]
        public JsonResult EliminarMarca(MarcaCLS mca)
        {
            int codigoRpt = objMarca.EliminarMarca(mca);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }



        [HttpPost]
        public JsonResult ObtenerMarcaPorId(int mca)
        {
            var marcaCLS = objMarca.ObtenerMarcaPorId(mca);
            return Json(new { marcaCLS, JsonRequestBehavior.AllowGet });
        }



        [HttpPost]
        public JsonResult EditarMarca(MarcaCLS mca)
        {
            int codigoRpt = objMarca.EditarMarca(mca);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }
    }
}