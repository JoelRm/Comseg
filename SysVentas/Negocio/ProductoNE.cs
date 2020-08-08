using Datos.Clases;
using Entidad;
using System.Collections.Generic;

namespace Negocio
{
    public class ProductoNE
    {
        private static ProductoDA obj = new ProductoDA();

        public int AgregarProducto(ProductoCLS objProductoCLS)
        {
            return obj.AgregarProducto(objProductoCLS);
        }

        public List<ProductoCLS> ListarProductosPorFiltro(FiltroCLS objFiltro)
        {
            return obj.ListarProductosPorFiltro(objFiltro);
        }

    }
}
