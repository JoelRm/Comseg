using Datos.Clases;
using Entidad;
using System.Collections.Generic;

namespace Negocio
{
    public class AlmacenNE
    {
        private static AlmacenDA obj = new AlmacenDA();

        public List<AlmacenCLS> ListarUnidadesPorFiltroProductoUnd(FiltroCLS objFiltroCLS)
        {
            return obj.ListarUnidadesPorFiltroProductoUnd(objFiltroCLS);
        }
    }
}
