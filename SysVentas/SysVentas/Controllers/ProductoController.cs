using Entidad;
using Negocio;
using System.Web.Mvc;

namespace SysVentas.Controllers
{
    public class ProductoController : Controller
    {
        LineaNE objLinea = new LineaNE();
        MarcaNE objMarca = new MarcaNE();
        UnidadNE objUnidad = new UnidadNE();
        AlmacenNE objAlmacen = new AlmacenNE();
        MonedaNE objMoneda = new MonedaNE();
        ImpuestoNE objImpuesto = new ImpuestoNE();
        ProveedorNE objProveedor = new ProveedorNE();
        ProductoNE objProducto = new ProductoNE();
            
        // GET: Producto
        public ActionResult Index()
        {
            ViewBag.menuActive = 9;

            listarCombos();

            return View();
        }

        public void listarCombos()
        {
            var listaMoneda = objMoneda.ListarMonedas();
            listaMoneda.Insert(0, new MonedaCLS { NombreMoneda = "--SELECCIONE MONEDA--", IdMoneda = 0 });
            var listaImpuesto = objImpuesto.ListarImpuesto();
            listaImpuesto.Insert(0, new ImpuestoCLS { NombreImpuesto = "--SELECCIONE IMPUESTO--", IdImpuesto = 0 });

            ViewBag.listaMoneda = listaMoneda;
            ViewBag.listaImpuesto = listaImpuesto;
        }

        [HttpPost]
        public JsonResult ListarProducto(FiltroCLS fil)
        {
            var lsProducto = objProducto.ListarProductosPorFiltro(fil);
            return Json(new { lsProducto, JsonRequestBehavior.AllowGet });
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

        [HttpPost]
        public JsonResult ListarUnidades(FiltroCLS flt)
        {
            var lsUnidades = objUnidad.ListarUnidadesPorFiltroProductoUnd(flt);
            return Json(new { lsUnidades, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ListarAlmacenes(FiltroCLS flt)
        {
            var lsAlmacen = objAlmacen.ListarAlmacenPorFiltroProductoAlm(flt);
            return Json(new { lsAlmacen, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult ListarProveedor(FiltroCLS fil)
        {
            var lsProveedor = objProveedor.ListarProveedorPorFiltro(fil);
            return Json(new { lsProveedor, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public JsonResult AgregarProducto(ProductoCLS prod)
        {
            var codigoRpt = objProducto.AgregarProducto(prod);
            return Json(new { Code = codigoRpt, JsonRequestBehavior.AllowGet });
        }
    }
}