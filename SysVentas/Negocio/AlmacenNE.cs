using Datos.Clases;
using Entidad;
using System.Collections.Generic;

namespace Negocio
{
    public class AlmacenNE
    {
        private static AlmacenDA obj = new AlmacenDA();

        public List<AlmacenCLS> ListarAlmacenPorFiltroProductoAlm(FiltroCLS objFiltroCLS)
        {
            return obj.ListarAlmacenPorFiltroProductoAlm(objFiltroCLS);
        }

        public int AgregarAlmacen(AlmacenCLS objAlmacenCLS)
        {
            return obj.AgregarAlmacen(objAlmacenCLS);
        }

        public List<AlmacenCLS> ListarAlmacenPorFiltro(FiltroCLS objFiltro)
        {
            return obj.ListarAlmacenPorFiltro(objFiltro);
        }

        public AlmacenCLS ObtenerAlmacenPorId(int idAlm)
        {
            return obj.ObtenerAlmacenPorId(idAlm);
        }

        public int EliminarAlmacen(AlmacenCLS objAlmacenCLS)
        {
            return obj.EliminarAlmacen(objAlmacenCLS);
        }

        public int CambiarEstadoAlmacen(AlmacenCLS objAlmacenCls)
        {
            return obj.CambiarEstadoAlmacen(objAlmacenCls);
        }

        public int EditarAlmacen(AlmacenCLS objAlmacenCLS)
        {
            return obj.EditarAlmacen(objAlmacenCLS);
        }
    }
}
